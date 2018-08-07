using P02_DatabaseFirst.Data.Models;
using System;
using System.IO;
using System.Linq;

namespace _08.AddressesByTown
{
    class StartUp
    {
        static void Main(string[] args)
        {
            using(var db = new SoftUniContext())
            {
                var addresses = db.Addresses
                        .OrderByDescending(a => a.Employees.Count)
                        .ThenBy(a => a.Town.Name)
                        .ThenBy(a => a.AddressText)
                        .Take(10)
                        .Select(a => new
                        {
                            AddressText = a.AddressText,
                            TownName = a.Town.Name,
                            EmployeeCount = a.Employees.Count
                        })
                        .ToList();
                using (StreamWriter Writer = new StreamWriter(@"..\..\..\result.txt"))
                {
                    foreach (var address in addresses)
                    {
                        Writer.WriteLine($"{address.AddressText}, {address.TownName} - {address.EmployeeCount} employees");
                    }
                }
            }
        }
    }
}
