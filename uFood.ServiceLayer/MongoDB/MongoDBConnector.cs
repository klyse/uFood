using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Extensions.Options;
using MongoDB.Bson;
using MongoDB.Driver;
using uFood.Infrastructure.Configuration;
using uFood.Infrastructure.Models.Environment;
using uFood.Infrastructure.Models.Food;
using uFood.Infrastructure.Models.Messages;

namespace uFood.ServiceLayer.MongoDB
{
	public class MongoDBConnector
	{
		private readonly IMongoDatabase _database;

		private const string DishesCollection = "Dishes";
		private const string FarmersCollection = "Farmers";

		private IMongoCollection<Farmer> Farmers => _database.GetCollection<Farmer>(FarmersCollection);
		private IMongoCollection<Dish> Dishes => _database.GetCollection<Dish>(DishesCollection);

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
			Farmers.InsertMany(MockData.Farmers);
			Dishes.InsertMany(MockData.Dishes);
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
			return Dishes.Find(c => c.Ingredients.Any(r =>r.Nutrient.Name.ToLowerInvariant() == nutrient.ToLowerInvariant())).ToList();
		}

        public NutrientCheckResult CheckNutrient(string name)
        {
            NutrientCheckResult check = new NutrientCheckResult();

            // TODO, now is just a fake logic
            if (name.ToLower() == "salat")
            {
                check.IsEvilForYou = true;
                check.Message = "you eat it 4 times this week!";
                check.AlternativeNutrient = new Nutrient() { Name = "Salami" };
            }
            else
            {
                check.IsEvilForYou = false;
            }

            return check;
        }

		#endregion
	}
}