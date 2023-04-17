using System;
using System.Text.Json.Serialization;
namespace CleaningService.Models
{
	public class CustomerNote
	{
		public int id { get; set; }
		[JsonIgnore]
		public virtual Customer? customer { get; set; }
		public int customerId { get; set; }
		public DateTime dateTime { get; } = DateTime.Now;
		public string note { get; set; } = string.Empty;
	}
}

