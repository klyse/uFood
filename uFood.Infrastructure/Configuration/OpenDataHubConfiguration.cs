using Newtonsoft.Json;

namespace uFood.Infrastructure.Configuration
{
	public class OpenDataHubConfiguration
	{
		[JsonProperty(PropertyName = "openDataEndpoint")]

		public string OpenDataEndpoint { get; set; }
	}
}