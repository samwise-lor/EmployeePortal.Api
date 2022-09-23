using Microsoft.EntityFrameworkCore;

namespace EmployeePortal.Api.DataModels
{
    public class EmployeeContext : DbContext
    {
        public EmployeeContext(DbContextOptions<EmployeeContext> options) : base(options)
        {
        }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employee>()
                .HasOne<Address>(s => s.Address)
                .WithOne(ad => ad.Employee)
                .HasForeignKey<Address>(ad => ad.EmployeeId);
        }

        public DbSet<Employee> Employee { get; set; }
        public DbSet<Address> Address { get; set; }
    }
}
