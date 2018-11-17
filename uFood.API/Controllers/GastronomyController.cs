using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using uFood.Infrastructure.Models.Environment;
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
		private readonly MongoDBConnector _mongoDBConnector;

        IMapper mapper;

		public GastronomyController(
            OpenDataHubConnector openDataHupConnector,
			MongoDBConnector mongoDBConnector
        )
		{
			this._openDataHupConnector = openDataHupConnector;
			_mongoDBConnector = mongoDBConnector;

         
            var mapperConfig = new MapperConfiguration(cfg => cfg.CreateMap<Gastronomy, MergedGastronomy>());
            mapper = mapperConfig.CreateMapper();
        }


        [HttpGet]
		[Route("gastronomy/{gastronomyID}")]
		public ActionResult GetGastronomyByID(string gastronomyID)
		{
			var gastronomy = _openDataHupConnector.GetGastronomyByID(gastronomyID);

			return new JsonResult(gastronomy);
		}


        [HttpPost]
        [Route("gastronomybyposition")]
        public ActionResult GetGastronomyByPosition(Position position)
        {
            var gastronomy = _openDataHupConnector.GetGastronomyByPosition(position);

            return new JsonResult(gastronomy);
        }

        [HttpGet]
		[Route("gastronomybynutrient/{nutrientID}")]
		public ActionResult GetGastronomyByNutrient(string nutrientID)
		{
            List<MergedGastronomy> list = new List<MergedGastronomy>();


            var dishesContainingNutrient = _mongoDBConnector.GetDishesByNutrient(nutrientID);
            var dishesIDContainingNutrient = dishesContainingNutrient.Select(x => x.ID).ToList();

            foreach (var dish in dishesContainingNutrient)
            {
                var gastronomies = _mongoDBConnector.GetGastronomiesByDishId(dish.ID.ToString());
                foreach (var g in gastronomies)
                {
                    var openDataGastronomy = _openDataHupConnector.GetGastronomyByID(g.ForeignID);
                    JObject openDataGastronomyJson = (JObject)JsonConvert.DeserializeObject(openDataGastronomy);

                    MergedGastronomy mergedGastronomy = mapper.Map<MergedGastronomy>(g);

                    mergedGastronomy.Name = openDataGastronomyJson["Detail"]["en"]["Title"].ToString();
                    mergedGastronomy.ZipCode = openDataGastronomyJson["ContactInfos"]["en"]["Address"].ToString();
                    mergedGastronomy.ZipCode = openDataGastronomyJson["ContactInfos"]["en"]["ZipCode"].ToString();
                    if (openDataGastronomyJson["ImageGallery"] != null && openDataGastronomyJson["ImageGallery"].Count() > 0)
                    {
                        mergedGastronomy.ImageUrl = openDataGastronomyJson["ImageGallery"].FirstOrDefault()["ImageUrl"].ToString();
                    }
                    mergedGastronomy.Position = new Position()
                    {
                        Altitude = Convert.ToInt32(openDataGastronomyJson["Altitude"]),
                        Latitude = Convert.ToDouble(openDataGastronomyJson["Latitude"]),
                        Longitude = Convert.ToDouble(openDataGastronomyJson["Longitude"])
                    };
                    mergedGastronomy.DishesContainingNutrient = new List<string>();
                   
                    foreach (var id in mergedGastronomy.Dishes)
                    {
                        if(dishesIDContainingNutrient.Contains(id))
                            mergedGastronomy.DishesContainingNutrient.Add(_mongoDBConnector.GetDishById(id.ToString()).Name);
                    }

                    list.Add(mergedGastronomy);
                }
            }
            
          

            return new JsonResult(list);
		}

	}
}