using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace uFood.Infrastructure.Models.Environment
{
	public class Farmer
	{
		[BsonId]
		public ObjectId ID { get; set; }

		public string Name { get; set; }

		public string Address { get; set; }

		public string Contact { get; set; }

		public Position Position { get; set; }
	}
}