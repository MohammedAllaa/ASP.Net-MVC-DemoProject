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

        public IQueryable<TEntity> GetAll(bool WithNoTracking = false)
        {
            if (WithNoTracking)
                return _context.Set<TEntity>();
            else
                return _context.Set<TEntity>().AsNoTracking();
            // fixed: when WithNoTracking == true return AsNoTracking()

            //var query = _context.Set<TEntity>().AsQueryable();
            //if (WithNoTracking)
            //    return query.AsNoTracking();
            //return query;
        }

        public TEntity GetById(int id)
        {
            var tEntity = _context.Set<TEntity>().Find(id);
            return tEntity;
        }

        
        public void Add(TEntity Item)
        {
            _context.Set<TEntity>().Add(Item);
           
        }
        public void Update(TEntity Item)
        {
            _context.Set<TEntity>().Update(Item);
           
        }
        public void Delete(int id)
        {
            var tEntity = _context.Set<TEntity>().Find(id);
            _context.Set<TEntity>().Remove(tEntity);
            
        }

        
    }
}
