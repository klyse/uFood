using Microsoft.Extensions.Options;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Text;
using uFood.Infrastructure.Configuration;
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

        public List<Gastronomy> GetGastronomyListByID(string gastronomyID)
        {
            List<Gastronomy> list = new List<Gastronomy>();

            var client = new RestClient(_openDataHubConfiguration.Value.OpenDataEndpoint);

            var request = new RestRequest("Gastronomy", Method.GET);
            request.AddHeader("authorization", "Bearer " + GetAuthToken());

            var response = client.Execute(request);
           

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
