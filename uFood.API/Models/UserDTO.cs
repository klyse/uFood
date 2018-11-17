using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace uFood.API.Models
{
	public class UserDTO
	{
		public string FirstName { get; set; }

		public string LastName { get; set; }

		public string UserID { get; set; }


		public UserDTO()
		{
		}
	}
}