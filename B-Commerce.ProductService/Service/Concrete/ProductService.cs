using B_Commerce.Common.Repository;
using B_Commerce.Common.UOW;
using B_Commerce.ProductService.DomainClasses;
using B_Commerce.ProductService.Response;
using B_Commerce.ProductService.Service.Abstract;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using static B_Commerce.ProductService.Common.Constants;

namespace B_Commerce.ProductService.Service.Concrete
{
    public class ProductService : IProductService
    {
        private IRepository<Product> _repositoryProduct;
        private IRepository<ProductSpacialAreaTable> _repositorySpacialTable;
        private IRepository<SpacialArea> _repositorySpacial;
        private IUnitOfWork _unitOfWork;

        public ProductService(IRepository<Product> repositoryProduct, IRepository<ProductSpacialAreaTable> repositorySpacialTable, IRepository<SpacialArea> repositorySpacial, IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _repositoryProduct = repositoryProduct;
            _repositorySpacial = repositorySpacial;
            _repositorySpacialTable = repositorySpacialTable;
        }
        public BaseResponse Add(Product product)
        {
            BaseResponse baseResponse = new BaseResponse();
            try
            {
                _repositoryProduct.Add(product);
                if (_unitOfWork.SaveChanges() < 1)
                {
                    baseResponse.SetStatus(ResponseCode.FAILED_ON_DB_PROCESS);
                    return baseResponse;

                }
                baseResponse.SetStatus(ResponseCode.SUCCESS);
                return baseResponse;
            }
            catch (Exception ex)
            {
                baseResponse.SetStatus(ResponseCode.FAILED_ON_DB_PROCESS, ex.Message);
                return baseResponse;
            }
        }
        public BaseResponse Delete(Product product)
        {
            BaseResponse baseResponse = new BaseResponse();
            try
            {
                _repositoryProduct.Delete(product);
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
        public BaseResponse Update(Product product)
        {
            BaseResponse baseResponse = new BaseResponse();
            try
            {
                //var updateproduct = _repositoryProduct.Get(t => t.ID == product.ID).SingleOrDefault();
                //updateproduct.ProductName = product.ProductName;
                _repositoryProduct.Update(product);
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
        public ProductModelResponse GetProducts(int? index, int count)
        {
            int pageNumber = (index ?? 1);
            ProductModelResponse productResponse = new ProductModelResponse();
            try
            {
             var products = _repositoryProduct.Get().ToList().GetRange(pageNumber, count);
                foreach (Product item in products)
                {
                    ProductModel productModel = new ProductModel
                    {
                        ID = item.ID,
                        Description = item.Description,
                        Price = item.Price,
                        ProductImages = item.ProductImages.ToList(),
                        ProductName = item.ProductName,
                        SpecialAreas = item.productSpacialAreas.ToList()
                    };
                    productResponse.Products.Add(productModel);
                }
                productResponse.SetStatus(ResponseCode.SUCCESS);
                return productResponse;
            }
            catch (Exception ex)
            {
                productResponse.Products = null;
                productResponse.SetStatus(ResponseCode.FAILED_ON_DB_PROCESS, ex.Message);
                return productResponse;
            }
        }

        public ProductModelResponse GetProductsByCategoryID(int categoryID,int? index,int count)
        {
            int pageNumber = (index ?? 1);
            ProductModelResponse productResponse = new ProductModelResponse();
            try
            {
                var products = _repositoryProduct.Get(t => t.CategoryID == categoryID).ToList().GetRange(pageNumber, count);
                foreach (Product item in products)
                {
                    ProductModel productModel = new ProductModel
                    {
                        ID = item.ID,
                        Description = item.Description,
                        Price = item.Price,
                        ProductImages = item.ProductImages.ToList(),
                        ProductName = item.ProductName,
                        SpecialAreas = item.productSpacialAreas.ToList()
                    };
                    productResponse.Products.Add(productModel);
                }
                //
                productResponse.SetStatus(ResponseCode.SUCCESS);
                return productResponse;
            }
            catch (Exception ex)
            {
                productResponse.Products = null;
                productResponse.SetStatus(ResponseCode.FAILED_ON_DB_PROCESS, ex.Message);
                return productResponse;
            }
        }

        public ProductResponse GetSpecialProducts(int spacialID, int? index, int count)
        {
            ProductResponse productResponse = new ProductResponse();
            try
            {
                int pageNumber = (index ?? 1);
                SpacialArea spacialArea = _repositorySpacial.Get(t => t.ID == spacialID).FirstOrDefault();

                if (spacialArea == null)
                {
                    productResponse.Products = null;
                    productResponse.SetStatus(ResponseCode.NOT_FOUND_ENTITY);
                    return productResponse;
                }

                List<ProductSpacialAreaTable> spacialAreaProducts = _repositorySpacialTable.Get(t => t.SpacialAreaID == spacialArea.ID).ToList().GetRange(pageNumber, count);

                if (spacialAreaProducts == null)
                {
                    productResponse.Products = null;
                    productResponse.SetStatus(ResponseCode.NOT_FOUND_ENTITY);
                    return productResponse;
                }
                List<Product> productList = new List<Product>();
                foreach (ProductSpacialAreaTable item in spacialAreaProducts)
                {
                    productList.Add(item.Product);
                }
                productResponse.Products = productList;
                productResponse.SetStatus(ResponseCode.SUCCESS);
                return productResponse;
            }
            catch (Exception ex)
            {
                productResponse.Products = null;
                productResponse.SetStatus(ResponseCode.FAILED_ON_DB_PROCESS, ex.Message);
                return productResponse;
            }
        }


    }
}
