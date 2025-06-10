using EmployeeManagement.Data;
using EmployeeManagement.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagement.Services
{
    // Service class to handle update operations for Employee
    public class UpdateService
    {
        // Method to update an existing employee by ID
        public void UpdateEmployee(int id, Employee updated)
        {
            using var db = new AppDbContext();
            var emp = db.Employees.Find(id);

            // If employee not found, display a message and exit
            if (emp == null)
            {
                Console.WriteLine("Employee not found.");
                return;
            }

            // Update employee properties with new values
            emp.Name = updated.Name;
            emp.Age = updated.Age;
            emp.Email = updated.Email;

            var context = new ValidationContext(emp, null, null);
            var results = new List<ValidationResult>();

            if (!Validator.TryValidateObject(emp, context, results, true))
            {
                // Display all validation errors
                foreach (var error in results)
                    Console.WriteLine($"Validation Error: {error.ErrorMessage}");
                return;
            }

            db.SaveChanges();
            Console.WriteLine("Employee updated.");
        }
    }
}
