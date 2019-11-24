using B_Commerce.Common.DomainClasses;
using System;
using System.Linq;
using System.Linq.Expressions;

namespace B_Commerce.ProductService.Repository.Abstract
{
    public interface ICRUDRepository<T> 
        where T:BaseEntity

    {
        void Add(T entity);
        void Delete(T entity);
        void Update(T entity);
        IQueryable<T> Get(Expression<Func<T, bool>> filter = null);
    }
}
