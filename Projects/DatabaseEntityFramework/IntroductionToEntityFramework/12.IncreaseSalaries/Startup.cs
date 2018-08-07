using P02_DatabaseFirst.Data.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace _12.IncreaseSalaries
{
    class StartUp
    {
        static void Main(string[] args)
        {
            var departmentsSalariesToBeIncrease = new List<string>
            {
                "Engineering",
                "Tool Design",
                "Marketing",
                "Information Services"
            };

            using (SoftUniContext db = new SoftUniContext())
            {
                var employees = db.Employees
                    .Where(e => departmentsSalariesToBeIncrease.Contains(e.Department.Name))
                    .OrderBy(e => e.FirstName)
                    .ThenBy(e => e.LastName)
                    .ToList();
                employees.ForEach(e => e.Salary *= 1.12m);
                db.SaveChanges();

                using (StreamWriter Writer = new StreamWriter(@"..\..\..\result.txt"))
                {
                    foreach (var emp in employees)
                    {
                        Writer.WriteLine($"{emp.FirstName} {emp.LastName} (${emp.Salary:f2})");
                    }
                }
            }
        }
    }
}
