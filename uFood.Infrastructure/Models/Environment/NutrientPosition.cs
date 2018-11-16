using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using uFood.Infrastructure.Models.Food;

namespace uFood.Infrastructure.Models.Environment
{
	public class NutrientPosition
	{
		[BsonId]
		public ObjectId ID { get; set; }

		public Nutrient Nutrient { get; set; }

		public Farmer Farmer { get; set; }
	}
}