using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using CustomerApi.Domain.Entities;

namespace CustomerApi.Data.Database
{
    public class CustomerContext : DbContext
    {
        public CustomerContext()
        {

        }
        public DbSet<Customer> Customer { get; set; }
        public CustomerContext(DbContextOptions<CustomerContext> options):base(options)
        {
            //for in-memory database. not required for any normal database
            var customers = new[]
            {
                new Customer
                {
                    Id = Guid.Parse("9f35b48d-cb87-4783-bfdb-21e36012930a"),
                    FirstName = "Wolfgang",
                    LastName = "Ofner",
                    DateOfBirth = new DateTime(1989, 11, 23),
                    Age = 30
                },
                new Customer
                {
                    Id = Guid.Parse("654b7573-9501-436a-ad36-94c5696ac28f"),
                    FirstName = "Darth",
                    LastName = "Vader",
                    DateOfBirth = new DateTime(1977, 05, 25),
                    Age = 43
                },
                new Customer
                {
                    Id = Guid.Parse("971316e1-4966-4426-b1ea-a36c9dde1066"),
                    FirstName = "Son",
                    LastName = "Goku",
                    DateOfBirth = new DateTime(1937, 04, 16),
                    Age = 83
                }
            };

            Customer.AddRange(customers);
            SaveChanges();
        }

        

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "2.2.6-servicing-10079");

            modelBuilder.Entity<Customer>(entity =>
            {
                entity.Property(e => e.Id).HasDefaultValueSql("(newid())");

                entity.Property(e => e.DateOfBirth).HasColumnType("date");

                entity.Property(e => e.FirstName).IsRequired();

                entity.Property(e => e.LastName).IsRequired();
            });
        }
    }
}
