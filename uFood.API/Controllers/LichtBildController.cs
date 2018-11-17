using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using System.Collections.Generic;
using uFood.Infrastructure.Configuration;
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
		[Route("photo/{farmerID}")]
		public ActionResult<IEnumerable<string>> PhotosByFarmerID(string farmerID)
		{
            var farmer = _mongoDBConnector.GetFarmersById(new MongoDB.Bson.ObjectId(farmerID));
			// TO DO: read the correct farmer using his ID
			var imageList = _lichtBildConnector.GetPhotographiesByPosition(farmer.Position);

			return new JsonResult(imageList);
		}
	}
}