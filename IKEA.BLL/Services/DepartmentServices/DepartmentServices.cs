using IKEA.BLL.Dto_s.DepartmentDto_s;
using IKEA.BLL.Factory.DepartmentFactory;
using IKEA.DAL.Repositories.DepartmentRepos;
using IKEA.DAL.UOW;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IKEA.BLL.Services.DepartmentServices
{
    public class DepartmentServices:IDepartmentServices
    {
       // private readonly IDepartmentRepository _repository;
        private readonly IUnitOfWork unitOfWork;

        public DepartmentServices(IUnitOfWork unitOfWork)
        {
           // _repository = repository;
            this.unitOfWork = unitOfWork;
        }

        public IEnumerable<DepartmentDto> GetAllDepartments()
        {
            var Departments = unitOfWork.DepartmentRepository.GetAll();

            //var MappedDepartments = Departments.Select(d => new DepartmentDto
            //{
            //    Id = d.Id,
            //    Name = d.Name,
            //    Description = d.Description,
            //    Code = d.Code
            //});

            List<DepartmentDto> MappedDepartments = new List<DepartmentDto>();

            foreach (var department in Departments)
            {
                var MappedDepat = department.ToDepartmentDto();
                MappedDepartments.Add(MappedDepat);
            }
            return MappedDepartments;
        }

        public DepartmentDetailsDto GetDepartmentById(int id)
        {
            var Department = unitOfWork.DepartmentRepository.GetById(id);
            if (Department == null)
            {
                return null;
            }
            var MappedDepartment = Department.ToEntity();

            return MappedDepartment;
        }

        public int AddDepartment(CreateDepartmentDto departmentDto)
        {
            var department = departmentDto.ToDepartment();
            unitOfWork.DepartmentRepository.Add(department);
            return unitOfWork.Complete();
        }

        public int UpdateDepartment(UpdatedDepartmentDto departmentDto)
        {
            var department = departmentDto.FromUpdatedDepartment();
            unitOfWork.DepartmentRepository.Update(department);
            return unitOfWork.Complete();
        }

        public int DeleteDepartment(int id)
        {
            unitOfWork.DepartmentRepository.Delete(id);
            return unitOfWork.Complete();
        }
    }
}
