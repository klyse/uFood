using System.Collections.Generic;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace uFood.Infrastructure.Models.Food
{
	public class Recipe
	{
		[BsonId]
		public ObjectId ID { get; set; }

		public string Name { get; set; }

		public IEnumerable<Ingredient> Ingredients { get; set; }
	}
}