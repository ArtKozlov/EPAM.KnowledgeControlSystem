using System.Collections.Generic;

namespace DAL.Interfaces
{
    public interface IRepository<TEntity> where TEntity : class
    {
        IEnumerable<TEntity> GetAll();
        TEntity GetById(int key);
        void Create(TEntity e);
        void Delete(TEntity e);
        void Delete(int key);
        void Update(TEntity e);
    }
}
