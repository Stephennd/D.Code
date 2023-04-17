using System;
using System.ComponentModel.DataAnnotations;

namespace CleaningService.Models
{
	public class Service
	{
		public int id { get; set; }
		public List<ServiceArea> areas { get; set; } = new List<ServiceArea>();
		public string name { get; set; } = string.Empty;
		public string description { get; set; } = string.Empty;
		public double price { get; set; } = 0.0;
	}
}

