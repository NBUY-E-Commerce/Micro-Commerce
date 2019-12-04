﻿using B_Commerce.Common.Repository;
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
        private IRepository<BannersImage> _repositoryBanner;
        private IUnitOfWork _unitOfWork;

        public ProductService(IRepository<Product> repositoryProduct, IRepository<ProductSpacialAreaTable> repositorySpacialTable, IRepository<SpacialArea> repositorySpacial, IUnitOfWork unitOfWork, IRepository<BannersImage> repositoryBanner)
        {
            _unitOfWork = unitOfWork;
            _repositoryProduct = repositoryProduct;
            _repositorySpacial = repositorySpacial;
            _repositorySpacialTable = repositorySpacialTable;
            _repositoryBanner = repositoryBanner;
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
        public ProductModelResponse GetProducts(int? page, int count)
        {
            List<int> SpecialAreas = new List<int>();
            List<string> productimages = new List<string>();
            int _page = page == null ? 0 : (int)page;
            int index = _page * count;
            List<Product> Productsafterpaging;
            ProductModelResponse productResponse = new ProductModelResponse();
            try
            {
                var products = _repositoryProduct.Get().ToList();
                if (products.Count < index + count)
                {
                    Productsafterpaging = new List<Product>();
                }
                else
                {
                    Productsafterpaging = products.GetRange(index, count);
                }
                foreach (Product item in Productsafterpaging)
                {
                    foreach (ProductImage value in item.ProductImages.ToList())
                    {
                        productimages.Add(value.URLFromAway);
                    }
                    foreach (ProductSpacialAreaTable value in item.productSpacialAreas.ToList())
                    {
                        SpecialAreas.Add(value.SpacialAreaID);
                    }
                    ProductModel productModel = new ProductModel
                    {
                        ID = item.ID,
                        Description = item.Description,
                        Price = item.Price,
                        ProductImages = productimages,
                        ProductName = item.ProductName,
                        SpecialAreas = SpecialAreas
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
        public ProductModelResponse GetProductsByCategoryID(int categoryID, int? page, int count)
        {
            int _page = page == null ? 0 : (int)page;
            int index = _page * count;
            List<int> SpecialAreas = new List<int>();
            List<string> productimages = new List<string>();
            List<Product> Productsafterpaging;
            ProductModelResponse productResponse = new ProductModelResponse();
            try
            {
                var products = _repositoryProduct.Get(t=>t.CategoryID==categoryID).ToList();
                if (products.Count < index + count)
                {
                    Productsafterpaging = new List<Product>();
                }
                else
                {
                    Productsafterpaging = products.GetRange(index, count);
                }
                foreach (Product item in Productsafterpaging)
                {
                    foreach (ProductImage value in item.ProductImages.ToList())
                    {
                        productimages.Add(value.URLFromAway);
                    }
                    foreach (ProductSpacialAreaTable value in item.productSpacialAreas.ToList())
                    {
                        SpecialAreas.Add(value.SpacialAreaID);
                    }
                    ProductModel productModel = new ProductModel
                    {
                        ID = item.ID,
                        Description = item.Description,
                        Price = item.Price,
                        ProductImages = productimages,
                        ProductName = item.ProductName,
                        SpecialAreas = SpecialAreas
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

        public BannerResponse GetBanners()
        {
            BannerResponse bannerResponse = new BannerResponse();

            try
            {
                bannerResponse.BannersImages = _repositoryBanner.Get().OrderByDescending(t => t.ID).Take(5).ToList();

                if (bannerResponse != null)
                {
                    bannerResponse.SetStatus(ResponseCode.SUCCESS);
                    return bannerResponse;
                }
                //b// 2kdk discorda gel daha hızlı ilerleriz bende cıkıcam az sonra 
                bannerResponse.SetStatus(ResponseCode.SYSTEM_ERROR);
                return bannerResponse;
            }
            catch (Exception ex)
            {

                bannerResponse.BannersImages = null;
                bannerResponse.SetStatus(ResponseCode.FAILED_ON_DB_PROCESS, ex.Message);
                return bannerResponse;
            }

        }
    }
}
