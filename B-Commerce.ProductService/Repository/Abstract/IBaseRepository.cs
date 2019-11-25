using B_Commerce.Common.DomainClasses;
using B_Commerce.ProductService.Response;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace B_Commerce.ProductService.Repository.Abstract
{
    public interface IBaseRepository<T> 
    {
        BaseResponse Add(T entity);
        BaseResponse Delete(T entity);
        BaseResponse Update(T entity);
        QueryableBaseResponse<T> GetAll(Expression<Func<T,bool>>filter=null);
    }
}
