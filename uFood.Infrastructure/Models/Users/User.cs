using System.Collections.Generic;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace uFood.Infrastructure.Models.Users
{
	public class User
	{
		[BsonId]
		public ObjectId ID { get; set; }

		public string Name { get; set; }

		public IEnumerable<ObjectId> Intolerances { get; set; }
	}
}