using Newtonsoft.Json;

namespace uFood.Infrastructure.Configuration
{
	public class LichtBildConfiguration
	{
		[JsonProperty(PropertyName = "ospenDataEndpoint")]

		public string OpenDataEndpoint { get; set; }
	}
}