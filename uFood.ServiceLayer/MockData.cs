using System.Collections.Generic;
using MongoDB.Bson;
using uFood.Infrastructure.Models.Environment;
using uFood.Infrastructure.Models.Food;
using uFood.Infrastructure.Models.Intolerance;
using uFood.Infrastructure.Models.User;
using uFood.ServiceLayer.MongoDB;

namespace uFood.ServiceLayer
{
	public static class MockData
	{
		#region Public Properties

		public static IEnumerable<Farmer> Farmers { get; set; }
		public static IEnumerable<Dish> Dishes { get; set; }
		public static IEnumerable<Intolerance> Intolerances { get; set; }
		public static IEnumerable<User> Users { get; set; }

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

		public static void GenerateIntolerances(MongoDBConnector connector)
		{
			Intolerances = new List<Intolerance>
			{
				new Intolerance
				{
					Name = "Dairy",
					Description = "Lactose intolerance is caused by a shortage of lactase enzymes, which causes an inability to digest lactose and results in digestive symptoms.",
					EvilNutrients = new List<string>
					{
						"Milk",
						"Cheese",
						"Yogurt"
					}
				},
				new Intolerance
				{
					Name = "Gluten",
					Description = "Gluten is the general name given to proteins found in wheat, barley, rye and triticale.",
					EvilNutrients = new List<string>
					{
						"Bread",
						"Pasta",
						"Beer"
					}
				}
			};
		}

		public static void GenerateUser()
		{
			Users = new List<User>
			{
				new User
				{
					Name = "Marc",
					Intolerances = new List<ObjectId>
					{
						new ObjectId("5bef797fa3b2aa6a3cec950a")
					}
				},
				new User
				{
					Name = "Ellen",
				},
				new User
				{
					Name = "Merry",
					Intolerances = new List<ObjectId>
					{
						new ObjectId("5bef797fa3b2aa6a3cec950a"),
						new ObjectId("5bef797fa3b2aa6a3cec950b")
					}
				}
			};
		}

		public static void GenerateMockData(MongoDBConnector connector)
		{
			GenerateFarms();
			GenerateDishes(connector);
			GenerateIntolerances(connector);
			GenerateUser();
		}

		#endregion
	}
}