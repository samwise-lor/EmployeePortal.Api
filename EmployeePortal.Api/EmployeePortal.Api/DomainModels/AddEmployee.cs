namespace EmployeePortal.Api.DomainModels
{
    public class AddEmployee
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public long Mobile { get; set; }
        public int Age { get; set; }
        
        public string PhysicalAddress { get; set; }
        public string PostalAddress { get; set; }
    }
}