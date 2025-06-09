using EmployeeManagement.Models;
using Microsoft.EntityFrameworkCore;


namespace EmployeeManagement.Data
{
    public class AppDbContext : DbContext

    {
        public DbSet<Employee> Employees { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=DESKTOP-BFCROBP\\SQLSERVER2022;Database=EmployeeDb;User Id=sa;Password=root@1234;TrustServerCertificate=True;");

        }
    }
}
