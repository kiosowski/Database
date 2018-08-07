namespace Banicharnica.App.Core.Controllers
{
    using AutoMapper;
    using AutoMapper.QueryableExtensions;
    using Banicharnica.App.Core.Contracts;
    using Banicharnica.App.Core.Dtos;
    using Banicharnica.Data;
    using Banicharnica.Models;
    using System;
    using System.Linq;

    public class EmployeeController : IEmployeeController
    {
        private readonly BanicharnicaContext context;
        private readonly IMapper mapper;
        public EmployeeController(BanicharnicaContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }
        public void AddEmployee(EmployeeDto employeeDto)
        {
            var employee = mapper.Map<Employee>(employeeDto);

            this.context.Employees.Add(employee);

            this.context.SaveChanges();
        }

        public void SetAddress(int employeeId, string address)
        {
            var employee = context.Employees.Find(employeeId);

            if (employee == null)
            {
                throw new ArgumentException("Invalid Id");
            }
            employee.Address = address;

            this.context.SaveChanges();
        }

        public void SetBirthday(int employeeId, DateTime date)
        {
            var employee = context.Employees.Find(employeeId);

            if (employee == null)
            {
                throw new ArgumentException("Invalid Id");
            }
            employee.Birthday = date;

            this.context.SaveChanges();
        }

        public EmployeeDto GetEmployeInfo(int employeeId)
        {
            var employee = context.Employees
                             .Find(employeeId);

            var employeeDto = mapper.Map<EmployeeDto>(employee);
            if (employee == null)
            {
                throw new ArgumentException("Invalid Id");
            }

            return employeeDto;
        }

        public EmployeePersonalInfoDto GetEmployeePersonalInfo(int employeeId)
        {
            var employee = context.Employees
                            .Find(employeeId);

            var employeeDto = mapper.Map<EmployeePersonalInfoDto>(employee);
            if (employee == null)
            {
                throw new ArgumentException("Invalid Id");
            }

            return employeeDto;
        }
    }
}
