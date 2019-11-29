﻿using B_Commerce.ProductService.DomainClasses;
using B_Commerce.ProductService.Response;
using System;
using System.Collections.Generic;
using System.Text;

namespace B_Commerce.ProductService.Service.Abstract
{
    public interface ICategoryService
    {
        BaseResponse Add(Category category);
        BaseResponse Delete(Category category);
        BaseResponse Update(Category category);
        CategoryResponse GetCategories();
        CategoryResponse GetMasterCategories();
        CategoryResponse GetSubCategoriesByCategoryID(int id);
    }
}
