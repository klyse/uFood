using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Net;
using System.Text;
using System.Xml.Linq;
using uFood.Infrastructure.Configuration;
using uFood.Infrastructure.Models.Environment;

namespace uFood.ServiceLayer.LichBild
{
    public class LichBildConnector
    {
      
        private string freeReverseGeocodingEndpoint = "https://nominatim.openstreetmap.org/reverse?format=json&lat=#latitude#&lon=#longitude#&zoom=18"; // Used just to transofrm a Position entity to a Place with a name

        private readonly IOptions<LichBildConfiguration> _lichBildConfiguration;

        public LichBildConnector(IOptions<LichBildConfiguration> lichBildConfiguration)
        {
            _lichBildConfiguration = lichBildConfiguration;

        }

        public List<Uri> GetPhotographiesByPosition(Position position)
        {
            XDocument doc = new XDocument();

            // Give the name of the name represented by the Position 
            using (var client = new WebClient())
            {
                client.Headers.Add("user-agent", "Mozilla/4.0 (compatible; MSIE 6.0; Windows NT 5.2; .NET CLR 1.0.3705;)");

                var reverseGeocoding = client.DownloadString(freeReverseGeocodingEndpoint.
                    Replace("#latitude#", position.Latitude.ToString(CultureInfo.InvariantCulture)).
                     Replace("#longitude#", position.Longitude.ToString(CultureInfo.InvariantCulture))
                );

                JObject reverseGeocodingObject = (JObject)JsonConvert.DeserializeObject(reverseGeocoding);
                var city = reverseGeocodingObject["address"].SelectToken("city").Value<string>().Split(" - ")[0].Trim();  // Maybe some cyties have a composed name (Bolzano - Bozen)

                Uri baseUri = new Uri(_lichBildConfiguration.Value.OpenDataEndpoint);

                var photographyInfos = client.DownloadString(new Uri(baseUri, $"?q=CP_it:{city}&start=0&rows=20&fl=B1p, MUS,CP_geo"));

                doc = XDocument.Parse(photographyInfos);
            }

            return doc;
        }
    }
}
