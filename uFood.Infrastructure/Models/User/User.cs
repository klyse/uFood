using System.Collections.Generic;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using uFood.Infrastructure.Models.Food;

namespace uFood.Infrastructure.Models.User
{
	public class User
	{
		[BsonId]
		public ObjectId ID { get; set; }

		public string Name { get; set; }

		public IEnumerable<Intolerance.Intolerance> Intolerances { get; set; }

		public IEnumerable<Dish> History { get; set; }
	}
}