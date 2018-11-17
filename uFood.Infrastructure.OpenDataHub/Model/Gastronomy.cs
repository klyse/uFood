using System.Collections.Generic;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace uFood.Infrastructure.OpenDataHub.Model
{
	public class Gastronomy
	{
		[BsonId]
		public ObjectId ID { get; set; }

		public string ForeignID { get; set; }

		public IEnumerable<ObjectId> Dishes { get; set; }
	}
}