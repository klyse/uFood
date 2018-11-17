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
using uFood.Infrastructure.Models.User;

namespace uFood.ServiceLayer.MongoDB
{
	public class MongoDBConnector
	{
		private readonly IMongoDatabase _database;

		private const string DishesCollection = "Dishes";
		private const string FarmersCollection = "Farmers";
		private const string IntolerancesCollection = "Intolerances";
		private const string UsersCollection = "Users";

		private IMongoCollection<Farmer> Farmers => _database.GetCollection<Farmer>(FarmersCollection);
		private IMongoCollection<Dish> Dishes => _database.GetCollection<Dish>(DishesCollection);
		private IMongoCollection<Intolerance> Intolerances => _database.GetCollection<Intolerance>(IntolerancesCollection);
		private IMongoCollection<User> Users => _database.GetCollection<User>(UsersCollection);

		public MongoDBConnector(IOptions<MongoDBConfiguration> configuration)
		{
			var connectionString = configuration.Value.ConnectionString;
			var client = new MongoClient(connectionString);

			_database = client.GetDatabase("ufood");
		}

		#region Getters

		public void GenerateMock()
		{
			MockData.GenerateMockData(this);
			//Farmers.InsertMany(MockData.Farmers);
			//Dishes.InsertMany(MockData.Dishes);
			//Intolerances.InsertMany(MockData.Intolerances);
			//Users.InsertMany(MockData.Users);
		}

		public Farmer GetFarmersById(string id)
		{
			return Farmers.Find(c => c.ID.Equals(id.GetObjectId())).FirstOrDefault();
		}

		public Dish GetDishById(string id)
		{
			return Dishes.Find(c => c.ID.Equals(id.GetObjectId())).FirstOrDefault();
		}

		public IEnumerable<Dish> GetDishesByNutrient(string nutrient)
		{
			return Dishes.Find(c => c.Ingredients.Any(r => r.Nutrient.Name.ToLowerInvariant() == nutrient.ToLowerInvariant())).ToList();
		}

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
			}
			else
			{
				check.IsEvilForYou = false;
				check.Message = "No complications found.";
			}

			check.Message = check.Message.Trim();
			return check;
		}

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