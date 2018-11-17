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
					Name = "Tomato One",
					Contact = "Franz.Josef@gmail.com",
					Position = new Position(46.794421, 11.941683),
					ProducesNutrients = new List<string>
					{
						"Tomato",
						"Salami",
					}
				},
				new Farmer
				{
					Name = "Flour Heaven",
					Contact = "Paula12@gmail.com",
					Position = new Position(46.798900, 11.942383),
					ProducesNutrients = new List<string>
					{
						"Flour",
					}
				},
				new Farmer
				{
					Name = "Micheles Verdure",
					Contact = "m.Verdure@gmail.com",
					Position = new Position(46.896932, 11.446064),
					ProducesNutrients = new List<string>
					{
						"Potatoes",
						"Tomatoes",
						"Garlic",
					}
				},
				new Farmer
				{
					Name = "Diary Products",
					Contact = "diary@gmail.com",
					Position = new Position(46.521512, 11.361570),
					ProducesNutrients = new List<string>
					{
						"Cream",
						"Cheese",
					}
				},
				new Farmer
				{
					Name = "Fishers Friz",
					Contact = "fish@gmail.com",
					Position = new Position(46.497394, 11.317820),
					ProducesNutrients = new List<string>
					{
						"Fish",
					}
				},
			};
		}

		public static void GenerateDishes()
		{
			Dishes = new List<Dish>
			{
				new Dish
				{
					Name = "Spaghetti all'amatriciana",
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
								Name = "Salami",
								Description = "Salami"
							},
							Quantity = 1
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
								Name = "Eggs",
								Description = "Chicken eggs"
							},
							Quantity = 12
						},
						new Ingredient
						{
							Nutrient = new Nutrient
							{
								Name = "Cheese",
								Description = "Italian Parmigiano"
							},
							Quantity = 3
						},
						new Ingredient
						{
							Nutrient = new Nutrient
							{
								Name = "Bacon",
								Description = "Pork bacon"
							},
							Quantity = 3
						},
						new Ingredient
						{
							Nutrient = new Nutrient
							{
								Name = "Flour",
								Description = "Made out of wheat"
							},
							Quantity = 3
						},
						new Ingredient
						{
							Nutrient = new Nutrient
							{
								Name = "Cream",
								Description = "Milk"
							},
							Quantity = 1
						},
					}
				},
				new Dish
				{
					Name = "Spaghetti allo scoglio",
					Ingredients = new List<Ingredient>
					{
						new Ingredient
						{
							Nutrient = new Nutrient
							{
								Name = "Fish",
								Description = "Local fish"
							},
							Quantity = 12
						},
						new Ingredient
						{
							Nutrient = new Nutrient
							{
								Name = "Garlic",
								Description = "Garlic"
							},
							Quantity = 3
						},
						new Ingredient
						{
							Nutrient = new Nutrient
							{
								Name = "Flour",
								Description = "Made out of wheat"
							},
							Quantity = 3
						},
						new Ingredient
						{
							Nutrient = new Nutrient
							{
								Name = "Tomato",
							},
							Quantity = 1
						},
					}
				}
			};
		}

		public static void GenerateIntolerances()
		{
			Intolerances = new List<Intolerance>
			{
				new Intolerance
				{
					Name = "Dairy",
					Description = "Lactose intolerance is caused by a shortage of lactose enzymes, which causes an inability to digest lactose and results in digestive symptoms.",
					EvilNutrients = new List<string>
					{
						"Milk",
						"Cheese",
						"Yogurt"
					}
				},
				new Intolerance
				{
					Name = "Fish Allergy",
					Description =
						"While less common in the general population than other types of food allergies, an allergy to finned fish is a frequent cause of anaphylaxis, a potentially life-threatening allergic reaction that appears quickly, impairs breathing and can send the body into shock.",
					EvilNutrients = new List<string>
					{
						"Fish",
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
						new ObjectId("5bef912b6eb56c5b401145cb")
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
						new ObjectId("5bef912b6eb56c5b401145cb"),
						new ObjectId("5bef912b6eb56c5b401145cc")
					}
				}
			};
		}

		public static void GenerateMockData()
		{
			GenerateFarms();
			GenerateDishes();
			GenerateIntolerances();
			GenerateUser();
		}

		#endregion
	}
}