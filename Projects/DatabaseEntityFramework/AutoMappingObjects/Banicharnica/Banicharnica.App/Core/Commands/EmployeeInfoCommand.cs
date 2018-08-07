
namespace Banicharnica.App.Core.Commands
{
    using Banicharnica.App.Core.Contracts;
    using System;

    public class EmployeeInfoCommand : ICommand
    {
        private readonly IEmployeeController employeeController;
        public EmployeeInfoCommand(IEmployeeController employeeController)
        {
            this.employeeController = employeeController;
        }
        public string Execute(string[] args)
        {
            int id = int.Parse(args[0]);

            var employeeDto = this.employeeController.GetEmployeInfo(id);

            return $"ID: {employeeDto.Id} - {employeeDto.FirstName} {employeeDto.LastName} - ${employeeDto.Salary:f2}";
        }
    }
}
