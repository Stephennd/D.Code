using System;
using Microsoft.EntityFrameworkCore;

namespace CleaningService.Models
{
	public static class ModelBuilderExtension
	{
		public static void Seed(this ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<Service>().HasData(
				new Service() { id = 1, areas = new List<ServiceArea>(), name = "Sweeping", description = "Sweeping/Vacuming the entire space", price = 50.00 },
				new Service() { id = 2, areas = new List<ServiceArea>(), name = "Mopping", description = "Dry mopping with swiffer sweeper", price = 40.00 },
				new Service() { id = 3, areas = new List<ServiceArea>(), name = "Dish Washing", description = "Wash all dirty dishes visible in the kitchen", price = 30.0 },
				new Service() { id = 4, areas = new List<ServiceArea>(), name = "Clothes Washing", description = "Wash all dirty clothes visible near the washing machine", price = 30.0 }
			);

			modelBuilder.Entity<Admin>().HasData(
				new Admin()
				{
					id = 1,
					userName = "Stephennd86",
					credential = "pumpum",
					firstName = "Stephen",
					middleName = "Nathaniel",
					lastName = "Deleveaux",
					streetAddress = "215 Eads Street",
					city = "Chattanooga",
					state = "TN",
					status = AdminState.Unavailable,
					phoneNumber ="7705729985",
					zip = "37412"
				}
				) ;

			modelBuilder.Entity<SuperUser>().HasData(
				new SuperUser()
				{
					id = 1,
					userName = "super",
					credential = "password"
					
				}
				) ;
		}
	}
}

