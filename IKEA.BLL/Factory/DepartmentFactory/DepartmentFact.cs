using IKEA.BLL.Dto_s.DepartmentDto_s;
using IKEA.DAL.Models.Department;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IKEA.BLL.Factory.DepartmentFactory
{
    public static class DepartmentFact
    {
        public static DepartmentDto ToDepartmentDto (this Department department) 
        {
            return new DepartmentDto
            {
                Id = department.Id,
                Name = department.Name,
                Description = department.Description,
                Code = department.Code
            };
        }

        public static DepartmentDetailsDto ToEntity (this Department department)
        {
            return new DepartmentDetailsDto(department);
        }

        public static Department ToDepartment (this CreateDepartmentDto createDepartmentDto)
        {
            return new Department
            {
                Name = createDepartmentDto.Name,
                Description = createDepartmentDto.Description,
                Code = createDepartmentDto.Code,
                CreatedBy  = 1,
                CreatedOn = DateTime.Now,
                LastModifiedBy = 1,
                LastModifiedOn = DateTime.Now,  
                IsDeleted = false
            };
        }

        public static Department FromUpdatedDepartment(this UpdatedDepartmentDto Dto)
        {
            return new Department
            {
                Id= Dto.Id,
                Name = Dto.Name,
                Description = Dto.Description,
                Code = Dto.Code,
                CreatedBy = 1,
                LastModifiedBy = 1,
                LastModifiedOn = DateTime.Now,
                IsDeleted = false
            };
        }
    }
}
