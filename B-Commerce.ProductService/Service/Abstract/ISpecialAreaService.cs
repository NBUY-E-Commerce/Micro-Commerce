using B_Commerce.ProductService.DomainClasses;
using B_Commerce.ProductService.Response;
using System;
using System.Collections.Generic;
using System.Text;

namespace B_Commerce.ProductService.Service.Abstract
{
    public interface ISpecialAreaService
    {
        SpecialAreaResponse Add(SpacialArea SpacialArea);
        BaseResponse Delete(int ID);
        SpecialAreaResponse Update(SpacialArea SpacialArea);
        SpecialAreaResponse GetSpecialAreas();
        ProductSpecialAreaResponse GetProductSpecialAreas();
        ProductSpecialAreaResponse Add(ProductSpacialAreaTable productSpacialAreaTable);
        SpecialAreaResponse GetSpecialAreaByID(int ID);
        BaseResponse AddProductToSpecialByID(int ID);
    }
}
