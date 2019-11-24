using B_Commerce.ProductService.DomainClasses;
using B_Commerce.ProductService.Response;
using System;
using System.Collections.Generic;
using System.Text;

namespace B_Commerce.ProductService.Services.Abstracts
{
    public interface IProductImageService
    {
        QueryableBaseResponse<ProductImage> GetImagesByProductId(int id);
    }
}
