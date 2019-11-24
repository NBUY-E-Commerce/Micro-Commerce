using B_Commerce.Common.UOW;
using B_Commerce.ProductService.DomainClasses;
using B_Commerce.ProductService.Repository.Abstract;
using B_Commerce.ProductService.Repository.Concrete;
using B_Commerce.ProductService.Response;
using B_Commerce.ProductService.Services.Abstracts;

namespace B_Commerce.ProductService.Services.Concrete
{
    public class ProductImageService : BaseRepository<ProductImage>, IProductImageService
    {
        private ICRUDRepository<ProductImage> _crudRepo;
        private IUnitOfWork _uow;

        public ProductImageService(IUnitOfWork uow,
            ICRUDRepository<ProductImage> crudRepo) : base(uow, crudRepo)
        {
            _uow = uow;
            _crudRepo = crudRepo;
        }
        public QueryableBaseResponse<ProductImage> GetImagesByProductId(int id)
        {
            return this.Get(t=>t.ProductID==id);
        }
    }
}
