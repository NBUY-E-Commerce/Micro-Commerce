using B_Commerce.ProductService.DomainClasses;
using B_Commerce.ProductService.Response;
using System;
using System.Collections.Generic;
using System.Text;

namespace B_Commerce.ProductService.Service.Abstract
{
    public interface ISpecialAreaService
    {
        BaseResponse Add(SpacialArea SpacialArea);
        BaseResponse Delete(int ID);
        BaseResponse Update(SpacialArea SpacialArea);
        SpecialAreaResponse GetSpecialAreas();
    }
}
