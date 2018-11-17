﻿using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
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
            Dish dish = new Dish();

            //TODO get the dish by ID

            return new JsonResult(dish);
		}


        [HttpGet]
        [Route("dishesbynutrient/{nutrientName}")]
        public ActionResult<List<Dish>>DishesByNutrient(string nutrientName)
        {
            List<Dish> list = new List<Dish>();

            //TODO get the dishes that have the nutrient inside

            return list;
        }
    }
}