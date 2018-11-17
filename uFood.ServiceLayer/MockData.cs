using System.Collections.Generic;
using MongoDB.Bson;
using uFood.Infrastructure.ModelExtensions;
using uFood.Infrastructure.Models.Environment;
using uFood.Infrastructure.Models.Food;
using uFood.Infrastructure.OpenDataHub.Model;

namespace uFood.ServiceLayer
{
	public static class MockData
	{
		#region Public Properties

		public static IEnumerable<Recipe> Recipes { get; set; }
		public static IEnumerable<Farmer> Farmers { get; set; }

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

		public static void GenerateMockData()
		{
			GenerateRecipe();
			GenerateFarms();
		}

		#endregion
	}
}