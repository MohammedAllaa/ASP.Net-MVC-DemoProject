using IKEA.DAL.Models.Shared;
using IKEA.DAL.Models.Department;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IKEA.DAL.Models.Employee
{
    public class Employee : BaseEntity
    {
        public string Name { get; set; } = null!;

        public int Age { get; set; }

        public string? Address { get; set; }

        public decimal Salary { get; set; }

        public bool isActive { get; set; } 

        public string? Email { get; set; }

        public string? PhoneNumber { get; set; }

        public DateOnly HiringDate { get; set; }

        public Gender Gender { get; set; }

        public EmployeeType EmployeeType { get; set; }

        public int? DepartmentId { get; set; }

        public virtual Department.Department? Department { get; set; }

        public string? ImageName { get; set; }


    }
}
