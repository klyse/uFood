using MongoDB.Driver;
using uFood.Infrastructure.Models.Food;
using uFood.Infrastructure.ModelExtensions;

namespace uFood.ServiceLayer.MongoDB
{
	public class MongoRepository
	{
		public void ConnectToMongo()
		{
			MockData.GenerateMockData();

			// password is just for the Hackathon - remove it later
			var connectionString = "mongodb://root:123456a@ds024748.mlab.com:24748/ufood";
			var client = new MongoClient(connectionString);

			var enumerable = client.GetDatabase("ufood");

			var mongoCollection = enumerable.GetCollection<Recipe>("Recipes");

			mongoCollection.InsertMany(MockData.Recipes.RecipeList);

			var findFluent = mongoCollection.Find(c => c.Name == "Penne All'Amatriciana").First();
		}	
	}
}