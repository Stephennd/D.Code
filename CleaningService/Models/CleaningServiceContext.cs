using System;
using System.Linq;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace CleaningService.Models
{
	public class CleaningServiceContext: DbContext
	{
        // Users
        public DbSet<Admin> Admins { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<SuperUser> SuperUsers { get; set; }

        // Services
        public DbSet<Service> Services { get; set; }
        public DbSet<Request> Requests { get; set; }

        // Other
        public DbSet<CustomerNote> CustomerNotes { get; set; }

        // Enums
        public List<string> ServiceAreas { get; } = Enum.GetNames(typeof(ServiceArea)).ToList<string>();
        public List<string> RequestStatuses { get; } = Enum.GetNames(typeof(RequestStatus)).ToList<string>();
        public List<string> AdminStates { get; } = Enum.GetNames(typeof(AdminState)).ToList<string>();

        public CleaningServiceContext(DbContextOptions<CleaningServiceContext> options):base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Admin>()
                .HasMany(c => c.requests)
                .WithOne(a => a.admin);

            modelBuilder.Entity<Admin>()
                .HasKey(c => c.id);

            modelBuilder.Entity<Customer>()
                .HasMany(c => c.requests)
                .WithOne(a => a.customer);

            modelBuilder.Entity<Customer>()
                .HasMany(c => c.CustomerNotes)
                .WithOne(a => a.customer);

            modelBuilder.Entity<Request>()
                .HasMany(c => c.Services);

            modelBuilder.Entity<List<ServiceArea>>()
                .HasNoKey();

            modelBuilder.Entity<Service>()
                .HasKey(x => x.id);
                
            modelBuilder.Entity<Service>()
                .Property(c => c.areas)
                .HasConversion(
                    v => string.Join(',', v.Select(i => i.ToString())),
                    v => v.Split(',',StringSplitOptions.TrimEntries|StringSplitOptions.RemoveEmptyEntries ).Select(i => (ServiceArea)Enum.Parse(typeof(ServiceArea), i)).ToList<ServiceArea>());

            modelBuilder.Seed();
        }
    }
}

