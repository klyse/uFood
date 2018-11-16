using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using System.Collections.Generic;
using uFood.Infrastructure.Configuration;
using uFood.ServiceLayer.LichBild;

namespace uFood.API.Controllers
{
	[Route("api/lichtbild")]
	[ApiController]
	public class LichBildController : ControllerBase
	{
        private readonly IOptions<LichBildConfiguration>   _lichBildConfiguration;
        private readonly LichBildConnector _lichBildConnector;

        public LichBildController(
            IOptions<LichBildConfiguration> lichBildConfiguration,
            LichBildConnector lichBildConnector
            )
        {
            this._lichBildConnector = lichBildConnector;
            this._lichBildConfiguration = lichBildConfiguration;

        }



        [HttpGet]
        [Route("photo/{farmerID}")]
        public ActionResult<IEnumerable<string>> PhotosByFarmerID(string farmerID)
        {
            // TO DO: read the correct farmer using his ID
            var imageList = _lichBildConnector.GetPhotographiesByPosition(new Infrastructure.Models.Environment.Position() {
                Latitude= 46.478081, Longitude = 11.328372
            });

            return new JsonResult(imageList);

        }
    }
}