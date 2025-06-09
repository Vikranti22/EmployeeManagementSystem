using EmployeeManagement.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagement.Services
{
    public class ReadService
    {
        public void ListEmployees()
        {
            using var db = new AppDbContext();
            var employees = db.Employees.ToList();

            if (!employees.Any())
            {
                Console.WriteLine("No employees found.");
                return;
            }

            foreach (var e in employees)
                Console.WriteLine($"ID: {e.Id}, Name: {e.Name}, Age: {e.Age}, Email: {e.Email}");
        }
    }
}
