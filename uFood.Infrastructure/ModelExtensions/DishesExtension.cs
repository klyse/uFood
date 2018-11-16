using System.Linq;
using uFood.Infrastructure.Models.Food;

namespace uFood.Infrastructure.ModelExtensions
{
	public static class DishesExtension
	{
		public static Dish GetDishByName(this Dishes nutrients, string name)
		{
			return nutrients.DishList.First(c => c.Name == name);
		}
	}
}