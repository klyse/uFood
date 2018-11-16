using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace uFood.Infrastructure.Models.Food
{
	public class Nutrient
	{
		[BsonId]
		public ObjectId ID { get; set; }

		public string Name { get; set; }

		public string Description { get; set; }
	}
}