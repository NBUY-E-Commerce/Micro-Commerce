using System;
using System.Linq;
using System.Linq.Expressions;
using B_Commerce.Common.DomainClasses;
using B_Commerce.ProductService.Repository.Abstract;
using Microsoft.EntityFrameworkCore;

namespace B_Commerce.ProductService.Repository.Concrete
{
    public class CRUDRepository<T> : ICRUDRepository<T> where T : BaseEntity
    {
        private DbContext _context;
        private DbSet<T> _dbSet;
        public CRUDRepository(DbContext context) {
            _context = context;
            _dbSet = _context.Set<T>();
        }
        public void Add(T entity)
        {
            _context.Entry(entity).State = EntityState.Added;
        }

        public void Delete(T entity)
        {
            entity.isDeleted = true;
            _context.Entry(entity).State = EntityState.Modified;
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
            _context.Entry(entity).State = EntityState.Modified;
        }
    }
}
