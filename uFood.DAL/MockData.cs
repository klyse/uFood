using System.Collections.Generic;
using uFood.Infrastructure.ModelExtensions;
using uFood.Infrastructure.Models.Food;
using uFood.Infrastructure.OpenDataHub.Model;

namespace uFood.DAL
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
						ID = "Flour",
						Name = "Flour",
						Description = "Made out of wheat"
					},
					new Nutrient
					{
						ID = "Milk",
						Name = "Milk",
						Description = "From a cow"
					},
					new Nutrient
					{
						ID = "Wheat",
						Name = "Wheat",
					},
					new Nutrient
					{
						ID = "Egg",
						Name = "Egg",
						Description = "Chicken egg"
					},
					new Nutrient
					{
						ID = "Tomato",
						Name = "Tomato"
					},
					new Nutrient
					{
						ID = "Parmigiano",
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
					new Dish
					{
						ID = "PenneAmatriciana",
						Name = "Penne All'Amatriciana",
						Description = "Italian pasta with Arrabaiata souce",
						Recipe = new Recipe
						{
							ID = "PenneAmatriciana",
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
			Gastronomies.GastronomyList = new List<Gastronomy>
			{
				new Gastronomy
				{
					ID = "2141jd",
					ForeignID = "asf42",
					Dishes = new List<Dish>
					{
						new Dish
						{
							ID = "fjksl",
							Description = "Some Noodles",
							Name = "Pasta Amatriciana",
							Recipe = new Recipe
							{
								ID = "jfka",
								Name = "Pasta Amatriciana",
								Ingredients = new List<Ingredient>
								{
									new Ingredient
									{
										Nutrient = "Flour",
										Quantity = 100
									}
								}
							}
						}
					}
				}
			};
		}

		#endregion
	}
}