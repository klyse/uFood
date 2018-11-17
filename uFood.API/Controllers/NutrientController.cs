using Google.Cloud.Dialogflow.V2;
using Google.Dialogflow.TestWebHook.Helper;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using uFood.Infrastructure.Models.Food;
using uFood.ServiceLayer.MongoDB;
using static Google.Cloud.Dialogflow.V2.Intent.Types;
using static Google.Cloud.Dialogflow.V2.Intent.Types.Message.Types;

namespace uFood.API.Controllers
{
	[Route("api/nutrient")]
	[ApiController]
	public class NutrientController : ControllerBase
	{
		private readonly MongoDBConnector _mongoDBConnector;
		private readonly GoogleJsonHelper _googleJsonHelper;

		public NutrientController(
			MongoDBConnector mongoDBConnector,
			GoogleJsonHelper googleJsonHelper
		)
		{
			this._mongoDBConnector = mongoDBConnector;
			this._googleJsonHelper = googleJsonHelper;
		}


		[HttpPost]
		[Route("google/checknutrient")]
		public ContentResult CheckNutrient(string nutrientName)
		{
			var webhookRequest = _googleJsonHelper.GetWebhook(Request);

			WebhookResponse response = new WebhookResponse();

			if (webhookRequest.QueryResult.Parameters.Fields.ContainsKey("Nutrient"))
			{
				var nutrient = webhookRequest.QueryResult.Parameters.Fields.GetValueOrDefault("Nutrient").StringValue;

				// TODO Check if the nutrient is ok
				var nutrientCheckResult = _mongoDBConnector.CheckNutrient(nutrient);

				SimpleResponses simpleResponses = new SimpleResponses();
				SimpleResponse simpleResponse = null;

				if (nutrientCheckResult.IsEvilForYou)
				{
					simpleResponse = new SimpleResponse()
					{
						DisplayText =
							$"Sorry, the {nutrient} seems to be evil for you, because {nutrientCheckResult.Message}. I suggest you this alternative: {nutrientCheckResult.AlternativeNutrient}",
						TextToSpeech =
							$"Sorry, the {nutrient} seems to be evil for you, because {nutrientCheckResult.Message}. I suggest you this alternative: {nutrientCheckResult.AlternativeNutrient}"
					};
				}
				else
				{
					simpleResponse = new SimpleResponse()
					{
						DisplayText = $"OK {nutrient} seems ok! Would you like to eat it at home, or outside?",
						TextToSpeech = $"OK {nutrient} seems ok! Would you like to eat it at home, or outside?"
					};
				}

				simpleResponses.SimpleResponses_.Add(simpleResponse);

				response.FulfillmentMessages.Add(new Message()
				{
					Platform = Platform.ActionsOnGoogle,
					SimpleResponses = simpleResponses
				});
			}


			string responseJson = response.ToString();
			return Content(responseJson, "application/json");
		}
	}
}