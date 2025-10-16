using IKEA.BLL.Dto_s.DepartmentDto_s;
using IKEA.BLL.Factory.DepartmentFactory;
using IKEA.DAL.Repositories.DepartmentRepos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IKEA.BLL.Services.DepartmentServices
{
    public class DepartmentServices:IDepartmentServices
    {
        private readonly IDepartmentRepository _repository;
        public DepartmentServices(IDepartmentRepository repository)
        {
            _repository = repository;
        }

        public IEnumerable<DepartmentDto> GetAllDepartments()
        {
            var Departments = _repository.GetAll();

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
            var Department = _repository.GetById(id);
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
            return _repository.Add(department);
        }

        public int UpdateDepartment(UpdatedDepartmentDto departmentDto)
        {
            var department = departmentDto.FromUpdatedDepartment();
            return _repository.Update(department);
        }

        public int DeleteDepartment(int id)
        {
            return _repository.Delete(id);
        }
    }
}
