using System.Collections.Generic;
using Microsoft.Extensions.Options;
using MongoDB.Bson;
using MongoDB.Driver;
using uFood.Infrastructure.Configuration;
using uFood.Infrastructure.Models.Environment;
using uFood.Infrastructure.Models.Food;

namespace uFood.ServiceLayer.MongoDB
{
	public class MongoDBConnector
	{
		private readonly IOptions<MongoDBConfiguration> _configuration;
		private readonly IMongoDatabase _database;

		private const string DishesCollection = "Dishes";
		private const string RecipesCollection = "Recipes";
		private const string FarmersCollection = "Farmers";

		private IMongoCollection<Recipe> Recipes => _database.GetCollection<Recipe>(RecipesCollection);
		private IMongoCollection<Farmer> Farmers => _database.GetCollection<Farmer>(FarmersCollection);

		public MongoDBConnector(IOptions<MongoDBConfiguration> configuration)
		{
			_configuration = configuration;


			var connectionString = configuration.Value.ConnectionString;
			var client = new MongoClient(connectionString);

			_database = client.GetDatabase("ufood");

			MockData.GenerateMockData();
			Recipes.InsertMany(MockData.Recipes);
			Farmers.InsertMany(MockData.Farmers);
		}

		public IEnumerable<Recipe> GetRecipesByName(string name)
		{
			return Recipes.Find(c => c.Name == name).ToList();
		}

		public Farmer GetFarmersById(ObjectId id)
		{
			return Farmers.Find(c => c.ID.Equals(id)).FirstOrDefault();
		}
	}
}