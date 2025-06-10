using EmployeeManagement.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagement.Services
{
   // Service class to handle read operations for Employee
    public class ReadService
    {
        public void ListEmployees()
        {
            using var db = new AppDbContext();
            var employees = db.Employees.ToList();

            // Check if the list is empty
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
