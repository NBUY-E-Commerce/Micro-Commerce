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
        SpecialAreaResponse Delete(int ID);
        SpecialAreaResponse Update(SpacialArea SpacialArea);
        SpecialAreaResponse GetSpecialAreas();
    }
}
