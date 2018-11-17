using System.IO;
using System.Linq;
using Google.Cloud.Dialogflow.V2;
using Google.Protobuf;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json.Linq;
using uFood.API.Models;

namespace uFood.API.Helper
{
	/// <summary>
	/// Google json helper.
	/// Plase refer to https://cloud.google.com/dialogflow-enterprise/docs/reference/rest/Shared.Types/ for the JSON documentation
	/// </summary>
	public class GoogleJsonHelper
	{
		private static readonly JsonParser jsonParser = new JsonParser(JsonParser.Settings.Default.WithIgnoreUnknownFields(true)); // Google parser

		public GoogleJsonHelper()
		{
		}

		public WebhookRequest GetWebhook(HttpRequest httpRequest)
		{
			// Parse the body of the request using the Protobuf JSON parser,
			// *not* Json.NET.
			WebhookRequest request;
			using (var reader = new StreamReader(httpRequest.Body))
			{
				request = jsonParser.Parse<WebhookRequest>(reader);
			}

			return request;
		}

		public LocationDTO GetLocation(WebhookRequest request)
		{
			LocationDTO result = new LocationDTO();

			try
			{
				var device = request.OriginalDetectIntentRequest.Payload.Fields.Where(x => x.Key.ToLower() == "device").FirstOrDefault();

				JObject deviceAsJSONObject = JObject.Parse(device.Value.ToString());

				result.Latitude = (double?)deviceAsJSONObject["location"]?.SelectToken("coordinates.latitude");
				result.Longitude = (double?)deviceAsJSONObject["location"]?.SelectToken("coordinates.longitude");
				result.City = (string)deviceAsJSONObject["location"]?.SelectToken("city");
				result.Address = (string)deviceAsJSONObject["location"]?.SelectToken("formattedAddress");
				result.ZIPCode = (string)deviceAsJSONObject["location"]?.SelectToken("zipCode");
			}
			catch
			{
			}

			return result;
		}

		public UserDTO GetUser(WebhookRequest request)
		{
			UserDTO result = new UserDTO();

			try
			{
				var device = request.OriginalDetectIntentRequest.Payload.Fields.Where(x => x.Key.ToLower() == "user").FirstOrDefault();

				JObject userAsJSONObject = JObject.Parse(device.Value.ToString());

				result.FirstName = (string)userAsJSONObject?.SelectToken("profile.givenName");
				result.LastName = (string)userAsJSONObject?.SelectToken("profile.familyName");
				result.UserID = (string)userAsJSONObject?.SelectToken("userId");
			}
			catch
			{
			}

			return result;
		}

		public string GetNutrientName(WebhookRequest request)
		{
			try
			{
			}
			catch
			{
			}

			return "";
		}
	}
}