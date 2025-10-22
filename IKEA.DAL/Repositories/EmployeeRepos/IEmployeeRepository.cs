using IKEA.DAL.Models.Department;
using IKEA.DAL.Models.Employee;
using IKEA.DAL.Repositories.GenericRepo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IKEA.DAL.Repositories.EmployeeRepos
{
    public interface IEmployeeRepository: IGenericRepository<Employee>
    {
        public IEnumerable<Employee> GetAll(string? searchValue);
    }
}
