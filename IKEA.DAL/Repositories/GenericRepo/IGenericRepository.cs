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
        public IEnumerable<TEntity> GetAll(bool WithNoTracking = false);

        public TEntity GetById(int id);

        public int Add(TEntity Item);
        public int Update(TEntity Item);
        public int Delete(int id);
    }
}

