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

    public class ShoppingCartController : ControllerBase
    {
        IShoppingCartService _service;

        public ShoppingCartController(IShoppingCartService service)
        {
            _service = service;
        }

        [HttpPost]
        [Route("Add")]
        public IActionResult Add(ShoppingCartProductDTO shoppingCartProduct)
        {
            //todo : login servise  checktoken ı cagır
            //eğer ilgili token gecersizse login api hata doner bizde sepete ekleme işlemini iptal ederiz.,
            //checktoken başarılı dondugu varsayıp devam ediyoruz. (****eklenecek)
            //checktoken userın idsini donsun
            ShoppingCartResponse response = new ShoppingCartResponse();
            response = _service.Add(shoppingCartProduct.Token, 1, shoppingCartProduct.ProductID, shoppingCartProduct.ProductCount);
            return response.Code != (int)Constants.ResponseCode.SUCCESS ? StatusCode(500, response) : StatusCode(201, response);
        }

        [HttpPost]
        [Route("GetShoppingCartofUser")]
        public IActionResult GetShoppingCartofUser([FromBody]string token)
        {
            ShoppingCartResponse response = _service.GetShoppingCartofUser(token);
            return response.Code != (int)Constants.ResponseCode.SUCCESS ? StatusCode(500, response) : StatusCode(200, response);
        }


        [HttpPost]
        [Route("UpdateProductCountOfShoppingCart")]
        public IActionResult UpdateProductCountOfShoppingCart(UpdateProductCountDTO parameters)
        {
            ShoppingCartResponse response = _service.UpdateProductCountOfShoppingCart(parameters.Token, parameters.ProductID, parameters.NewCount);
            return response.Code != (int)Constants.ResponseCode.SUCCESS ? StatusCode(500, response) : StatusCode(200, response);
        }


    }
}