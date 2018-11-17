using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using uFood.Infrastructure.Models.Food;
using uFood.ServiceLayer.MongoDB;
using uFood.ServiceLayer.OpenDataHub;

namespace uFood.API.Controllers
{
	[Route("api/gastronomy")]
	[ApiController]
	public class GastronomyController : ControllerBase
	{
		private readonly OpenDataHubConnector _openDataHupConnector;

		public GastronomyController(
			OpenDataHubConnector openDataHupConnector
		)
		{
			this._openDataHupConnector = openDataHupConnector;
		}


		[HttpGet]
		[Route("gastronomylist")]
		public ActionResult<Dish> DishByID()
		{
			var gastroomyList = _openDataHupConnector.GetGastronomyListByID("d");

			return new JsonResult(gastroomyList);
		}
	}
}