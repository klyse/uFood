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

			MockData.GenerateMockData(this);
			Farmers.InsertMany(MockData.Farmers);
			Dishes.InsertMany(MockData.Dishes);
		}

		#region Getters

		public Farmer GetFarmersById(string id)
		{
			return Farmers.Find(c => c.ID.Equals(id.GetObjectId())).FirstOrDefault();
		}

		public Dish GetDishById(string id)
		{
			return Dishes.Find(c => c.ID.Equals(id.GetObjectId())).FirstOrDefault();
		}

        public NutrientCheckResult CheckNutrient(string name)
        {
            NutrientCheckResult check = new NutrientCheckResult();

            return check;
        }

		#endregion
	}
}