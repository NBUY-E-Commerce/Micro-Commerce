using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using B_Commerce.ProductService.Api.DTO;
using B_Commerce.ProductService.Common;
using B_Commerce.ProductService.DomainClasses;
using B_Commerce.ProductService.Response;
using B_Commerce.ProductService.Service.Abstract;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace B_Commerce.ProductService.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class ShoppingCartProductController : ControllerBase
    {
        IShoppingCartProductService _service;

        public ShoppingCartProductController(IShoppingCartProductService service)
        {
            _service = service;
        }

        [HttpPost]
        [Route("Add")]
        public IActionResult Add(ShoppingCartProductDTO shoppingCartProduct)
        {

            BaseResponse response = new BaseResponse();

            ShoppingCartProduct newshoppingCartProduct = new ShoppingCartProduct
            {
                ShoppingCartID = shoppingCartProduct.ShoppingCartID,
                ProductID = shoppingCartProduct.ProductID,
                ProductCount = shoppingCartProduct.ProductCount,
                Product = shoppingCartProduct.Product,
                ShoppingCart = shoppingCartProduct.ShoppingCart
            };
            response = _service.Add(newshoppingCartProduct);
            return response.Code != (int)Constants.ResponseCode.SUCCESS ? StatusCode(500, response) : StatusCode(201, response);
        }

        [HttpPost]
        [Route("GetShoppingCartofUser")]
        public IActionResult GetShoppingCartofUser([FromBody]int ID)
        {
            ShoppingCartProductResponse response = _service.GetShoppingCartofUser(ID);
            return response.Code != (int)Constants.ResponseCode.SUCCESS ? StatusCode(500, response) : StatusCode(200, response);
        }

       
    }
}