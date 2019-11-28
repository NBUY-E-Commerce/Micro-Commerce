using B_Commerce.Common.UOW;
using B_Commerce.ProductService.DomainClasses;
using B_Commerce.ProductService.Repository.Abstract;
using B_Commerce.ProductService.Repository.Concrete;
using B_Commerce.ProductService.Response;
using B_Commerce.ProductService.Services.Abstracts;
using System;


namespace B_Commerce.ProductService.Services.Concrete
{
    public class ProductService : BaseRepository<Product>, IProductService
    {
        private ICRUDRepository<Product> _crudRepo;
        private IUnitOfWork _uow;

        public ProductService(IUnitOfWork uow,
            ICRUDRepository<Product> crudRepo) : base(uow, crudRepo)
        {
            _uow = uow;
            _crudRepo = crudRepo;
        }
        public QueryableBaseResponse<Product> GetProductById(int id)
        {
            return this.Get(t=>t.ID==id);
        }

        public QueryableBaseResponse<Product> GetProducts()
        {
            return this.GetAll();
        }

        public QueryableBaseResponse<Product> GetProductsByCategoryId(int id)
        {
            return this.Get(t=>t.SubCategoryID==id);
        }
    }
}
