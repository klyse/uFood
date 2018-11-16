using System.Collections.Generic;
using uFood.Infrastructure.Models.Food;
using uFood.Infrastructure.OpenDataHub.Model;

namespace uFood.Infrastructure.OpenDataHub.ModelExtensions
{
	public static class GastronomyExtension
	{
		public static IEnumerable<Dish> GetDishesByNutrient(this Gastronomy gastronomy, Nutrient nutrient)
		{
			var dishes = new List<Dish>();


			return dishes;
		}
	}
}