using B_Commerce.Common.DomainClasses;
using B_Commerce.Common.UOW;
using B_Commerce.ProductService.Common;
using B_Commerce.ProductService.Repository.Abstract;
using B_Commerce.ProductService.Response;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using static B_Commerce.ProductService.Common.Constants;

namespace B_Commerce.ProductService.Repository.Concrete
{
    public class BaseRepository<T> : IBaseRepository<T>
        where T : BaseEntity
    {
        private ICRUDRepository<T> _crudRepo;
        private IUnitOfWork _uow;

        public BaseRepository(IUnitOfWork uow,
            ICRUDRepository<T> crudRepo)
        {
            _uow = uow;
            _crudRepo = crudRepo;
        }

        public BaseResponse Add(T entity)
        {
            try
            {
                _crudRepo.Add(entity);
                _uow.SaveChanges();
                return new BaseResponse();
            }
            catch (Exception)
            {

                return new BaseResponse
                {
                    code = ResponseCode.FAILED_ON_DB_PROCESS,
                };
            }
        }

        public BaseResponse Delete(T entity)
        {
            try
            {
                _crudRepo.Delete(entity);
                _uow.SaveChanges();
                return new BaseResponse();
            }
            catch (Exception)
            {

                return new BaseResponse
                {
                    code = ResponseCode.FAILED_ON_DB_PROCESS,
                };
            }
        }

        public QueryableBaseResponse<T> Get(Expression<Func<T, bool>> filter = null)
        {
            try
            {
                return new QueryableBaseResponse<T>
                {
                    queryableResponse = _crudRepo.Get(filter).ToList(),
                    code = ResponseCode.SUCCESS,
                    Message = Constants.ResponseCache[ResponseCode.SUCCESS]
                };
            }
            catch (Exception)
            {
                return new QueryableBaseResponse<T>
                {
                    queryableResponse = null,
                    code = ResponseCode.FAILED_ON_DB_OR_FILTER_PROCESS,
                    Message = GetMessage(ResponseCode.FAILED_ON_DB_OR_FILTER_PROCESS)

                };

            }
        }

        public QueryableBaseResponse<T> GetAll(Expression<Func<T, bool>> filter = null)
        {
            try
            {

                return new QueryableBaseResponse<T>
                {
                    queryableResponse = _crudRepo.Get().ToList(),
                    code = ResponseCode.SUCCESS,
                    Message = Constants.ResponseCache[ResponseCode.SUCCESS]
                };
            }
            catch (Exception)
            {
                return new QueryableBaseResponse<T>
                {
                    queryableResponse = null,
                    code = ResponseCode.FAILED_ON_DB_OR_FILTER_PROCESS,
                    Message = GetMessage(ResponseCode.FAILED_ON_DB_OR_FILTER_PROCESS)

                };

            }
        }

        public BaseResponse Update(T entity)
        {
            try
            {
                _crudRepo.Update(entity);
                _uow.SaveChanges();
                return new BaseResponse();
            }
            catch (Exception)
            {

                return new BaseResponse
                {
                    code = ResponseCode.FAILED_ON_DB_PROCESS,
                };
            }
        }

    }
}
