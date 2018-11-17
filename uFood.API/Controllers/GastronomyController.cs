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

		public GastronomyController(
            OpenDataHubConnector openDataHupConnector
        )
		{
			this._openDataHupConnector = openDataHupConnector;
		}


		[HttpGet]
		[Route("gastronomy/{gastronomyID}")]
		public ActionResult GetGastronomyByID(string gastronomyID)
		{
            var gastronomy = _openDataHupConnector.GetGastronomyByID(gastronomyID);

			return new JsonResult(gastronomy);
		}

	}
}