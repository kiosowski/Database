using P02_DatabaseFirst.Data.Models;
using System;
using System.Globalization;
using System.IO;
using System.Linq;

namespace _07.EmployeesAndProjects
{
    class StartUp
    {
        static void Main(string[] args)
        {
            using(var db = new SoftUniContext())
            {
                var employees = db.Employees
                    .Where(e => e.EmployeesProjects.Any(ep => ep.Project.StartDate.Year >= 2001 &&
                      ep.Project.StartDate.Year <= 20013))
                    .Take(30)
                    .Select(e => new
                    {
                        EmployeeName = $"{e.FirstName} {e.LastName}",
                        ManagerName = $"{e.Manager.FirstName} {e.Manager.LastName}",
                        Projects = e.EmployeesProjects.Select(ep => new
                        {
                            ep.Project.Name,
                            ep.Project.StartDate,
                            ep.Project.EndDate
                        })
                    })
                    .ToList();

                using(StreamWriter Writer = new StreamWriter(@"..\..\..\result.txt"))
                {
                    foreach (var emp in employees)
                    {
                        Writer.WriteLine($"{emp.EmployeeName} - Manager: {emp.ManagerName}");
                        foreach (var proj in emp.Projects)
                        {
                            string startDate = proj.StartDate.ToString("M/d/yyyy h:mm:ss tt", CultureInfo.InvariantCulture);
                            string endDate = proj.EndDate == null ? "not finished" : proj.EndDate.Value.ToString("M/d/yyyy h:mm:ss tt", CultureInfo.InvariantCulture);

                            Writer.WriteLine($"--{proj.Name} - {startDate} - {endDate}");
                        }
                    }
                }
            }
        }
    }
}
