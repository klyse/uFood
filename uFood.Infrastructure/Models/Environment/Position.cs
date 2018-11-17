namespace uFood.Infrastructure.Models.Environment
{
	public class Position
	{
		public Position()
		{
		}

		public Position(double latitude, double longitude)
		{
			Latitude = latitude;
			Longitude = longitude;
		}

		public double Latitude { get; set; }

		public double Longitude { get; set; }

		public double Altitude { get; set; }
	}
}