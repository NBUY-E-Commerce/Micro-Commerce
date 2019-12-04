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
        ProductModelResponse GetProductsColor(int categoryID);
        ProductModelResponse GetProductsColor(int categoryID, string color);
        ProductModelResponse GetSpecialProducts(GetSpecialProductRequest request);

        BannerResponse GetBanners();
    }
}
