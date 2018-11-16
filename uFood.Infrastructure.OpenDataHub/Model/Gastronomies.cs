using System.Collections.Generic;

namespace uFood.Infrastructure.OpenDataHub.Model
{
	public class Gastronomies
	{
		public IEnumerable<Gastronomy> GastronomyList { get; set; } = new List<Gastronomy>();
	}
}