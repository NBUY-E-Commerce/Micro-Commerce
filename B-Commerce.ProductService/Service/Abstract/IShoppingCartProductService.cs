using B_Commerce.ProductService.DomainClasses;
using B_Commerce.ProductService.Response;
using System;
using System.Collections.Generic;
using System.Text;

namespace B_Commerce.ProductService.Service.Abstract
{
   public interface IShoppingCartProductService
    {
        BaseResponse Add(ShoppingCartProduct shoppingCartProduct);
        ShoppingCartProductResponse GetShoppingCartofUser(int ID);

    }
}
