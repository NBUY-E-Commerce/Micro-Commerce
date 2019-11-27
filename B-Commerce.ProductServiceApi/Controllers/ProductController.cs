using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using B_Commerce.ProductService.DomainClasses;
using B_Commerce.ProductService.Response;
using B_Commerce.ProductService.Services.Abstracts;
using B_Commerce.ProductServiceApi.Models;
using Microsoft.AspNetCore.Mvc;
using static B_Commerce.ProductService.Common.Constants;

namespace B_Commerce.ProductServiceApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        IProductService _productService;

        public ProductController(IProductService productService,
        IProductImageService productImageService) {
            _productService = productService;

        }

        [HttpGet]
        [Route("/[controller]/Products")]
        public IActionResult GetProducts()
        {
            QueryableBaseResponse<Product> result = null;
            
            try
            {
                result = _productService.GetProducts();

                if (result.code == ResponseCode.SUCCESS)
                {
                    return Ok(result.queryableResponse);
                }
                else
                {
                    return BadRequest();
                }
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpGet]
        [Route("/[controller]/Products/{id}")]
        public IActionResult GetProductById(int id) {
            QueryableBaseResponse<Product> result = null;
            try
            {
                result = _productService.GetProductById(id);
                if (result.code == ResponseCode.SUCCESS)
                {
                    return Ok(result.queryableResponse);
                }
                else
                {
                    return BadRequest();
                }
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpGet]
        [Route("/[controller]/Products/Category/{id}")]
        public IActionResult GetProductsByCategoryId(int id) {
            QueryableBaseResponse<Product> result = null;
            try
            {
                result = _productService.GetProductsByCategoryId(id);
                if (result.code == ResponseCode.SUCCESS)
                {
                    return Ok(result.queryableResponse);
                }
                else
                {
                    return BadRequest();
                }
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpGet]
        [Route("/[controller]/Products/DisplayProducts")]
        public ActionResult GetDisplayProducts() {
            QueryableBaseResponse<Product> result = null;
            try
            {
                result = _productService.GetDisplayProducts();
                if (result.code == ResponseCode.SUCCESS)
                {
                    return Ok(result.queryableResponse);
                }
                else
                {
                    return BadRequest();
                }
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

    }
}