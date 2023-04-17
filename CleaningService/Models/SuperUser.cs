using System;
using System.Text.Json.Serialization;

namespace CleaningService.Models
{
	public class SuperUser:IUser
	{
        public int id { get; set; }
        public string userName { get; set; } = string.Empty;
        public string credential { get; set; } = string.Empty;

        [JsonIgnore]
        public string firstName { get; set; } = string.Empty;
        [JsonIgnore]
        public string middleName { get; set; } = string.Empty;
        [JsonIgnore]
        public string lastName { get; set; } = string.Empty;
    }
}

