using AutoMapper.QueryableExtensions;
using Banicharnica.App.Core.Contracts;
using Banicharnica.App.Core.Dtos;
using Banicharnica.Data;
using System;                 
using System.Linq; 
using Microsoft.EntityFrameworkCore;
using AutoMapper;

namespace Banicharnica.App.Core.Controllers
{
    public class ManagerController : IManagerController
    {
        private readonly BanicharnicaContext context;
        private readonly IMapper _mapper;
        public ManagerController(BanicharnicaContext context, IMapper mapper)
        {
            this.context = context;
            this._mapper = mapper;
        }
        public ManagerDto GetManagerInfo(int employeeId)
        {
            var employee = context.Employees
                .Find(employeeId);

            var managerDto = _mapper.Map<ManagerDto>(employee);

            if (employee == null)
            {
                throw new ArgumentException("Invalid id");
            }
            return managerDto;
                                  
        }

        public void SetManager(int employeeId, int managerId)
        {
            var employee = this.context.Employees.Find(employeeId);
            var manager = this.context.Employees.Find(managerId);

            if (employee == null || manager == null)
            {
                throw new ArgumentException("Invalid id!");
            }
            employee.Manager = manager;
            context.SaveChanges();
        }
    }
}
