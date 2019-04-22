using Microsoft.EntityFrameworkCore;
using PayrollLibrary;

namespace PayrollData
{
    public class PayrollContext : DbContext
    {
        public DbSet<Department> Departments { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Paycheck> Paychecks { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder); 
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string connection = "Server = (localdb)\\mssqllocaldb; Database = PayrollData; Trusted_Connection = True; ";
            optionsBuilder.UseSqlServer(connection); 
        }
    }
}
