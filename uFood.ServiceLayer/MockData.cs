using System.Collections.Generic;
using MongoDB.Bson;
using uFood.Infrastructure.ModelExtensions;
using uFood.Infrastructure.Models.Food;
using uFood.Infrastructure.OpenDataHub.Model;

namespace uFood.ServiceLayer
{
	public static class MockData
	{
		#region Public Properties

		public static Gastronomies Gastronomies { get; set; } = new Gastronomies();
		public static Dishes Dishes { get; set; }
		public static Ingredients Ingredients { get; set; }
		public static Nutrients Nutrients { get; set; }

		#endregion

		#region MockGeneration

		private static void GenerateNutrients()
		{
			Nutrients = new Nutrients
			{
				NutrientsList = new List<Nutrient>
				{
					new Nutrient
					{
						ID = new ObjectId("Flour"),
						Name = "Flour",
						Description = "Made out of wheat"
					},
					new Nutrient
					{
						ID = new ObjectId("Milk"),
						Name = "Milk",
						Description = "From a cow"
					},
					new Nutrient
					{
						ID = new ObjectId("Wheat"),
						Name = "Wheat",
					},
					new Nutrient
					{
						ID = new ObjectId("Egg"),
						Name = "Egg",
						Description = "Chicken egg"
					},
					new Nutrient
					{
						ID = new ObjectId("Tomato"),
						Name = "Tomato"
					},
					new Nutrient
					{
						ID = new ObjectId("Parmigiano"),
						Name = "Parmigiano",
						Description = "Italian Parmigiano"
					}
				}
			};
		}

		private static void GenerateDishes()
		{
			Dishes = new Dishes
			{
				DishList = new List<Dish>
				{
					// Penne Amatriciana
					new Dish
					{
						ID = new ObjectId("PenneAmatriciana"),
						Name = "Penne All'Amatriciana",
						Description = "Italian pasta with Arrabaiata souce",
						Recipe = new Recipe
						{
							ID = new ObjectId("PenneAmatriciana"),
							Name = "Penne All'Amatriciana",
							Ingredients = new List<Ingredient>
							{
								new Ingredient
								{
									Nutrient = Nutrients.GetNutrientByID("Flour"),
									Quantity = 200
								},
								new Ingredient
								{
									Nutrient = Nutrients.GetNutrientByID("Tomato"),
									Quantity = 2
								},
								new Ingredient
								{
									Nutrient = Nutrients.GetNutrientByID("Parmigiano"),
									Quantity = 3
								}
							}
						}
					}
				}
			};
		}

		public static void GenerateMockData()
		{
			GenerateNutrients();
			GenerateDishes();

			Gastronomies.GastronomyList = new List<Gastronomy>
			{
				new Gastronomy
				{
					ID = new ObjectId("Gastronomy1"),
					ForeignID = "jdk39",
					Dishes = new List<Dish>
					{
						Dishes.GetDishByID("PenneAmatriciana")
					}
				}
			};
		}

		#endregion
	}
}