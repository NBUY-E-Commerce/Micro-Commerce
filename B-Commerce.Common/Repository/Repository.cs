using B_Commerce.Common.DomainClasses;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;

namespace B_Commerce.Common.Repository
{
    public class Repository<T> : IRepository<T> where T : BaseEntity, new()
    {
        private DbContext _context;
        private DbSet<T> _dbSet;
        public Repository(DbContext context)
        {
            _context = context;
            _dbSet = _context.Set<T>();
        }

        public void Add(T entity)
        {
            _dbSet.Add(entity);
        }

        public void Delete(T entity)
        {
            _dbSet.Remove(entity);
        }

        public IQueryable<T> Get(Expression<Func<T, bool>> filter = null)
        {
            
            if (filter == null)
            {
                return _dbSet.AsQueryable();
            }
            return _dbSet.Where(filter).AsQueryable();
        }

        public void Update(T entity)
        {
            _dbSet.Update(entity);
        }
    }
}
