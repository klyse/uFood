using System.Collections.Generic;
using MongoDB.Driver;
using uFood.Infrastructure.Models.Food;

namespace uFood.ServiceLayer.MongoDB
{
	public class MongoDBConnector
	{
		private readonly IMongoDatabase _database;

		private const string DishesCollection = "Dishes";
		private const string RecipesCollection = "Recipes";

		public MongoDBConnector()
		{
			// todo password is just there for the Hackathon - remove it later
			var connectionString = "mongodb://root:123456a@ds024748.mlab.com:24748/ufood";
			var client = new MongoClient(connectionString);

			_database = client.GetDatabase("ufood");

			MockData.GenerateMockData();
			_database.GetCollection<Recipe>(RecipesCollection).InsertMany(MockData.Recipes);
		}

		public IEnumerable<Recipe> GetRecipesByName(string name)
		{
			return _database.GetCollection<Recipe>(RecipesCollection).Find(c => c.Name == name).ToList();
		}
	}
}