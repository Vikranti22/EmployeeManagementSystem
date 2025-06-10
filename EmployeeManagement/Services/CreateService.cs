using EmployeeManagement.Data;
using EmployeeManagement.Models;
using System.ComponentModel.DataAnnotations;


namespace EmployeeManagement.Services
{
    // Service class to handle creation operations for Employee
    public class CreateService
    {
        // Method to add a new employee to the database
        public void AddEmployee(Employee emp)
        {
            var validationResults = new List<ValidationResult>();
            var context = new ValidationContext(emp, null, null);

            // Validate the employee object using data annotations
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
