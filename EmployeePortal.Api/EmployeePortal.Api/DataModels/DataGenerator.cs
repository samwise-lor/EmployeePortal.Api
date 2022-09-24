using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace EmployeePortal.Api.DataModels
{
    public class DataGenerator
    {

        public static void Initialize(IServiceProvider serviceProvider)
        {
            using var context = new EmployeeContext(serviceProvider.GetRequiredService<DbContextOptions<EmployeeContext>>());
            if (context.Employee.Any())
            {
                return;   // Database has been seeded
            }

            context.Employee.AddRange(
                new Employee
                {
                    Id = Guid.NewGuid(),
                    FirstName = "Captain",
                    LastName = "America",
                    Age = 20,
                    Email = "captain.america@anywhere.com",
                    Mobile = 1234567890,
                    Address = new Address()
                    {
                        Id = Guid.NewGuid(),
                        PhysicalAddress = "123 Main St",
                        PostalAddress = "123 Main St"
                    }
                },
                new Employee
                {
                    Id = Guid.NewGuid(),
                    FirstName = "Iron",
                    LastName = "Man",
                    Age = 30,
                    Email = "iron.man@anywhere.com",
                    Mobile = 2345678901,
                    Address = new Address()
                    {
                        Id = Guid.NewGuid(),
                        PhysicalAddress = "123 Main St",
                        PostalAddress = "123 Main St"
                    }
                },
                new Employee
                {
                    Id = Guid.NewGuid(),
                    FirstName = "Black",
                    LastName = "Widow",
                    Age = 20,
                    Email = "black.widow@anywhere.com",
                    Mobile = 3456789012,
                    Address = new Address()
                    {
                        Id = Guid.NewGuid(),
                        PhysicalAddress = "123 Main St",
                        PostalAddress = "123 Main St"
                    }
                },
                new Employee
                {
                    Id = Guid.NewGuid(),
                    FirstName = "Winter",
                    LastName = "Solder",
                    Age = 25,
                    Email = "winter.solder@anywhere.com",
                    Mobile = 4567890123,
                    Address = new Address()
                    {
                        Id = Guid.NewGuid(),
                        PhysicalAddress = "123 Main St",
                        PostalAddress = "123 Main St"
                    }
                });

            context.SaveChanges();
        }
    }
}
