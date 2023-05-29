using BookData.Data;
using BookData.Services.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BookData.Services.Repository
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        protected readonly ApplicationDbContext _context;
        private DbSet<TEntity> entities;

        public Repository(ApplicationDbContext context)
        {
            _context = context;
            entities = context.Set<TEntity>();
        }

        protected void save() => _context.SaveChanges();
        public int Count(Func<TEntity, bool> predicate)
        {
            //return _context.Set<TEntity>().Where(predicate).Count();
            return entities.Count();
        }

        public virtual TEntity Create(TEntity entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            _context.Add(entity);
            save();
            return entity;
        }

        public void Delete(TEntity entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            _context.Remove(entity);
            save();
        }

        public IQueryable<TEntity> Find(Func<TEntity, bool> predicate)
        {
            return _context.Set<TEntity>().Where(predicate).AsQueryable();
        }

        public void Remove(TEntity entity)
        {
            foreach (var p in _context.Set<TEntity>())
            {
                _context.Entry(p).State = EntityState.Deleted;
            }

        }

        public IQueryable<TEntity> GetAll()
        {
            return _context.Set<TEntity>();
        }

        public TEntity GetById(int Id)
        {
            return _context.Set<TEntity>().Find(Id);
        }

        public void Update(TEntity entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            _context.Entry(entity).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            save();
        }

        public void RemoveRange(TEntity entity)
        {
            _context.RemoveRange(_context);
            _context.SaveChanges();
        }
    }
}
