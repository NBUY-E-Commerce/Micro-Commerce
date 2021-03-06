﻿using B_Commerce.Common.Repository;
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
    public class CategoryService : ICategoryService
    {

        private IRepository<Category> _repository;
        private IUnitOfWork _unitOfWork;
        public CategoryService(IRepository<Category> repository, IUnitOfWork unitOfWork)
        {
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

                baseResponse.SetStatus(ResponseCode.FAILED_ON_DB_PROCESS, ex.Message);
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

        public CategoryModelResponse GetSubCategoriesByCategoryID(int? id)
        {
            if (id == 0) id = null;
            CategoryModelResponse categoryResponse = new CategoryModelResponse();
            try
            {
                List<Category> categories = _repository.Get(t => t.MasterCategoryID == id).ToList();


                categoryResponse.Categories = CategoryModel.GetCategoryModelFromData(categories);
                categoryResponse.SetStatus(ResponseCode.SUCCESS);
                return categoryResponse;
            }
            catch (Exception ex)
            {

                categoryResponse.SetStatus(ResponseCode.FAILED_ON_DB_PROCESS, ex.Message);
                return categoryResponse;
            }
        }

        public CategoryResponse GetByID(int id)
        {

            CategoryResponse categoryResponse = new CategoryResponse();
            try
            {
                Category category = _repository.Get(t => t.ID == id).FirstOrDefault();

                if (category == null)
                {
                    categoryResponse.SetStatus(ResponseCode.NOT_FOUND_ENTITY);
                    return categoryResponse;
                }

                categoryResponse.Category = category;
                categoryResponse.SetStatus(ResponseCode.SUCCESS);
                return categoryResponse;
            }
            catch (Exception ex)
            {

                categoryResponse.SetStatus(ResponseCode.FAILED_ON_DB_PROCESS, ex.Message);
                return categoryResponse;
            }
        }

        public List<CategoryShortInfo> GetCategoriesWithShortInfo()
        {
            List<Category> categories = _repository.Get().OrderBy(t => t.CategoryName).ToList();

            List<CategoryShortInfo> categoryShortInfos = new List<CategoryShortInfo>();

            if (categories.Count > 0)
            {
                foreach (Category item in categories)
                {
                    categoryShortInfos.Add(new CategoryShortInfo
                    {
                        ID = item.ID,
                        CategoryName = item.CategoryName,
                        MasterCategoryID = item.MasterCategoryID
                    });
                }
            }
            return categoryShortInfos;
        }

        public List<CategoryShortInfo> GetCategoryBranch(int ID)
        {
            List<CategoryShortInfo> shortInfos = new List<CategoryShortInfo>();
            getShortInfo(ID, ref shortInfos);
            
            void getShortInfo(int? ID, ref List<CategoryShortInfo> categories)
            {
                var a = _repository.Get(t => t.ID == ID).Select(t => new { t.ID, t.CategoryName, t.MasterCategoryID }).FirstOrDefault();
                CategoryShortInfo cat = null;
                if (a != null)
                {
                    cat = new CategoryShortInfo
                    {
                        ID = a.ID,
                        CategoryName = a.CategoryName,
                        MasterCategoryID = a.MasterCategoryID
                    };
                    categories.Add(cat);
                }
                
                if (cat.MasterCategoryID != null)
                {
                    getShortInfo(cat.MasterCategoryID,ref categories);
                }
            }
            shortInfos.Reverse();
            return shortInfos;
        }
    }
}
