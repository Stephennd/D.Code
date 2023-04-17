using System;
using System.Text.Json.Serialization;

namespace CleaningService.Models
{
	public class Request
	{
		public int id { get; set; }

		public Admin? admin { get; set; }
		public Customer? customer { get; set; }

		public List<Service>? Services { get; set; }
		public double price => Services is null ? 0.0 : Services.Sum(x => x.price);

        [JsonConverter(typeof(JsonStringEnumConverter))]
        public RequestStatus status { get; set; } = RequestStatus.New;
		
		public string comments { get; set; } = string.Empty;

	}
}

