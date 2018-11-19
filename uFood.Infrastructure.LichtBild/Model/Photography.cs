using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace uFood.Infrastructure.LichtBild.Model
{
	public class Photography
	{
		[BsonId]
		public ObjectId ID { get; set; }

		public string ForeignID { get; set; }
	}
}