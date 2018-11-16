using MongoDB.Bson;

namespace uFood.Infrastructure.LichtBild.Model
{
	public class Photography
	{
		public ObjectId ID { get; set; }

		public string ForeignID { get; set; }
	}
}