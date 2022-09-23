using System;

namespace EmployeePortal.Api.DomainModels
{
    public class Employee
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public long Mobile { get; set; }
        public int Age { get; set; }
    }
}