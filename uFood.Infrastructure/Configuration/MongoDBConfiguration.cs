using Newtonsoft.Json;

namespace uFood.Infrastructure.Configuration
{
	public class MongoDBConfiguration
	{
		[JsonProperty(PropertyName = "connectionString")]

		public string ConnectionString { get; set; }
	}
}