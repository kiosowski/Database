using P02_DatabaseFirst.Data.Models;
using System;
using System.IO;
using System.Linq;

namespace _04.EmployeesWithSalaryOver50000
{
    class StartUp
    {
        static void Main(string[] args)
        {
            using (var db = new SoftUniContext())
            {
                var employees = db.Employees.Select(e => new
                {
                    e.FirstName,
                    e.Salary
                }).Where(e => e.Salary > 50000)
                .OrderBy(e => e.FirstName);

                using (StreamWriter writer = new StreamWriter(@"..\..\..\result.txt"))
                {
                    foreach (var employee in employees)
                    {
                        writer.WriteLine($"{employee.FirstName}");
                    }
                }
            }
        }
    }
}