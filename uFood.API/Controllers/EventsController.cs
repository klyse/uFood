using Microsoft.AspNetCore.Mvc;
using uFood.Infrastructure.Models.Environment;
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
		public ActionResult GetEventByPosition(Position position)
		{
			var events = _openDataHupConnector.GetEventsByPosition(position);

			return new JsonResult(events);
		}
	}
}