using MiniORM.App.Data;
using MiniORM.App.Data.Entities;
using System;
using System.Linq;

namespace MiniORM.App
{
    class StartUp
    {
        static void Main(string[] args)
        {
            var connectionString = @"Server=DESKTOP-OSBRO1S\SQLEXPRESS;Database=MiniORM;Integrated Security=True";
            var context = new SoftUniDbContext(connectionString);
            var gosho = new Employee
            {
                FirstName = "Gosho",
                LastName = "Inserted",
                DepartmentId = context.Departments.First().Id,
                IsEmployed = true,
            };
            context.Employees.Add(gosho);

            var employee = context.Employees.Last();
            employee.FirstName = "Modified";
            context.SaveChanges();
        }
    }
}
