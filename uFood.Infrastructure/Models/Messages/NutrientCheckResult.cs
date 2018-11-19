namespace uFood.Infrastructure.Models.Messages
{
	public class NutrientCheckResult
	{
		public bool IsEvilForYou { get; set; }

		public string Message { get; set; }

		public string AlternativeNutrient { get; set; }
	}
}