using B_Commerce.ProductService.DomainClasses;
using B_Commerce.ProductService.Request;
using B_Commerce.ProductService.Response;
using System;
using System.Collections.Generic;
using System.Text;

namespace B_Commerce.ProductService.Service.Abstract
{
    public interface IProductService
    {
        BaseResponse Add(Product product);
        BaseResponse Update(Product product);
        BaseResponse Delete(Product product);
        ProductModelResponse GetProducts(GetProductRequest request);
        ProductModelResponse GetSpecialProducts(GetSpecialProductRequest request);
        GetProductModelResponse GetProductByID(int ID);
        BannerResponse GetBanners();
        SameBrandProductsResponse GetSameBrandProducts(int BrandID);
        ProductModelResponse GetRandomProducts(GetProductRequest request);
    }
}
