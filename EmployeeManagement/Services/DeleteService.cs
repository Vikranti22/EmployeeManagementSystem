using EmployeeManagement.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagement.Services
{
    //service to handle delete operation
    public class DeleteService
    {
        //method for delete employee
        public void DeleteEmployee(int id)
        {
            using var db = new AppDbContext();
            var emp = db.Employees.Find(id);
            if (emp == null)
            {
                Console.WriteLine("Employee not found.");
                return;
            }

            db.Employees.Remove(emp);
            db.SaveChanges();
            Console.WriteLine("Employee deleted.");
        }
    }
}
