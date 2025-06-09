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
    public class CreateService
    {
        public void AddEmployee(Employee emp)
        {
            var validationResults = new List<ValidationResult>();
            var context = new ValidationContext(emp, null, null);

            if (!Validator.TryValidateObject(emp, context, validationResults, true))
            {
                foreach (var error in validationResults)
                    Console.WriteLine($"Validation Error: {error.ErrorMessage}");
                return;
            }

            using var db = new AppDbContext();
            db.Employees.Add(emp);
            db.SaveChanges();
            Console.WriteLine("Employee added successfully.");
        }
    }
}
