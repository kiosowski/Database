using AutoMapper;
using Banicharnica.App.Core.Dtos;
using Banicharnica.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Banicharnica.App.Core
{
    public class BanicharnicaProfile : Profile
    {
        public BanicharnicaProfile()
        {
            CreateMap<Employee, ManagerDto>().ReverseMap();
            CreateMap<Employee, EmployeeDto>().ReverseMap();
           
           
        }
    }
}
