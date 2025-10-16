using IKEA.DAL.Contexts;
using IKEA.DAL.Models.Department;
using IKEA.DAL.Models.Shared;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IKEA.DAL.Repositories.GenericRepo
{
    public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : BaseEntity
    {
        private readonly ApplicationDbContext _context;

        public GenericRepository(ApplicationDbContext context)
        {
            this._context = context;
        }

        public IEnumerable<TEntity> GetAll(bool WithNoTracking = false)
        {
            if (WithNoTracking)
                return _context.Set<TEntity>().ToList();
            else
                return _context.Set<TEntity>().AsNoTracking().ToList();
        }

        public TEntity GetById(int id)
        {
            var tEntity = _context.Set<TEntity>().Find(id);
            return tEntity;
        }

        
        public int Add(TEntity Item)
        {
            _context.Set<TEntity>().Add(Item);
            return _context.SaveChanges();
        }
        public int Update(TEntity Item)
        {
            _context.Set<TEntity>().Update(Item);
            return _context.SaveChanges();
        }
        public int Delete(int id)
        {
            var tEntity = _context.Set<TEntity>().Find(id);
            _context.Set<TEntity>().Remove(tEntity);
            return _context.SaveChanges();
        }

        
    }
}
