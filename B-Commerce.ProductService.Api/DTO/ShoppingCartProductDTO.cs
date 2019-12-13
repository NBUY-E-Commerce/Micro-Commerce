using B_Commerce.ProductService.DomainClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace B_Commerce.ProductService.Api.DTO
{
    public class ShoppingCartProductDTO
    {
        public string Token { get; set; }
        public int ProductID { get; set; }
        public int UserID { get; set; }
        public int ProductCount { get; set; }
    }
}
