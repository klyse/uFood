using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace uFood.API.Models
{
	public class LocationDTO
	{
		public double? Latitude { get; set; }

		public double? Longitude { get; set; }

		public string Address { get; set; }

		public string ZIPCode { get; set; }

		public string City { get; set; }


		public LocationDTO()
		{
		}
	}
}