using B_Commerce.Common.Repository;
using B_Commerce.Common.UOW;
using B_Commerce.ProductService.DomainClasses;
using B_Commerce.ProductService.Service.Abstract;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using B_Commerce.ProductService.Response;
using static B_Commerce.ProductService.Common.Constants;

namespace B_Commerce.ProductService.Service.Concrete
{
    public class CategoryService:ICategoryService
    {

        private IRepository<Category> _repository;
        private IUnitOfWork _unitOfWork;
        public CategoryService(IRepository<Category> repository,IUnitOfWork unitOfWork) {
            _repository = repository;
            _unitOfWork = unitOfWork;
        }

        public BaseResponse Add(Category category)
        {
            BaseResponse baseResponse = new BaseResponse();
            try
            {
                _repository.Add(category);
                _unitOfWork.SaveChanges();
                baseResponse.SetStatus(ResponseCode.SUCCESS);
                return baseResponse;
            }
            catch (Exception ex)
            {

                baseResponse.SetStatus(ResponseCode.FAILED_ON_DB_PROCESS,ex.Message);
                return baseResponse;
            }
            
        }
        public BaseResponse Delete(Category category)
        {
            BaseResponse baseResponse = new BaseResponse();
            try
            {
                _repository.Delete(category);
                _unitOfWork.SaveChanges();
                baseResponse.SetStatus(ResponseCode.SUCCESS);
                return baseResponse;
            }
            catch (Exception ex)
            {

                baseResponse.SetStatus(ResponseCode.FAILED_ON_DB_PROCESS, ex.Message);
                return baseResponse;
            }
        }
        public BaseResponse Update(Category category)
        {
            BaseResponse baseResponse = new BaseResponse();
            try
            {
                _repository.Update(category);
                _unitOfWork.SaveChanges();
                baseResponse.SetStatus(ResponseCode.SUCCESS);
                return baseResponse;
            }
            catch (Exception ex)
            {

                baseResponse.SetStatus(ResponseCode.FAILED_ON_DB_PROCESS, ex.Message);
                return baseResponse;
            }
        }
        public CategoryResponse GetCategories()
        {
            CategoryResponse categoryResponse = new CategoryResponse();
            try
            {
                categoryResponse.categories = _repository.Get().ToList();
                categoryResponse.SetStatus(ResponseCode.SUCCESS);
                return categoryResponse;
            }
            catch (Exception ex)
            {
                categoryResponse.categories = null;
                categoryResponse.SetStatus(ResponseCode.FAILED_ON_DB_PROCESS,ex.Message);
                return categoryResponse;
            }
        }
        public CategoryResponse GetMasterCategories()
        {
            CategoryResponse categoryResponse = new CategoryResponse();
            try
            {
                categoryResponse.categories = _repository.Get(t=>t.MasterCategoryID==null).ToList();
                categoryResponse.SetStatus(ResponseCode.SUCCESS);
                return categoryResponse;
            }
            catch (Exception ex)
            {
                categoryResponse.categories = null;
                categoryResponse.SetStatus(ResponseCode.FAILED_ON_DB_PROCESS, ex.Message);
                return categoryResponse;
            }
        }
        public CategoryResponse GetSubCategoriesByCategoryID(int id)
        {
            CategoryResponse categoryResponse = new CategoryResponse();
            try
            {
                categoryResponse.categories = _repository.Get(t=>t.MasterCategoryID==id).ToList();
                categoryResponse.SetStatus(ResponseCode.SUCCESS);
                return categoryResponse;
            }
            catch (Exception ex)
            {
                categoryResponse.categories = null;
                categoryResponse.SetStatus(ResponseCode.FAILED_ON_DB_PROCESS, ex.Message);
                return categoryResponse;
            }
        }
    }
}
