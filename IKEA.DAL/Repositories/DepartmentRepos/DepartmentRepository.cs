using IKEA.DAL.Contexts;
using IKEA.DAL.Models.Department;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IKEA.DAL.Repositories.DepartmentRepos
{
    public class DepartmentRepository : IDepartmentRepository
    {
        private readonly ApplicationDbContext _context;
        public DepartmentRepository(ApplicationDbContext context)
        {
            _context = context;

        }

        public IEnumerable<Department> GetAll(bool WithNoTracking = false)
        {
            if (WithNoTracking)
                return _context.Departments.ToList();
            else
                return _context.Departments.AsNoTracking().ToList();
        }

        public Department GetById(int id)
        {
            var Department = _context.Departments.Find(id);
            return Department;
        }

        public int Update(Department department)
        {
            _context.Departments.Update(department);
            return _context.SaveChanges();
        }

        public int Add(Department department)
        {
            _context.Departments.Add(department);
            return _context.SaveChanges();
        }

        public int Delete(int id)
        {
            var department = _context.Departments.Find(id);
            _context.Departments.Remove(department);
            return _context.SaveChanges();
        }

        
    }
}
