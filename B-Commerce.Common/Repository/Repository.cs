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
            _context.Entry(entity).State = EntityState.Added;
        }

         public void Delete(T entity)
        {
            if (entity.GetType().GetProperties("IsDelete")!=null)
            {
                
                  T _entity = entity;

                _entity.GetType().GetProperty("IsDelete").SetValue(_entity, true);

                this.Update(_entity);
            }
              else
              {
              
                DbEntityEntry dbEntityEntry = _dbContext.Entry(entity);

                if (dbEntityEntry.State != EntityState.Deleted)
                {
                    dbEntityEntry.State = EntityState.Deleted;
                }
                else
                {
                    _dbSet.Attach(entity);
                    _dbSet.Remove(entity);
                }
              }
	   
          //  _context.Entry(entity).State = EntityState.Deleted;
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
