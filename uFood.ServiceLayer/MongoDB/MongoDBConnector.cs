using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Extensions.Options;
using MongoDB.Bson;
using MongoDB.Driver;
using uFood.Infrastructure.Configuration;
using uFood.Infrastructure.Models.Environment;
using uFood.Infrastructure.Models.Food;
using uFood.Infrastructure.Models.Intolerance;
using uFood.Infrastructure.Models.Messages;
using uFood.Infrastructure.Models.Users;
using uFood.Infrastructure.OpenDataHub.Model;

namespace uFood.ServiceLayer.MongoDB
{
	public class MongoDBConnector
	{
		private readonly IMongoDatabase _database;

		private const string DishesCollection = "Dishes";
		private const string FarmersCollection = "Farmers";
		private const string IntolerancesCollection = "Intolerances";
		private const string UsersCollection = "Users";
		private const string GastronomiesCollection = "Gastronomies";

		private IMongoCollection<Farmer> Farmers => _database.GetCollection<Farmer>(FarmersCollection);
		private IMongoCollection<Dish> Dishes => _database.GetCollection<Dish>(DishesCollection);
		private IMongoCollection<Intolerance> Intolerances => _database.GetCollection<Intolerance>(IntolerancesCollection);
		private IMongoCollection<User> Users => _database.GetCollection<User>(UsersCollection);
		private IMongoCollection<Gastronomy> Gastronomies => _database.GetCollection<Gastronomy>(GastronomiesCollection);

		public MongoDBConnector(IOptions<MongoDBConfiguration> configuration)
		{
			var connectionString = configuration.Value.ConnectionString;
			var client = new MongoClient(connectionString);

			_database = client.GetDatabase("ufood");
		}

		#region Getters

		public void GenerateMock()
		{
			MockData.GenerateMockData();
			//Farmers.InsertMany(MockData.Farmers);
			//Dishes.InsertMany(MockData.Dishes);
			//Intolerances.InsertMany(MockData.Intolerances);
			//Users.InsertMany(MockData.Users);
			//Gastronomies.InsertMany(MockData.Gastronomies);
		}

		/// <summary>
		/// Get Farmers by ID
		/// </summary>
		public Farmer GetFarmersById(string id)
		{
			return Farmers.Find(c => c.ID.Equals(id.GetObjectId())).FirstOrDefault();
		}

		/// <summary>
		/// Get farmers by name
		/// </summary>
		public IEnumerable<Farmer> GetFarmersByNutrition(string name)
		{
			return Farmers.Find(c => c.ProducesNutrients.Any(g => g.ToLowerInvariant() == name.ToLowerInvariant())).ToList();
		}

		/// <summary>
		/// Get Dish by ID
		/// </summary>
		public Dish GetDishById(string id)
		{
			return Dishes.Find(c => c.ID.Equals(id.GetObjectId())).FirstOrDefault();
		}

		/// <summary>
		/// Get Gastronomy by ID
		/// </summary>
		public Gastronomy GetGastronomyById(string id)
		{
			return Gastronomies.Find(c => c.ID.Equals(id.GetObjectId())).FirstOrDefault();
		}

		/// <summary>
		/// Queries the database for dishes that contain a specific nutrient
		/// </summary>
		public IEnumerable<Dish> GetDishesByNutrient(string nutrient)
		{
			return Dishes.Find(c => c.Ingredients.Any(r => r.Nutrient.Name.ToLowerInvariant() == nutrient.ToLowerInvariant())).ToList();
		}

		/// <summary>
		/// Queries database and selects only dishes which do not interfere with possible intolerances
		/// </summary>
		/// <param name="userId"></param>
		/// <param name="nutrient"></param>
		/// <returns></returns>
		public IEnumerable<Dish> GetDishesByNutrient(string userId, string nutrient)
		{
			var user = Users.Find(c => c.ID.Equals(userId.GetObjectId())).FirstOrDefault();

			// select all intolerances
			var intolerances = Intolerances.AsQueryable().ToList()
										   .Where(c => user.Intolerances?.Any(r => r.Equals(c.ID)) ?? false)
										   .SelectMany(c => c.EvilNutrients)
										   .ToList();

			// select all dishes containing the given nutrient
			var potentialDishes = GetDishesByNutrient(nutrient);

			// remove all dishes which are excluded by diary
			var possibleDishes = potentialDishes.Where(c => c.Ingredients.All(r => !intolerances.Contains(r.Nutrient.Name)));


			return possibleDishes;
		}

		/// <summary>
		/// Queries the database and returns list of restaurants that offer a given dish by id
		/// </summary>
		public IEnumerable<Gastronomy> GetGastronomiesByDishId(string dishId)
		{
			var gastronomies = Gastronomies.AsQueryable()
										   .ToList()
										   .Where(c => c.Dishes.Any(g => g.Equals(dishId.GetObjectId())))
										   .ToList();
			return gastronomies;
		}

		/// <summary>
		/// Queries database and returns any complications with the given nutrient
		/// </summary>
		/// <param name="name">Nutrient name</param>
		/// <returns>Returns object containing any complications about the nutrient</returns>
		public NutrientCheckResult CheckNutrient(string name)
		{
			var check = new NutrientCheckResult();

			var res = Intolerances.Find(c => c.EvilNutrients.Any(g => g.ToLowerInvariant() == name.ToLowerInvariant())).ToList();

			if (res.Any())
			{
				check.IsEvilForYou = true;
				check.Message = $"{name} should no be consumed because: ";
				foreach (var intolerance in res)
				{
					check.Message += intolerance.Name + " ";
				}

                check.AlternativeNutrient = "egg, potato";
            }
			else
			{
				check.IsEvilForYou = false;
				check.Message = "No complications found.";
			}

			check.Message = check.Message.Trim();
			return check;
		}

		/// <summary>
		/// Queries against the database and checks if any complications between the user and the nutrient can be found
		/// </summary>
		/// <param name="userID">UserID</param>
		/// <param name="name">Nutrient name</param>
		/// <returns>Returns object containing inforation whether nutrient can be consumed or not</returns>
		public NutrientCheckResult CheckNutrient(string userID, string name)
		{
			var check = new NutrientCheckResult();

			var user = Users.Find(c => c.ID == userID.GetObjectId()).FirstOrDefault();
			var intolerances = Intolerances.Find(c => user.Intolerances.Any(r => r == c.ID)).ToList();

			if (intolerances.Any())
			{
				check.IsEvilForYou = true;
				check.Message = $"{name} should no be consumed because: ";
				foreach (var intolerance in intolerances)
				{
					check.Message += intolerance.Name + " ";
				}

                check.AlternativeNutrient = "egg, potato";
			}
			else
			{
				check.IsEvilForYou = false;
				check.Message = "No complications found.";
			}

			return check;
		}

		#endregion
	}
}