using P02_DatabaseFirst.Data.Models;
using System;
using System.Globalization;
using System.IO;
using System.Linq;

namespace _11.FindLatest10Projects
{
    class StartUp
    {
        static void Main(string[] args)
        {
            using (var db = new SoftUniContext())
            {
                var projects = db.Projects
                    .OrderByDescending(p => p.StartDate)
                    .Take(10)
                    .Select(p => new
                    {
                        p.Name,
                        p.Description,
                        StartDate = p.StartDate.ToString("M/d/yyyy h:mm:ss tt", CultureInfo.InvariantCulture)
                    })
                    .ToList();
                using (StreamWriter Writer = new StreamWriter(@"..\..\..\result.txt"))
                {
                    foreach (var project in projects.OrderBy(p => p.Name))
                    {
                        Writer.WriteLine($"{project.Name}");
                        Writer.WriteLine($"{project.Description}");
                        Writer.WriteLine(project.StartDate);
                    }
                }
            }
        }
    }
}
