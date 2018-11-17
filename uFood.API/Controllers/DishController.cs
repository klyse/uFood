using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using uFood.Infrastructure.Models.Food;
using uFood.ServiceLayer.MongoDB;

namespace uFood.API.Controllers
{
	[Route("api/dish")]
	[ApiController]
	public class DishController : ControllerBase
	{
		private readonly MongoDBConnector _mongoDBConnector;

		public DishController(
			MongoDBConnector mongoDBConnector
		)
		{
			this._mongoDBConnector = mongoDBConnector;
		}


		[HttpGet]
		[Route("dish/{dishID}")]
		public ActionResult<Dish> DishByID(string dishID)
		{
			var dish = _mongoDBConnector.GetDishById(dishID);

			if (dish is null)
				return NotFound("Dish not found");

			return new JsonResult(dish);
		}

		
		[HttpGet]
		[Route("dishesbynutrient/{nutrientName}")]
		public ActionResult<IEnumerable<Dish>> DishesByNutrient(string nutrientName)
		{
			var list = _mongoDBConnector.GetDishesByNutrient(nutrientName);

			if (list is null || !list.Any())
				return NotFound("Dish not found");

			return new JsonResult(list);
		}

		[HttpGet]
		[Route("dishbynutrientforuser/{userID}/{nutrientName}")]
		public ActionResult<IEnumerable<Dish>> DishesByNutrient(string userID, string nutrientName)
		{
			var result = _mongoDBConnector.GetDishesByNutrient(userID, nutrientName);

			if (result is null)
				return NotFound("Dish or User not found");

			return new JsonResult(result);
		}
	}
}