using System;
using System.Text.Json.Serialization;

namespace CleaningService.Models
{
	public class Admin : IUser
	{
        public int id { get ; set ; }
        public string userName { get; set; } = string.Empty;
        public string credential { get ; set ; } = string.Empty;
        public string firstName { get ; set ; } = string.Empty;
        public string middleName { get ; set ; } = string.Empty;
        public string lastName { get ; set ; } = string.Empty;
        public string phoneNumber { get ; set ; } = string.Empty;
        public string streetAddress { get ; set ; } = string.Empty;
        public string city { get ; set ; } = string.Empty;
        public string state { get ; set ; } = string.Empty;
        public string zip { get ; set ; } = string.Empty;

        [JsonConverter(typeof(JsonStringEnumConverter))]
        public AdminState status { get; set; } = AdminState.Unavailable;

        public List<Request> requests { get; set; } = new List<Request>();

    }
}

