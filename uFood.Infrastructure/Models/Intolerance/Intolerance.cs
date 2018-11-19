using System.Collections.Generic;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace uFood.Infrastructure.Models.Intolerance
{
	public class Intolerance
	{
		[BsonId]
		public ObjectId ID { get; set; }

		public string Name { get; set; }

		public string Description { get; set; }

		public IEnumerable<string> EvilNutrients { get; set; }
	}
}