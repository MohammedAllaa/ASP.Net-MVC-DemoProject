using IKEA.DAL.Contexts;
using IKEA.DAL.Models.Employee;
using IKEA.DAL.Repositories.GenericRepo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IKEA.DAL.Repositories.EmployeeRepos
{
    public class EmployeeRepository :GenericRepository<Employee> ,IEmployeeRepository
    {
        private readonly ApplicationDbContext _context;

        public EmployeeRepository(ApplicationDbContext context): base(context)
        {
            _context = context;
        }
    }
}
