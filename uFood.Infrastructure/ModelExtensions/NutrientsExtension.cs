using System.Linq;
using uFood.Infrastructure.Models.Food;

namespace uFood.Infrastructure.ModelExtensions
{
	public static class NutrientsExtension
	{
		public static Nutrient GetNutrientByID(this Nutrients nutrients, string id)
		{
			return nutrients.NutrientsList.First(c => c.ID.ToString() == id);
		}
	}
}