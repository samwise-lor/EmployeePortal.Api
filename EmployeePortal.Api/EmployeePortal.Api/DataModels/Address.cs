using System;

namespace EmployeePortal.Api.DataModels
{
    public class Address
    {
        public Guid Id { get; set; }
        public string PhysicalAddress { get; set; }
        public string PostalAddress { get; set; }

        // Navigation Property
        public Guid EmployeeId { get; set; }
        public Employee Employee { get; set; }
    }
}