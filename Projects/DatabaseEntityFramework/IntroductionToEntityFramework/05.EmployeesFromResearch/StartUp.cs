using P02_DatabaseFirst.Data.Models;
using System;
using System.IO;
using System.Linq;

namespace _05.EmployeesFromResearch
{
    class StartUp
    {
        static void Main(string[] args)
        {
            using (var db = new SoftUniContext())
            {
                var employees = db.Employees.Where(e => e.Department.Name == "Research and Development")
                    .OrderBy(e => e.Salary)
                    .ThenByDescending(e => e.FirstName)
                    .Select(e => new
                    {
                        e.FirstName,
                        e.LastName,
                        e.Department.Name,
                        e.Salary
                    })
                    .ToList();

                using (StreamWriter Writer = new StreamWriter(@"..\..\..\result.txt"))
                {
                    foreach (var e in employees)
                    {
                        Writer.WriteLine($"{e.FirstName} {e.LastName} from {e.Name} - ${e.Salary:F2}");
                    }
                }
            }
        }
    }
}
