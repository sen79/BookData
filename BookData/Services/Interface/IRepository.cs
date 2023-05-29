using System;
using System.Collections.Generic;

namespace BookData.Services.Interface
{
    public interface IRepository<TEntity> where TEntity : class
    {
        IQueryable<TEntity> GetAll();
        IQueryable<TEntity> Find(Func<TEntity, bool> predicate);
        TEntity GetById(int Id);
        TEntity Create(TEntity entity);
        void Update(TEntity entity);
        void Delete(TEntity entity);
        void Remove(TEntity entity);
        void RemoveRange(TEntity entity);
        int Count(Func<TEntity, bool> predicate);
    }
}
