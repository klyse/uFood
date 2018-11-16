﻿using uFood.Infrastructure.Models.Food;

namespace uFood.Infrastructure.Models.Environment
{
	public class NutrientPosition
	{
		public string ID { get; set; }

		public Nutrient Nutrient { get; set; }

		public Farmer Farmer { get; set; }
	}
}