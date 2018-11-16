using System.Collections.Generic;
using uFood.Infrastructure.Models.Food;

namespace uFood.Infrastructure.OpenDataHub.Model
{
	public class Gastronomy
	{
		public string ID { get; set; }

		public string ForeignID { get; set; }

		public IEnumerable<Dish> Dishes { get; set; }
	}
}