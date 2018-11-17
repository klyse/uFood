using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using uFood.Infrastructure.Models.Environment;
using uFood.Infrastructure.Models.PointOfInterest;
using uFood.ServiceLayer.OpenDataHub;

namespace uFood.API.Controllers
{
	[Route("api/event")]
	[ApiController]
	public class EventsController : ControllerBase
	{
		private readonly OpenDataHubConnector _openDataHupConnector;

		public EventsController(
			OpenDataHubConnector openDataHupConnector
		)
		{
			this._openDataHupConnector = openDataHupConnector;
		}

		[HttpPost]
		[Route("eventbyposition")]
		public IActionResult GetEventByPosition(Position position)
		{
			var events = _openDataHupConnector.GetEventsByPosition(position);

			return new JsonResult(events);
		}
	}
}