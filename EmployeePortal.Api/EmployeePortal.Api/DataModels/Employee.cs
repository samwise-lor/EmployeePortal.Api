using System;

namespace EmployeePortal.Api.DataModels
{
    public class Employee
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public long Mobile { get; set; }
        public int Age { get; set; }
        
        public Address Address { get; set; }
    }
}
