using B_Commerce.Common.UOW;
using B_Commerce.ProductService.DomainClasses;
using B_Commerce.ProductService.Repository.Abstract;
using B_Commerce.ProductService.Repository.Concrete;
using B_Commerce.ProductService.Response;
using B_Commerce.ProductService.Services.Abstracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace B_Commerce.ProductService.Services.Concrete
{
    public class SubCategoryService: BaseRepository<SubCategory>,ISubCategoryService
    {
        private ICRUDRepository<SubCategory> _crudRepo;
        private IUnitOfWork _uow;

        public SubCategoryService(ICRUDRepository<SubCategory> crudRepo, IUnitOfWork uow):base(uow,crudRepo) {
            _uow = uow;
            _crudRepo = crudRepo;
        }
        public QueryableBaseResponse<SubCategory> GetSubCategories()
        {
           return this.GetAll();
        }

        public QueryableBaseResponse<SubCategory> GetSubCategoryById(int id)
        {
            return this.Get(t=>t.ID==id);
        }

        public QueryableBaseResponse<SubCategory> GetSubCategoryByMasterId(int id)
        {
            return this.Get(t=>t.MasterCatID==id);
        }
    }
}
