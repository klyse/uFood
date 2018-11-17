using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using uFood.Infrastructure.Configuration;
using uFood.Infrastructure.Models.Environment;
using uFood.ServiceLayer.MongoDB;

namespace uFood.API.Controllers
{
	[Route("api/farmer")]
	[ApiController]
	public class FarmerController : ControllerBase
	{
		private readonly IOptions<LichtBildConfiguration> _lichtBildConfiguration;
		private readonly MongoDBConnector _mongoDBConnector;

		public FarmerController(
			MongoDBConnector mongoDBConnector
		)
		{
			this._mongoDBConnector = mongoDBConnector;
		}


		[HttpGet]
		[Route("farmer/{farmerID}")]
		public ActionResult<Farmer> Farmer(string farmerID)
		{
			var result = _mongoDBConnector; // TODO

			return new JsonResult(result);
		}


		[HttpGet]
		[Route("farmerbynutrient/{nutrientID}")]
		public ActionResult<Farmer> FarmerByNutrient(string nutrientID)
		{
			var result = _mongoDBConnector; // TODO

			return new JsonResult(result);
		}
	}
}