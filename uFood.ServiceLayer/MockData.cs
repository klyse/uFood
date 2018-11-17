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
		public static IEnumerable<Recipe> Recipes { get; set; }

		#endregion

		#region MockGeneration

		private static void GenerateRecipe()
		{
			Recipes = new List<Recipe>
			{
				new Recipe
				{
					Name = "Penne All'Amatriciana",
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
				new Recipe
				{
					Name = "Spaghetti Carbonara",
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

		public static void GenerateMockData()
		{
			GenerateRecipe();
		}

		#endregion
	}
}