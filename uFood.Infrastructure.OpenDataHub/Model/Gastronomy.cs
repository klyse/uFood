using System.Collections.Generic;
using MongoDB.Bson;
using uFood.Infrastructure.Models.Food;

namespace uFood.Infrastructure.OpenDataHub.Model
{
	public class Gastronomy
	{
		public ObjectId ID { get; set; }

		public string ForeignID { get; set; }

		public IEnumerable<Dish> Dishes { get; set; }
	}
}