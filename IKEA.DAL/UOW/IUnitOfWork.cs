using IKEA.DAL.Repositories.DepartmentRepos;
using IKEA.DAL.Repositories.EmployeeRepos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IKEA.DAL.UOW
{
    public interface IUnitOfWork
    {
        public IEmployeeRepository EmployeeRepository { set;  get; }
        public IDepartmentRepository DepartmentRepository { set;  get; }
        public int Complete();
    }
}
