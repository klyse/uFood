using System.Collections.Generic;
using uFood.Infrastructure.Models.Food;

namespace uFood.Infrastructure.Models.Intolerance
{
	public class Intolerance
	{
		public string ID { get; set; }

		public string Name { get; set; }

		public string Description { get; set; }

		public IEnumerable<Nutrient> EvilNutrients { get; set; }
	}
}