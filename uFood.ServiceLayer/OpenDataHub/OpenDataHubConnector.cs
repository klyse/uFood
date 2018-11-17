using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using uFood.Infrastructure.Configuration;
using uFood.Infrastructure.Models.Environment;
using uFood.Infrastructure.Models.PointOfInterest;
using uFood.Infrastructure.OpenDataHub.Model;

namespace uFood.ServiceLayer.OpenDataHub
{
	public class OpenDataHubConnector
	{
		private readonly IOptions<OpenDataHubConfiguration> _openDataHubConfiguration;

		public OpenDataHubConnector(IOptions<OpenDataHubConfiguration> openDataHubConfiguration)
		{
			_openDataHubConfiguration = openDataHubConfiguration;
		}

		public string GetGastronomyByID(string gastronomyID)
		{
			var client = new RestClient(_openDataHubConfiguration.Value.OpenDataEndpoint);

			var request = new RestRequest("Gastronomy/{id}", Method.GET);
			request.AddUrlSegment("id", gastronomyID);
			request.AddQueryParameter("categorycodefilter", "1"); // Just restaurants
			request.AddHeader("authorization", "Bearer " + GetAuthToken());


			return client.Execute(request).Content;
		}

		public string GetGastronomyByPosition(Position position)
		{
			var client = new RestClient(_openDataHubConfiguration.Value.OpenDataEndpoint);

			var request = new RestRequest("Gastronomy", Method.GET);
			request.AddQueryParameter("latitude", position.Latitude.ToString(CultureInfo.InvariantCulture));
			request.AddQueryParameter("longitude", position.Longitude.ToString(CultureInfo.InvariantCulture));
			request.AddQueryParameter("radius", 1000.ToString());
			request.AddQueryParameter("categorycodefilter", "1"); // Just restaurants

			request.AddHeader("authorization", "Bearer " + GetAuthToken());


			return client.Execute(request).Content;
		}

		public List<Event> GetEventsByPosition(Position position)
		{
			List<Event> list = new List<Event>();

			var client = new RestClient(_openDataHubConfiguration.Value.OpenDataEndpoint);

			var request = new RestRequest("Event", Method.GET);
			request.AddQueryParameter("latitude", position.Latitude.ToString(CultureInfo.InvariantCulture));
			request.AddQueryParameter("longitude", position.Longitude.ToString(CultureInfo.InvariantCulture));
			request.AddQueryParameter("radius", 1000.ToString());
			request.AddQueryParameter("topicfilter", 4.ToString());

			request.AddHeader("authorization", "Bearer " + GetAuthToken());

			var json = client.Execute(request).Content;

			JObject serializedJSON = (JObject)JsonConvert.DeserializeObject(json);

			// Create the Event entities
			foreach (JObject item in serializedJSON["Items"].ToObject<List<object>>().ToArray())
			{
				Event e = new Event();
				e.Name = item["Detail"]["en"]["Title"].ToString();
				e.Description = item["Detail"]["en"]["BaseText"].ToString();
				e.Date = DateTime.Parse(item["DateBegin"].ToString());
				list.Add(e);
			}

			return list;
		}

		private string GetAuthToken()
		{
			var client = new RestClient(_openDataHubConfiguration.Value.OpenDataEndpoint);

			var request = new RestRequest("LoginApi", Method.POST);
			request.AddParameter("username", "tourism@hackathon.bz.it");
			request.AddParameter("pswd", "V3rT1c4lInn0v4ti0n$");
			request.AddParameter("returnurl", "string");

			AuthResponse response = client.Execute<AuthResponse>(request).Data;
			return response.access_token;
		}
	}
}