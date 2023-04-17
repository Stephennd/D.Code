using System;
namespace CleaningService.Models
{
	public interface IUser
	{
		public int id { get; set; }

		public string userName { get; set; }
		public string credential { get; set; }

		public string firstName { get; set; }
		public string middleName { get; set; } 
		public string lastName { get; set; }


    }
}

