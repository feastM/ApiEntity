using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Users.API.Domain.Models;


namespace Users.API.Persistance.Context
{
    public class AppDbContext : DbContext
    {
        public DbSet<Employee> Employees { get; set; }
     
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Employee>().ToTable("Employees");
            builder.Entity<Employee>().HasKey(p => p.Id);
            builder.Entity<Employee>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<Employee>().Property(p => p.FirstName).IsRequired().HasMaxLength(60);
            builder.Entity<Employee>().Property(p => p.LastName).IsRequired().HasMaxLength(60);
            builder.Entity<Employee>().Property(p => p.Email).IsRequired().HasMaxLength(100);
            builder.Entity<Employee>().Property(p => p.DateOfBirth).IsRequired();
            builder.Entity<Employee>().Property(p => p.Description);

            builder.Entity<Employee>().HasData
            (
                
                new Employee
                {
                    Id = 100,
                    FirstName = "Alexandru",
                    LastName = "Miaun",
                    Email = "alexandru.miaun@email.com",
                    DateOfBirth = new DateTime(1997, 11, 28),
                    Description = ""
                },
                new Employee
                {
                    Id = 101,
                    FirstName = "Eric",
                    LastName = "Gutu",
                    Email = "eric.gutu@email.com",
                    DateOfBirth = new DateTime(1997, 10, 1),
                    Description = ""
                }


            );

            
        }
    }
}
