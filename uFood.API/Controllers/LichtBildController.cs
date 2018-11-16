using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using System.Collections.Generic;
using uFood.Infrastructure.Configuration;
using uFood.ServiceLayer.LichtBild;

namespace uFood.API.Controllers
{
	[Route("api/lichtbild")]
	[ApiController]
	public class LichtBildController : ControllerBase
	{
		private readonly IOptions<LichtBildConfiguration> _lichtBildConfiguration;
		private readonly LichtBildConnector _lichtBildConnector;

		public LichtBildController(
			IOptions<LichtBildConfiguration> lichtBildConfiguration,
			LichtBildConnector lichtBildConnector
		)
		{
			this._lichtBildConnector = lichtBildConnector;
			this._lichtBildConfiguration = lichtBildConfiguration;
		}


		[HttpGet]
		[Route("photo/{farmerID}")]
		public ActionResult<IEnumerable<string>> PhotosByFarmerID(string farmerID)
		{
			// TO DO: read the correct farmer using his ID
			var imageList = _lichtBildConnector.GetPhotographiesByPosition(new Infrastructure.Models.Environment.Position()
			{
				Latitude = 46.478081, Longitude = 11.328372
			});

			return new JsonResult(imageList);
		}
	}
}