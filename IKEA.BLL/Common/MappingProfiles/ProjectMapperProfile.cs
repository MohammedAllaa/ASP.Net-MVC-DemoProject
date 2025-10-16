using AutoMapper;
using IKEA.BLL.Dto_s.EmployeeDto_s;
using IKEA.DAL.Models.Employee;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IKEA.BLL.Common.MappingProfiles
{
    public class ProjectMapperProfile : Profile
    {
        public ProjectMapperProfile()
        {
            CreateMap<Employee, EmployeeDto>().ForMember(d => d.DepartmentName, options => options.MapFrom(src=>src.Department != null ? src.Department.Name : "N/A" )).ReverseMap();
            CreateMap<Employee, EmployeeDetailsDto>().ForMember(d => d.DepartmentName, options => options.MapFrom(src => src.Department != null ? src.Department.Name : "N/A")).ReverseMap();
            CreateMap<Employee, CreatedEmployeeDto>().ReverseMap();
            CreateMap<Employee, UpdatedEmployeeDto>().ReverseMap();
        }

       
    }
}
