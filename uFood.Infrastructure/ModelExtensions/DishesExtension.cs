using System.Linq;
using uFood.Infrastructure.Models.Food;

namespace uFood.Infrastructure.ModelExtensions
{
	public static class DishesExtension
	{
		public static Dish GetDishByID(this Dishes nutrients, string id)
		{
			return nutrients.DishList.First(c => c.ID.ToString() == id);
		}
	}
}