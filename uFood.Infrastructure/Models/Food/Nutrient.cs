using MongoDB.Bson;

namespace uFood.Infrastructure.Models.Food
{
	public class Nutrient
	{
		public ObjectId ID { get; set; }

		public string Name { get; set; }

		public string Description { get; set; }
	}
}