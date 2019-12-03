using B_Commerce.ProductService.DomainClasses;
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

        ProductModelResponse GetProducts(int? page,int range);
        ProductResponse GetSpecialProducts(int spacialID, int? page, int range);
        ProductModelResponse GetProductsByCategoryID(int categoryID, int? index, int count);
    }
}
