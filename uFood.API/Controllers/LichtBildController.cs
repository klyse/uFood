using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using System.Collections.Generic;
using uFood.Infrastructure.Configuration;
using uFood.Infrastructure.Models.Environment;
using uFood.Infrastructure.OpenDataHub.Model;
using uFood.ServiceLayer.LichtBild;
using uFood.ServiceLayer.MongoDB;

namespace uFood.API.Controllers
{
	[Route("api/lichtbild")]
	[ApiController]
	public class LichtBildController : ControllerBase
	{
		private readonly IOptions<LichtBildConfiguration> _lichtBildConfiguration;
		private readonly LichtBildConnector _lichtBildConnector;
		private readonly MongoDBConnector _mongoDBConnector;

		public LichtBildController(
			IOptions<LichtBildConfiguration> lichtBildConfiguration,
			LichtBildConnector lichtBildConnector,
			MongoDBConnector mongoDBConnector
		)
		{
			this._lichtBildConnector = lichtBildConnector;
			this._lichtBildConfiguration = lichtBildConfiguration;
			this._mongoDBConnector = mongoDBConnector;
		}


		[HttpGet]
		[Route("photobyfarmer/{farmerID}")]
		public ActionResult<IEnumerable<string>> PhotosByFarmerID(string farmerID)
		{
			Farmer farmer = _mongoDBConnector.GetFarmersById(farmerID);

			if (farmer == null)
				return NotFound("Farmer not found");

			var imageList = _lichtBildConnector.GetPhotographiesByPosition(farmer.Position);

			return new JsonResult(imageList);
		}

		[HttpGet]
		[Route("photobygastronomy/{gastronomyID}")]
		public ActionResult<IEnumerable<string>> PhotosByGastronomyID(string gastronomyID)
		{
			Gastronomy gastronomy = null;
			try
			{
				//gastronomy = _mongoDBConnector.GetFarmersById(new MongoDB.Bson.ObjectId(gastronomyID));
			}
			catch
			{
			}

			if (gastronomy == null)
				return NotFound("GastronomyID not found");

			var imageList = _lichtBildConnector.GetPhotographiesByPosition(gastronomy.Position);

			return new JsonResult(imageList);
		}
	}
}