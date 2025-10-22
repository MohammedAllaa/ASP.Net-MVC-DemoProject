using IKEA.DAL.Models.Employee;
using IKEA.DAL.Models.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IKEA.DAL.Repositories.GenericRepo
{
    public interface IGenericRepository<TEntity> where TEntity : BaseEntity
    {
        public IQueryable<TEntity> GetAll(bool WithNoTracking = false);

        public TEntity GetById(int id);

        public void Add(TEntity Item);
        public void Update(TEntity Item);
        public void Delete(int id);
    }
}

