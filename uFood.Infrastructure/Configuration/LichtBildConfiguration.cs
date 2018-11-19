using Newtonsoft.Json;

namespace uFood.Infrastructure.Configuration
{
	public class LichtBildConfiguration
	{
		[JsonProperty(PropertyName = "openDataEndpoint")]

		public string OpenDataEndpoint { get; set; }
	}
}