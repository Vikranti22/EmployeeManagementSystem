using EmployeeManagement.Models;
using Microsoft.EntityFrameworkCore;


namespace EmployeeManagement.Data
{
    // Database context class for Entity Framework Core
    public class AppDbContext : DbContext

    {
        public DbSet<Employee> Employees { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // Configures the database connection string
            optionsBuilder.UseSqlServer("Server=DESKTOP-BFCROBP\\SQLSERVER2022;Database=EmployeeDb;User Id=sa;Password=root@1234;TrustServerCertificate=True;");

        }
    }
}
