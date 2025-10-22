using AutoMapper;
using IKEA.BLL.Dto_s.DepartmentDto_s;
using IKEA.BLL.Dto_s.EmployeeDto_s;
using IKEA.DAL.Models.Employee;
using IKEA.DAL.Repositories.EmployeeRepos;
using IKEA.DAL.UOW;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IKEA.BLL.Services.EmployeeServices
{
    public class EmployeeServices : IEmployeeServices
    {
       // private readonly IEmployeeRepository _employeeRepository;
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;

        public EmployeeServices(IUnitOfWork unitOfWork,IMapper mapper)
        {
            //this._employeeRepository = employeeRepository;
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }

        public IEnumerable<EmployeeDto> GetAllEmployees()
        {
            return  mapper.Map<IEnumerable<Employee>,IEnumerable<EmployeeDto>>(unitOfWork.EmployeeRepository.GetAll());
        }

        public IEnumerable<EmployeeDto> GetSearchedEmployyes(string? searchValue)
        {
            return mapper.Map<IEnumerable<Employee>, IEnumerable<EmployeeDto>>(unitOfWork.EmployeeRepository.GetAll(searchValue));
        }
        public EmployeeDetailsDto GetEmployeeById(int id)
        {
            return mapper.Map<Employee,EmployeeDetailsDto>(unitOfWork.EmployeeRepository.GetById(id));
        }
        public int CreateEmployee(CreatedEmployeeDto dto)
        {
            var Emp = mapper.Map<CreatedEmployeeDto, Employee>(dto);
            Emp.CreatedBy = 1;
            Emp.CreatedOn = DateTime.Now;
            Emp.LastModifiedBy = 1;
            Emp.LastModifiedOn = DateTime.Now;

             unitOfWork.EmployeeRepository.Add(Emp);
            return unitOfWork.Complete();
        }
        public int UpdateEmployee(UpdatedEmployeeDto dto)
        {
            var Emp = mapper.Map<UpdatedEmployeeDto, Employee>(dto);
            Emp.LastModifiedBy = 1;
            Emp.LastModifiedOn = DateTime.Now;
            unitOfWork.EmployeeRepository.Update(Emp);
            return unitOfWork.Complete();
        }
        public int DeleteEmployee(int? id)
        {
            if (id is not null)
            {
                unitOfWork.EmployeeRepository.Delete(id.Value);
                return unitOfWork.Complete();
            }
            else
                return 0;
        }

        
    }
}
