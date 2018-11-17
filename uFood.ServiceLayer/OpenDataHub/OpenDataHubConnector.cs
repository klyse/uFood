using Microsoft.Extensions.Options;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using uFood.Infrastructure.Configuration;
using uFood.Infrastructure.Models.Environment;
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
			MergedGastronomy gastronomy = new MergedGastronomy();

			var client = new RestClient(_openDataHubConfiguration.Value.OpenDataEndpoint);

			var request = new RestRequest("Gastronomy/{id}", Method.GET);
			request.AddUrlSegment("id", gastronomyID);
			request.AddHeader("authorization", "Bearer " + GetAuthToken());


			return client.Execute(request).Content;
		}

        public string GetGastronomyByPosition(Position position)
        {
            MergedGastronomy gastronomy = new MergedGastronomy();

            var client = new RestClient(_openDataHubConfiguration.Value.OpenDataEndpoint);

            var request = new RestRequest("Gastronomy", Method.GET);
            request.AddQueryParameter("latitude", position.Latitude.ToString(CultureInfo.InvariantCulture));
            request.AddQueryParameter("longitude", position.Longitude.ToString(CultureInfo.InvariantCulture));
            request.AddQueryParameter("radius", 1000.ToString());

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