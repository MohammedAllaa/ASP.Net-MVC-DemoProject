using IKEA.BLL.Dto_s.DepartmentDto_s;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IKEA.BLL.Services.DepartmentServices
{
    public interface IDepartmentServices
    {
        public IEnumerable<DepartmentDto> GetAllDepartments();
        public DepartmentDetailsDto GetDepartmentById(int id);
        public int AddDepartment(CreateDepartmentDto departmentDto);
        public int UpdateDepartment(UpdatedDepartmentDto departmentDto);
        public int DeleteDepartment(int id);

    }
}
