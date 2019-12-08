using B_Commerce.Common.Repository;
using B_Commerce.Common.UOW;
using B_Commerce.ProductService.DomainClasses;
using B_Commerce.ProductService.Response;
using B_Commerce.ProductService.Service.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace B_Commerce.ProductService.Service.Concrete
{
    public class SpecialAreaService : ISpecialAreaService
    {
        private IRepository<SpacialArea> _repositorySpacial;
        private IRepository<ProductSpacialAreaTable> _repositoryProductSpecialArea;
        private IUnitOfWork _unitOfWork;

        public SpecialAreaService(IRepository<SpacialArea> repositoryProduct, IRepository<SpacialArea> repositorySpacial, IUnitOfWork unitOfWork, IRepository<ProductSpacialAreaTable> repositoryProductSpecialArea)
        {
            _unitOfWork = unitOfWork;
            _repositorySpacial = repositorySpacial;
            _repositoryProductSpecialArea = repositoryProductSpecialArea;
        }

        public SpecialAreaResponse Add(SpacialArea specialArea)
        {
            SpecialAreaResponse response = new SpecialAreaResponse();
            try
            {
                _repositorySpacial.Add(specialArea);
                _unitOfWork.SaveChanges();
                response.SetStatus(Common.Constants.ResponseCode.SUCCESS);
                return response;
            }
            catch (Exception ex)
            {
                response.SetStatus(Common.Constants.ResponseCode.FAILED_ON_DB_PROCESS, ex.Message);
                return response;
            }
        }
        public ProductSpecialAreaResponse Add(ProductSpacialAreaTable productSpacialAreaTable)
        {
            ProductSpecialAreaResponse response = new ProductSpecialAreaResponse();
            try
            {
                _repositoryProductSpecialArea.Add(productSpacialAreaTable);
                _unitOfWork.SaveChanges();
                response.SetStatus(Common.Constants.ResponseCode.SUCCESS);
                return response;
            }
            catch (Exception ex)
            {
                response.SetStatus(Common.Constants.ResponseCode.FAILED_ON_DB_PROCESS, ex.Message);
                return response;
            }
        }

        public BaseResponse Delete(int ID)
        {
            BaseResponse response = new BaseResponse();
            try
            {
                SpacialArea spacialarea = new SpacialArea { ID = ID };
                _repositorySpacial.Delete(spacialarea);
                _unitOfWork.SaveChanges();
                response.SetStatus(Common.Constants.ResponseCode.SUCCESS);
                return response;
            }
            catch (Exception ex)
            {
                response.SetStatus(Common.Constants.ResponseCode.FAILED_ON_DB_PROCESS, ex.Message);
                return response;
            }
        }

        public SpecialAreaResponse GetSpecialAreas()
        {
            SpecialAreaResponse response = new SpecialAreaResponse();
            try
            {
                foreach (var item in _repositorySpacial.Get().ToList())
                {
                    response.SpecialAreas.Add(new SpecialAreaModel
                    {
                        ID = item.ID,
                        Name = item.Name,
                        Description = item.Description
                    });
                }
                response.SetStatus(Common.Constants.ResponseCode.SUCCESS);
                return response;
            }
            catch (Exception ex)
            {
                response.SetStatus(Common.Constants.ResponseCode.FAILED_ON_DB_PROCESS, ex.Message);
                return response;
            }
        }
        public ProductSpecialAreaResponse GetProductSpecialAreas()
        {
            ProductSpecialAreaResponse response = new ProductSpecialAreaResponse();
            try
            {
                foreach (var item in _repositoryProductSpecialArea.Get().ToList())
                {
                    response.ProductSpecialAreaModels.Add(new ProductSpecialAreaModels
                    {
                        ProductID = item.ProductID,
                        SpecialAreaID = item.SpacialAreaID,
                        ProductName = item.Product.ProductName,
                        SpecialAreaName = item.SpacialArea.Name
                    });
                }
                response.SetStatus(Common.Constants.ResponseCode.SUCCESS);
                return response;
            }
            catch (Exception ex)
            {
                response.SetStatus(Common.Constants.ResponseCode.FAILED_ON_DB_PROCESS, ex.Message);
                return response;
            }
        }

        public SpecialAreaResponse Update(SpacialArea specialArea)
        {
            SpecialAreaResponse response = new SpecialAreaResponse();
            try
            {
                _repositorySpacial.Update(specialArea);
                _unitOfWork.SaveChanges();
                response.SetStatus(Common.Constants.ResponseCode.SUCCESS);
                return response;
            }
            catch (Exception ex)
            {
                response.SetStatus(Common.Constants.ResponseCode.FAILED_ON_DB_PROCESS, ex.Message);
                return response;
            }
        }

        public SpecialAreaResponse GetSpecialAreaByID(int ID)
        {
            SpecialAreaResponse response = new SpecialAreaResponse();
            try
            {
                SpacialArea spacialarea = _repositorySpacial.Get(t => t.ID == ID).FirstOrDefault();
                response.SpecialAreas.Add(new SpecialAreaModel { Name = spacialarea.Name, Description = spacialarea.Description, ID = spacialarea.ID });
                response.SetStatus(Common.Constants.ResponseCode.SUCCESS);
                return response;
            }
            catch (Exception exception)
            {
                response.SetStatus(Common.Constants.ResponseCode.FAILED_ON_DB_PROCESS, exception.Message);
                return response;
            }
        }

        public BaseResponse AddProductToSpecialByID(int ID)
        {
            BaseResponse response = new BaseResponse();
            try
            {
                SpacialArea spacial = _repositorySpacial.Get(t => t.ID == ID).FirstOrDefault();
                spacial.productSpacialAreas.Add(new ProductSpacialAreaTable { ID = spacial.ID });
            }
            catch (Exception)
            {

                throw;
            }
            throw new NotImplementedException();
        }
    }
}
