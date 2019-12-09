using B_Commerce.Common.Repository;
using B_Commerce.Common.UOW;
using B_Commerce.ProductService.DomainClasses;
using B_Commerce.ProductService.Response;
using B_Commerce.ProductService.Service.Abstract;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using B_Commerce.ProductService.Common;
using B_Commerce.ProductService.Request;
using Microsoft.EntityFrameworkCore;

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
                    baseResponse.SetStatus(Constants.ResponseCode.FAILED_ON_DB_PROCESS);
                    return baseResponse;

                }
                baseResponse.SetStatus(Constants.ResponseCode.SUCCESS);
                return baseResponse;
            }
            catch (Exception ex)
            {
                baseResponse.SetStatus(Constants.ResponseCode.FAILED_ON_DB_PROCESS, ex.Message);
                return baseResponse;
            }
        }

        public GetProductModelResponse GetProductByID(int ID)
        {
            GetProductModelResponse response = new GetProductModelResponse();
            try
            {
                Product product = _repositoryProduct.Get(t => t.ID == ID).SingleOrDefault();
                response.GetProductModel = new GetProductModel
                {
                    ID = product.ID,
                    AvailableCount = product.AvailableCount,
                    CategoryID = product.CategoryID,
                    Color = product.Color,
                    Description = product.Description,
                    isActive = product.isActive,
                    Price = product.Price,
                    ProductName = product.ProductName,
                    Size = product.Size,
                    BrandID = product.BrandID
                };
                foreach (ProductImage item in product.ProductImages)
                {
                    response.GetProductModel.ImageUrls.Add(item.URL);
                }
                response.SetStatus(Constants.ResponseCode.SUCCESS);
                return response;
            }
            catch (Exception)
            {

                response.SetStatus(Constants.ResponseCode.FAILED_ON_DB_PROCESS);
                return response;
            }
        }
        public BaseResponse Delete(Product product)
        {
            BaseResponse baseResponse = new BaseResponse();
            try
            {
                _repositoryProduct.Delete(product);
                _unitOfWork.SaveChanges();
                baseResponse.SetStatus(Constants.ResponseCode.SUCCESS);
                return baseResponse;
            }
            catch (Exception ex)
            {

                baseResponse.SetStatus(Constants.ResponseCode.FAILED_ON_DB_PROCESS, ex.Message);
                return baseResponse;
            }
        }
        public BaseResponse Update(Product product)
        {
            BaseResponse baseResponse = new BaseResponse();
            try
            {
                var updateproduct = _repositoryProduct.Get(t => t.ID == product.ID).SingleOrDefault();

                updateproduct.Description = product.Description;
                updateproduct.Price = product.Price;
                updateproduct.ProductName = product.ProductName;
                updateproduct.ProductImages = product.ProductImages;
                if (product.CategoryID != 0) updateproduct.CategoryID = product.CategoryID;
                _repositoryProduct.Update(updateproduct);
                _unitOfWork.SaveChanges();
                baseResponse.SetStatus(Constants.ResponseCode.SUCCESS);
                return baseResponse;
            }
            catch (Exception ex)
            {

                baseResponse.SetStatus(Constants.ResponseCode.FAILED_ON_DB_PROCESS, ex.Message);
                return baseResponse;
            }
        }
        public ProductModelResponse GetProducts(GetProductRequest request)
        {
            ProductModelResponse productResponse = new ProductModelResponse();
            //page 2 count 10 için 
            //index=20 yani 20 den basla 10 tane getir.
            try
            {
                //ilk  20 elemanı gec sonrasındakı 10 taneyı al 
                //**eğer 10 tane yoksa 6 tane varsa 6 tanesi alınır.Hata vermez!!!!
                int index = (request.Page - 1) * request.Range;//dbde kac kayıt es gecılmeli



                var products = _repositoryProduct.Get().Where(t => request.CategoryID == 0 || t.CategoryID == request.CategoryID).Where(t => request.BrandID == 0 || t.BrandID == request.BrandID).Where(t => string.IsNullOrEmpty(request.Color) || t.Color == request.Color).Skip(index).Take(request.Range).ToList();

                foreach (Product item in products)
                {

                    ProductModel productModel = new ProductModel
                    {
                        ID = item.ID,
                        Description = item.Description,
                        Price = item.Price,
                        ProductImages = item.ProductImages.Select(t => t.URLFromAway).ToList(),
                        ProductName = item.ProductName,
                        Brand = item.BrandID

                    };
                    productResponse.Products.Add(productModel);
                }

                int allProductCount = _repositoryProduct.Get().Where(t => request.CategoryID == 0 || t.CategoryID == request.CategoryID).Where(t => request.BrandID == 0 || t.BrandID == request.BrandID).Where(t => string.IsNullOrEmpty(request.Color) || t.Color == request.Color).Skip(index).Take(request.Range).Count();


                var productsColor = _repositoryProduct.Get().Where(t => request.CategoryID == 0 || t.CategoryID == request.CategoryID).Where(t => request.BrandID == 0 || t.BrandID == request.BrandID).Where(t => string.IsNullOrEmpty(request.Color) || t.Color == request.Color).GroupBy(t => t.Color).Select(p => new { Color = p.Key, Count = p.Count() }).ToList();
                foreach (var item in productsColor)
                {
                    if (item.Color != null)
                    {
                        productResponse.ProductsColor.Add(item.Color, item.Count);
                    }
                }


                var productsBrand = _repositoryProduct.Get().Where(t => request.CategoryID == 0 || t.CategoryID == request.CategoryID).Where(t => request.BrandID == 0 || t.BrandID == request.BrandID).Where(t => string.IsNullOrEmpty(request.Color) || t.Color == request.Color).GroupBy(t => new { t.Brand.ID, t.Brand.Name }).Select(p => new { ID = p.Key.ID, Brand = p.Key.Name, Count = p.Count() }).ToList();
                foreach (var item in productsBrand)
                {
                    if (item.Brand != null)
                    {
                        productResponse.ProductsBrand.Add(new BrandFilterModel
                        {
                            BrandID = item.ID,
                            BrandName = item.Brand,
                            ProductCount = item.Count
                        });
                    }
                }

                productResponse.PagingInfo = new PagingInfo(request.Page, request.Range, allProductCount);
                productResponse.SetStatus(Constants.ResponseCode.SUCCESS);
                return productResponse;
            }
            catch (Exception ex)
            {
                productResponse.Products = null;
                productResponse.SetStatus(Constants.ResponseCode.FAILED_ON_DB_PROCESS, ex.Message);
                return productResponse;
            }
        }

        public ProductModelResponse GetSpecialProducts(GetSpecialProductRequest request)
        {

            //1 spacialid indirimdeki ürünler sliderına karsılık gelsın --->
            ProductModelResponse productResponse = new ProductModelResponse();
            try
            {

                SpacialArea spacialArea = _repositorySpacial.Get(t => t.ID == request.SpacialID).FirstOrDefault();

                if (spacialArea == null)
                {
                    productResponse.Products = null;
                    productResponse.SetStatus(Constants.ResponseCode.NOT_FOUND_ENTITY);
                    return productResponse;
                }

                int index = (request.PageNumber - 1) * request.Count;//dbde kac kayıt es gecılmeli
                List<ProductSpacialAreaTable> spacialAreaProducts = _repositorySpacialTable.Get(t => t.SpacialAreaID == spacialArea.ID).Include(t => t.Product).Skip(index).Take(request.Count).ToList();

                if (spacialAreaProducts == null)
                {
                    productResponse.Products = null;
                    productResponse.SetStatus(Constants.ResponseCode.NOT_FOUND_ENTITY);
                    return productResponse;
                }

                List<ProductModel> productList = new List<ProductModel>();
                foreach (ProductSpacialAreaTable item in spacialAreaProducts)
                {
                    productList.Add(new ProductModel
                    {
                        ID = item.Product.ID,
                        Description = item.Product.Description,
                        Price = item.Product.Price,
                        ProductImages = item.Product.ProductImages.Select(t => t.URLFromAway).ToList(),
                        ProductName = item.Product.ProductName,
                        Brand = item.Product.BrandID
                    });
                }
                productResponse.Products = productList;

                int allcount = _repositorySpacialTable.Get(t => t.SpacialAreaID == spacialArea.ID).Count();
                productResponse.PagingInfo = new PagingInfo(request.PageNumber, request.Count, allcount);
                productResponse.SetStatus(Constants.ResponseCode.SUCCESS);
                return productResponse;
            }
            catch (Exception ex)
            {
                productResponse.Products = null;
                productResponse.SetStatus(Constants.ResponseCode.FAILED_ON_DB_PROCESS, ex.Message);
                return productResponse;
            }
        }

        public BannerResponse GetBanners()
        {
            BannerResponse bannerResponse = new BannerResponse();

            try
            {
                bannerResponse.BannersImages = _repositoryBanner.Get().OrderByDescending(t => t.ID).Take(Constants.BANNERCOUNT).ToList();

                if (bannerResponse != null)
                {
                    bannerResponse.SetStatus(Constants.ResponseCode.SUCCESS);
                    return bannerResponse;
                }
                //b// 2kdk discorda gel daha hızlı ilerleriz bende cıkıcam az sonra 
                bannerResponse.SetStatus(Constants.ResponseCode.SYSTEM_ERROR);
                return bannerResponse;
            }
            catch (Exception ex)
            {

                bannerResponse.BannersImages = null;
                bannerResponse.SetStatus(Constants.ResponseCode.FAILED_ON_DB_PROCESS, ex.Message);
                return bannerResponse;
            }

        }
        public ProductModelResponse GetRandomProducts(GetProductRequest request)
        {

            ProductModelResponse response = new ProductModelResponse();
            try
            {
                int count = _repositoryProduct.Get(t => t.CategoryID == request.CategoryID).Count();
                List<int> randoms = new List<int>();
                for (int i = 0; i < request.Range; i++)
                {
                    randoms.Add(RandomGenerator(count, randoms));
                }
                for (int i = 0; i < request.Range; i++)
                {
                    Product product = _repositoryProduct.Get(t => t.CategoryID == request.CategoryID).OrderBy(t => t.ID).Skip(randoms[i]).Take(1).SingleOrDefault();
                    response.Products.Add(new ProductModel
                    {
                        ID = product.ID,
                        Description = product.Description,
                        Price = product.Price,
                        ProductImages = product.ProductImages.Select(t => t.URLFromAway).ToList(),
                        ProductName = product.ProductName,
                        Brand = product.BrandID
                    });
                }

                response.SetStatus(Constants.ResponseCode.SUCCESS);
                return response;
            }
            catch (Exception)
            {

                response.SetStatus(Constants.ResponseCode.FAILED_ON_DB_PROCESS);
                return response;
            }

        }
        private int RandomGenerator(int max, List<int> list)
        {
            Random random = new Random();
            int temp;
            temp = random.Next(0, max);
            if (list.Contains(temp))
                RandomGenerator(max, list);
            return temp;
        }
        public SameBrandProductsResponse GetSameBrandProducts(int BrandID)
        {
            SameBrandProductsResponse response = new SameBrandProductsResponse();
            try
            {
                List<Product> products = _repositoryProduct.Get(t => t.BrandID == BrandID).ToList();

                foreach (var product in products)
                {
                    response.Products.Add(new ProductModel
                    {
                        ID = product.ID,
                        Description = product.Description,
                        Price = product.Price,
                        ProductImages = product.ProductImages.Select(t => t.URLFromAway).ToList(),
                        ProductName = product.ProductName,
                        Brand = product.BrandID
                    });
                }

                response.SetStatus(Constants.ResponseCode.SUCCESS);
                return response;
            }
            catch (Exception ex)
            {
                response.Products = null;
                response.SetStatus(Constants.ResponseCode.FAILED_ON_DB_PROCESS, ex.Message);
                return response;
            }

        }
        public ProductModelResponse SearchforProducts(string searchText) {

            ProductModelResponse response = new ProductModelResponse();
            try
            {
                var products = _repositoryProduct.Get(t => t.ProductName.Contains(searchText)).ToList();

                foreach (Product item in products)
                {

                    ProductModel productModel = new ProductModel
                    {
                        ID = item.ID,
                        Description = item.Description,
                        Price = item.Price,
                        ProductImages = item.ProductImages.Select(t => t.URLFromAway).ToList(),
                        ProductName = item.ProductName,
                        Brand = item.BrandID

                    };
                    response.Products.Add(productModel);
                }


                response.SetStatus(Constants.ResponseCode.SUCCESS);
                return response;
            }
            catch (Exception ex)
            {
                response.Products = null;
                response.SetStatus(Constants.ResponseCode.FAILED_ON_DB_PROCESS, ex.Message);
                return response;
            }

          
        }


    }
}
