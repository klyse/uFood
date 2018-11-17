using System.Collections.Generic;
using uFood.Infrastructure.Models.Environment;
using uFood.Infrastructure.Models.Food;
using uFood.ServiceLayer.MongoDB;

namespace uFood.ServiceLayer
{
	public static class MockData
	{
		#region Public Properties

		public static IEnumerable<Farmer> Farmers { get; set; }
		public static IEnumerable<Dish> Dishes { get; set; }

		#endregion

		#region MockGeneration

		public static void GenerateFarms()
		{
			Farmers = new List<Farmer>
			{
				new Farmer
				{
					Name = "Franz Josef's Kartoffeln",
					Address = "Brunneck",
					Contact = "Franz.Josef@gmail.com",
					Position = new Position(46.794421, 11.941683)
				},
				new Farmer
				{
					Name = "Paula's Äpfel",
					Address = "Brunneck",
					Contact = "Paula12@gmail.com",
					Position = new Position(46.798900, 11.942383)
				},
				new Farmer
				{
					Name = "Micheles Verdure",
					Address = "Bolzano",
					Contact = "m.Verdure@gmail.com",
					Position = new Position(46.4790589, 11.3329809)
				},
			};
		}

		public static void GenerateDishes(MongoDBConnector connector)
		{
			Dishes = new List<Dish>
			{
				new Dish
				{
					Name = "Penne all'amatriciana with Parmigiano Italiano",
					Ingredients = new List<Ingredient>
					{
						new Ingredient
						{
							Nutrient = new Nutrient
							{
								Name = "Flour",
								Description = "Made out of wheat"
							},
							Quantity = 200
						},
						new Ingredient
						{
							Nutrient = new Nutrient
							{
								Name = "Tomato"
							},
							Quantity = 2
						},
						new Ingredient
						{
							Nutrient = new Nutrient
							{
								Name = "Parmigiano",
								Description = "Italian Parmigiano"
							},
							Quantity = 3
						}
					}
				},
				new Dish
				{
					Name = "Superb Spaghetti Carbonara",
					Ingredients = new List<Ingredient>
					{
						new Ingredient
						{
							Nutrient = new Nutrient
							{
								Name = "Flour",
								Description = "Made out of wheat"
							},
							Quantity = 12
						}
					}
				}
			};
		}

		public static void GenerateMockData(MongoDBConnector connector)
		{
			GenerateFarms();
			GenerateDishes(connector);
		}

		#endregion
	}
}