using System;
namespace CleaningService.Models
{
	public enum RequestStatus
	{
		New,
		Submitted,
		Approved,
		InProgress,
		Completed,
		Canceled,
		Denied
	}
}

