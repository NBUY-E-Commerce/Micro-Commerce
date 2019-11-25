using B_Commerce.ProductService.DomainClasses;
using B_Commerce.ProductService.Response;
using System;
using System.Collections.Generic;
using System.Text;

namespace B_Commerce.ProductService.Services.Abstracts
{
    public interface ISubCategoryService
    {
        QueryableBaseResponse<SubCategory> GetSubCategories();
        QueryableBaseResponse<SubCategory> GetSubCategoryById(int id);
        QueryableBaseResponse<SubCategory> GetSubCategoryByMasterId(int id);
    }
}
