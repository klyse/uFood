using System.Collections.Generic;
using MongoDB.Bson;
using uFood.Infrastructure.Models.Food;

namespace uFood.Infrastructure.Models.Intolerance
{
	public class Intolerance
	{
		public ObjectId ID { get; set; }

		public string Name { get; set; }

		public string Description { get; set; }

		public IEnumerable<Nutrient> EvilNutrients { get; set; }
	}
}