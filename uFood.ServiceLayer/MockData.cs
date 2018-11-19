using System.Collections.Generic;
using MongoDB.Bson;
using uFood.Infrastructure.Models.Environment;
using uFood.Infrastructure.Models.Food;
using uFood.Infrastructure.Models.Intolerance;
using uFood.Infrastructure.Models.Users;
using uFood.Infrastructure.OpenDataHub.Model;
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
		public static IEnumerable<Gastronomy> Gastronomies { get; set; }

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
					Name = "Gröstl",
					Ingredients = new List<Ingredient>
					{
						new Ingredient
						{
							Nutrient = new Nutrient
							{
								Name = "Potatoes",
								Description = "Local Potatoes from val Pusteria"
							},
							Quantity = 200
						},
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
								Name = "Beef"
							},
							Quantity = 2
						},
						new Ingredient
						{
							Nutrient = new Nutrient
							{
								Name = "Onion",
							},
							Quantity = 1
						},
						new Ingredient
						{
							Nutrient = new Nutrient
							{
								Name = "Butter",
							},
							Quantity = 1
						}
					}
				},
				new Dish
				{
					Name = "Hamburger",
					Ingredients = new List<Ingredient>
					{
						new Ingredient
						{
							Nutrient = new Nutrient
							{
								Name = "Beef",
								Description = "Local production"
							},
							Quantity = 12
						},
						new Ingredient
						{
							Nutrient = new Nutrient
							{
								Name = "Onion"
							},
							Quantity = 3
						},
						new Ingredient
						{
							Nutrient = new Nutrient
							{
								Name = "Ketchup"
							},
							Quantity = 3
						},
						new Ingredient
						{
							Nutrient = new Nutrient
							{
								Name = "Pickles"
							},
							Quantity = 3
						},
					}
				},
				new Dish
				{
					Name = "Noodle Soup",
					Ingredients = new List<Ingredient>
					{
						new Ingredient
						{
							Nutrient = new Nutrient
							{
								Name = "Flour"
							},
							Quantity = 12
						},
						new Ingredient
						{
							Nutrient = new Nutrient
							{
								Name = "Spices"
							},
							Quantity = 3
						}
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

		public static void GenerateGastronomies()
		{
			Gastronomies = new List<Gastronomy>
			{
				new Gastronomy
				{
					ForeignID = "GASTROA2E20988C4B211D19C5D006097AF193B",
					Dishes = new List<ObjectId>
					{
						new ObjectId("5bef912b6eb56c5b401145ca"),
						new ObjectId("5bef912b6eb56c5b401145c9"),
					}
				},
				new Gastronomy
				{
					ForeignID = "GASTRO040182FB3AA0464894CCC1EA7D71EB3A",
					Dishes = new List<ObjectId>
					{
						new ObjectId("5bef912b6eb56c5b401145c8"),
						new ObjectId("5bef912b6eb56c5b401145c9"),
					}
				},
				new Gastronomy
				{
					ForeignID = "GASTRO0DDC0946F7B1211C5D90CF446BA9D1D5",
					Dishes = new List<ObjectId>
					{
						new ObjectId("5bef912b6eb56c5b401145c8"),
						new ObjectId("5bef912b6eb56c5b401145ca"),
						new ObjectId("5bef912b6eb56c5b401145c9"),
					}
				},
			};
		}

		public static void GenerateMockData()
		{
			GenerateFarms();
			GenerateDishes();
			GenerateIntolerances();
			GenerateUser();
			GenerateGastronomies();
		}

		#endregion
	}
}