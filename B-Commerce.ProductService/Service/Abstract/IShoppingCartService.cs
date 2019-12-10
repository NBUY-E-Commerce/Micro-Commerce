using B_Commerce.ProductService.DomainClasses;
using B_Commerce.ProductService.Response;
using System;
using System.Collections.Generic;
using System.Text;

namespace B_Commerce.ProductService.Service.Abstract
{
    public interface IShoppingCartService
    {
        ShoppingCartResponse Add(string token, int userid, int productid, int count);
        ShoppingCartResponse GetShoppingCartofUser(string token);
        ShoppingCartResponse UpdateProductCountOfShoppingCart(string token, int productid, int newcount);

    }
}
