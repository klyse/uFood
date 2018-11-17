using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using MongoDB.Bson;
using uFood.ServiceLayer.MongoDB;

namespace uFood.API.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class ValuesController : ControllerBase
	{
		private readonly MongoDBConnector _mongoDBConnector;

		public ValuesController(MongoDBConnector mongoDBConnector)
		{
			_mongoDBConnector = mongoDBConnector;
		}

		// GET api/values
		[HttpGet]
		public ActionResult<IEnumerable<string>> Get()
		{
			var recipes= _mongoDBConnector.GetFarmersById(new ObjectId("5bef624a26d5435724487ae9"));
			return new JsonResult(recipes);
		}

		// GET api/values/5
		[HttpGet("{id}")]
		public ActionResult<string> Get(int id)
		{
			return "value";
		}

		// POST api/values
		[HttpPost]
		public void Post([FromBody] string value)
		{
		}

		// PUT api/values/5
		[HttpPut("{id}")]
		public void Put(int id, [FromBody] string value)
		{
		}

		// DELETE api/values/5
		[HttpDelete("{id}")]
		public void Delete(int id)
		{
		}
	}
}