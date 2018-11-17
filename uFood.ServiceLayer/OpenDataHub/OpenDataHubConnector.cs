using Microsoft.Extensions.Options;
using RestSharp;
using System.Globalization;
using uFood.Infrastructure.Configuration;
using uFood.Infrastructure.Models.Environment;

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

			request.AddHeader("authorization", "Bearer " + GetAuthToken());


			return client.Execute(request).Content;
		}

		public string GetEventsByPosition(Position position)
		{
			var client = new RestClient(_openDataHubConfiguration.Value.OpenDataEndpoint);

			var request = new RestRequest("Event", Method.GET);
			request.AddQueryParameter("latitude", position.Latitude.ToString(CultureInfo.InvariantCulture));
			request.AddQueryParameter("longitude", position.Longitude.ToString(CultureInfo.InvariantCulture));
			request.AddQueryParameter("radius", 1000.ToString());
			request.AddQueryParameter("topicfilter", 4.ToString());

			request.AddHeader("authorization", "Bearer " + GetAuthToken());

			return client.Execute(request).Content;
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