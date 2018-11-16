﻿using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace uFood.Infrastructure.Models.Food
{
	public class Nutrient
	{
		public string Name { get; set; }

		public string Description { get; set; }
	}
}