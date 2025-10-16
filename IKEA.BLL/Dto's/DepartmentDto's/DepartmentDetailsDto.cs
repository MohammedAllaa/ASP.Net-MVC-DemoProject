using IKEA.DAL.Models.Department;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IKEA.BLL.Dto_s.DepartmentDto_s
{
    public class DepartmentDetailsDto
    {
        public DepartmentDetailsDto(Department Department) {
            Id = Department.Id;
            Name = Department.Name;
            Description = Department.Description;
            Code = Department.Code;
            CreatedBy = Department.CreatedBy;
            CreatedOn = DateOnly.FromDateTime(Department.CreatedOn);
            LastModifiedBy = Department.LastModifiedBy;
            LastModifiedOn = DateOnly.FromDateTime(Department.LastModifiedOn);


        }
        public int Id { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }
        public string Code { get; set; }

        public int CreatedBy { get; set; }

        public DateOnly CreatedOn { get; set; }

        public int LastModifiedBy { get; set; }

        public DateOnly LastModifiedOn { get; set; }


    }
}
