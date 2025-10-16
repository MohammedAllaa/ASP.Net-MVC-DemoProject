using IKEA.DAL.Models.Department;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IKEA.DAL.Repositories.DepartmentRepos
{
    public interface IDepartmentRepository
    {
        public IEnumerable<Department> GetAll(bool WithNoTracking = false);

        public Department GetById(int id);

        public int Add(Department department);
        public int Update(Department department);
        public int Delete(int id);

    }
}
