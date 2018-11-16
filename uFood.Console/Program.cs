using uFood.ServiceLayer.MongoDB;

namespace uFood.Console
{
	class Program
	{
		static void Main(string[] args)
		{
			System.Console.WriteLine("Hello World!");

			new MongoRepository().ConnectToMongo();

			System.Console.ReadLine();
		}
	}
}