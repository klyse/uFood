﻿using System.Collections.Generic;
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
						Name = "Flour",
						Description = "Made out of wheat"
					},
					new Nutrient
					{
						Name = "Milk",
						Description = "From a cow"
					},
					new Nutrient
					{
						Name = "Wheat",
					},
					new Nutrient
					{
						Name = "Egg",
						Description = "Chicken egg"
					},
					new Nutrient
					{
						Name = "Tomato"
					},
					new Nutrient
					{
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
			return;
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