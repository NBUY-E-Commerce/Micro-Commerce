using B_Commerce.Common.UOW;
using B_Commerce.ProductService.DomainClasses;
using B_Commerce.ProductService.Repository.Abstract;
using B_Commerce.ProductService.Repository.Concrete;
using B_Commerce.ProductService.Response;
using B_Commerce.ProductService.Services.Abstracts;
using System.Linq;

namespace B_Commerce.ProductService.Services.Concrete
{
    public class MasterCategoryService:BaseRepository<MasterCategory>,IMasterCategoryService
    {
        private ICRUDRepository<MasterCategory> _crudRepo;
        private IUnitOfWork _uow;

        public MasterCategoryService(IUnitOfWork uow,
            ICRUDRepository<MasterCategory> crudRepo):base(uow,crudRepo)
        {
            _uow = uow;
            _crudRepo = crudRepo;
        }


        public QueryableBaseResponse<MasterCategory> GetMasterCategories()
        {
            return this.GetAll();
        }

        public QueryableBaseResponse<MasterCategory> GetMasterCategoryById(int id)
        {
            return this.Get(t=>t.ID==id);
        }
    }
}
