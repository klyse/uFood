using AutoMapper;
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
		private readonly MongoDBConnector _mongoDBConnector;

        IMapper mapper;

		public GastronomyController(
            OpenDataHubConnector openDataHupConnector,
			MongoDBConnector mongoDBConnector
        )
		{
			this._openDataHupConnector = openDataHupConnector;
			_mongoDBConnector = mongoDBConnector;

            AutoMapper.Mapper.Initialize(cfg => cfg.CreateMap<Gastronomy, MergedGastronomy>());
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

		[HttpGet]
		[Route("gastronomybydish/{dishId}")]
		public ActionResult GetGastronomyByDishId(string dishId)
		{
            List<MergedGastronomy> list = new List<MergedGastronomy>();
			var gastronomies = _mongoDBConnector.GetGastronomiesByDishId(dishId);
            foreach (var g in gastronomies)
            {
                var openDataGastronomy = _openDataHupConnector.GetGastronomyByID(g.ForeignID);
                MergedGastronomy mergedGastronomy = mapper.Map<MergedGastronomy>(g);

                list.Add(mergedGastronomy);
            }
          

            return new JsonResult(list);
		}

	}
}