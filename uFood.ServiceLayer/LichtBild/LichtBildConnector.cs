using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Xml.Linq;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using uFood.Infrastructure.Configuration;
using uFood.Infrastructure.Models.Environment;

namespace uFood.ServiceLayer.LichtBild
{
	public class LichtBildConnector
	{
		private string freeReverseGeocodingEndpoint =
			"https://nominatim.openstreetmap.org/reverse?format=json&lat=#latitude#&lon=#longitude#&zoom=18"; // Used just to transofrm a Position entity to a Place with a name

		private string
			lichtBildImageUrl =
				"https://cert.provinz.bz.it/services/kksSearch/image?file=#filename#&size=s&mus=#mus#"; // Used just to transofrm a Position entity to a Place with a name


		private readonly IOptions<LichtBildConfiguration> _lichtBildConfiguration;

		public LichtBildConnector(IOptions<LichtBildConfiguration> lichtBildConfiguration)
		{
			_lichtBildConfiguration = lichtBildConfiguration;
		}

		public List<Uri> GetPhotographiesByPosition(Position position)
		{
			List<Uri> photos = new List<Uri>();

			// Give the name of the name represented by the Position 
			using (var client = new WebClient())
			{
				client.Headers.Add("user-agent", "Mozilla/4.0 (compatible; MSIE 6.0; Windows NT 5.2; .NET CLR 1.0.3705;)");

				var reverseGeocoding = client.DownloadString(freeReverseGeocodingEndpoint
															 .Replace("#latitude#", position.Latitude.ToString(CultureInfo.InvariantCulture))
															 .Replace("#longitude#", position.Longitude.ToString(CultureInfo.InvariantCulture))
															);

				JObject reverseGeocodingObject = (JObject)JsonConvert.DeserializeObject(reverseGeocoding);
				var city = (reverseGeocodingObject["address"].SelectToken("city") ?? reverseGeocodingObject["address"].SelectToken("town"))
						   .Value<string>().Split(" - ")[0].Trim(); // Maybe some cyties have a composed name (Bolzano - Bozen)

				Uri baseUri = new Uri(_lichtBildConfiguration.Value.OpenDataEndpoint);

				var photographyInfos = client.DownloadString(new Uri(baseUri, $"?q=CP_it:{city} and OB_it=fotografia&start=0&rows=20&fl=B1p, MUS"));

				XDocument doc = XDocument.Parse(photographyInfos);

				if (doc.Descendants("doc").Count() == 0) // try with the german language for the town name
				{
					photographyInfos = client.DownloadString(new Uri(baseUri, $"?q=CP_de:{city}&start=0&rows=20&fl=B1p, MUS"));
					doc = XDocument.Parse(photographyInfos);
				}

				foreach (var item in doc.Descendants("doc"))
				{
					var tokens = item.Descendants("str").Select(x => x.Value).ToArray();

					var imageUrl = lichtBildImageUrl.Replace("#filename#", tokens[0]).Replace("#mus#", tokens[1]);

					photos.Add(new Uri(imageUrl));
				}
			}

			return photos;
		}
	}
}