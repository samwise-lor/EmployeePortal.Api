namespace EmployeePortal.Api.DomainModels
{
    public class UpdateEmployee
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public long Mobile { get; set; }
        public int Age { get; set; }
    }
}