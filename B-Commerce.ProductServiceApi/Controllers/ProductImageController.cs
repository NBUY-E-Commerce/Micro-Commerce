using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using B_Commerce.ProductService.DomainClasses;
using B_Commerce.ProductService.Response;
using B_Commerce.ProductService.Services.Abstracts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using static B_Commerce.ProductService.Common.Constants;

namespace B_Commerce.ProductServiceApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductImageController : ControllerBase
    {
        IProductImageService _productImageService;
        public ProductImageController(IProductImageService productImageService) {
            _productImageService = productImageService;
        }
        [HttpGet]
        [Route("/[controller]/Images/{id}")]
        public IActionResult GetImagesByProductId(int id) {
            QueryableBaseResponse<ProductImage> result = null;
            try
            {

                result = _productImageService.GetImagesByProductId(id);
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