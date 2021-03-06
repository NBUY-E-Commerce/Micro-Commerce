﻿using System;
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
            response = _service.Add(shoppingCartProduct.Token, shoppingCartProduct.UserID, shoppingCartProduct.ProductID, shoppingCartProduct.ProductCount);
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
        public IActionResult UpdateProductCountOfShoppingCart(List<UpdateProductCountDTO> parameters)
        {
            ShoppingCartResponse response = new ShoppingCartResponse();
            foreach (UpdateProductCountDTO item in parameters)
            {
                response = _service.UpdateProductCountOfShoppingCart(item.Token, item.ProductID, item.NewCount);
                if (response.Code != 0)
                {
                    return StatusCode(500, response);
                }
            }

            return response.Code != (int)Constants.ResponseCode.SUCCESS ? StatusCode(500, response) : StatusCode(200, response);
        }

        [HttpPost]
        [Route("CartEqualizer")]
        public IActionResult CartEqualizer(CartEqualizerModel cartEqualizer)
        {
            BaseResponse baseResponse = _service.CartEqualizer(cartEqualizer.vToken, cartEqualizer.uToken);
                return baseResponse.Code != (int)Constants.ResponseCode.SUCCESS ? StatusCode(500, baseResponse) : StatusCode(200, baseResponse);
        }


    }
}