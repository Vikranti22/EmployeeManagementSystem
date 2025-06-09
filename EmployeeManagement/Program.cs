using EmployeeManagement.Data;
using EmployeeManagement.Models;
using EmployeeManagement.Services;

class Program
{
    static void Main()
    {
        using (var db = new AppDbContext())
        {
            db.Database.EnsureCreated();
        }

        var createService = new CreateService();
        var readService = new ReadService();
        var updateService = new UpdateService();
        var deleteService = new DeleteService();

        while (true)
        {
            Console.WriteLine("\n1. Add\n2. List\n3. Update\n4. Delete\n5. Exit");
            Console.Write("Choose: ");
            var choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    var emp = new Employee();
                    Console.Write("Name: "); emp.Name = Console.ReadLine();
                    Console.Write("Age: "); emp.Age = int.Parse(Console.ReadLine());
                    Console.Write("Email: "); emp.Email = Console.ReadLine();
                    createService.AddEmployee(emp);
                    break;

                case "2":
                    readService.ListEmployees();
                    break;

                case "3":
                    Console.Write("Enter ID to update: ");
                    if (!int.TryParse(Console.ReadLine(), out var uid))
                    {
                        Console.WriteLine("Invalid ID.");
                        break;
                    }

                    using (var db = new AppDbContext())
                    {
                        var existingEmp = db.Employees.Find(uid);
                        if (existingEmp == null)
                        {
                            Console.WriteLine("Employee not found.");
                            break;
                        }
                    }

                    var updated = new Employee();

                    Console.Write("Name: ");
                    updated.Name = Console.ReadLine();

                    Console.Write("Age: ");
                    if (!int.TryParse(Console.ReadLine(), out var age))
                    {
                        Console.WriteLine("Invalid age.");
                        break;
                    }
                    updated.Age = age;

                    Console.Write("Email: ");
                    updated.Email = Console.ReadLine();

                    updateService.UpdateEmployee(uid, updated);
                    break;

                case "4":
                    Console.Write("Enter ID to delete: ");
                    var did = int.Parse(Console.ReadLine());
                    deleteService.DeleteEmployee(did);
                    break;

                case "5":
                    return;

                default:
                    Console.WriteLine("Invalid option.");
                    break;
            }
        }
    }
}
