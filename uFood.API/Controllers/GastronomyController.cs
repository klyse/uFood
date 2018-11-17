using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using uFood.Infrastructure.Models.Food;
using uFood.Infrastructure.OpenDataHub.Model;
using uFood.ServiceLayer.MongoDB;
using uFood.ServiceLayer.OpenDataHub;

namespace uFood.API.Controllers
{
	[Route("api/gastronomy")]
	[ApiController]
	public class GastronomyController : ControllerBase
	{
		private readonly OpenDataHubConnector _openDataHupConnector;
		private readonly MongoDBConnector _mongoDBConnector;

		public GastronomyController(
            OpenDataHubConnector openDataHupConnector,
			MongoDBConnector mongoDBConnector
        )
		{
			this._openDataHupConnector = openDataHupConnector;
			_mongoDBConnector = mongoDBConnector;
		}

		
		[HttpGet]
		[Route("gastronomy/{gastronomyID}")]
		public ActionResult GetGastronomyByID(string gastronomyID)
		{
			var gastronomy = _openDataHupConnector.GetGastronomyByID(gastronomyID);

			return new JsonResult(gastronomy);
		}

		[HttpGet]
		[Route("gastronomybydish/{dishId}")]
		public ActionResult GetGastronomyByDishId(string dishId)
		{
			var gastronomy = _mongoDBConnector.GetGastronomiesByDishId(dishId);

			return new JsonResult(gastronomy);
		}

	}
}