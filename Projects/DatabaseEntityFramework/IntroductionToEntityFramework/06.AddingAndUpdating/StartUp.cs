using P02_DatabaseFirst.Data.Models;
using System;
using System.IO;
using System.Linq;

namespace _06.AddingAndUpdating
{
    class StartUp
    {
        static void Main(string[] args)
        {
            using (var db = new SoftUniContext())
            {
                var address = new Address();
                address.AddressText = "Vitoshka 15";
                address.TownId = 4;

                Employee employee = db.Employees.FirstOrDefault(e => e.LastName == "Nakov");
                employee.Address = address;

                db.SaveChanges();

                var employees = db.Employees
                    .OrderByDescending(e => e.AddressId)
                    .Take(10)
                    .Select(e => new
                    {
                        e.Address.AddressText
                    })
                    .ToList();

                using (StreamWriter Writer = new StreamWriter(@"..\..\..\result.txt"))
                {
                    foreach (var emp in employees)
                    {
                        Writer.WriteLine(emp.AddressText);
                    }
                }
            }
        }
    }
}
