using System.Collections.Generic;
using MongoDB.Bson;

namespace uFood.Infrastructure.Models.Food
{
	public class Recipe
	{
		public ObjectId ID { get; set; }

		public string Name { get; set; }

		public IEnumerable<Ingredient> Ingredients { get; set; }
	}
}