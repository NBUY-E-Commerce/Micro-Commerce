using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using B_Commerce.ProductService.Api.DTO;
using B_Commerce.ProductService.Common;
using B_Commerce.ProductService.DomainClasses;
using B_Commerce.ProductService.Request;
using B_Commerce.ProductService.Response;
using B_Commerce.ProductService.Service.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace B_Commerce.ProductService.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductController : Controller
    {
        IProductService _service;
        public ProductController(IProductService service)
        {
            _service = service;
        }
        [HttpPost]
        [Route("Add")]
        public IActionResult Add(ProductDTO product)
        {

            BaseResponse response = new BaseResponse();

            Product newproduct = new Product
            {
                ProductName = product.ProductName,
                Description = product.Description,
                Price = product.Price,
                Size = product.Size,
                Color = product.Color,
                AvailableCount = product.AvailableCount,
                isActive = product.isActive,
                CategoryID = product.CategoryID
            };

            foreach (string item in product.ImageUrls)
            {
                newproduct.ProductImages.Add(new ProductImage
                {
                    URL = item,
                    Description = ""
                });
            }

            foreach (var item in product.SpecialAreas)
            {
                newproduct.productSpacialAreas.Add(new ProductSpacialAreaTable { SpacialAreaID = item }); // TODO ?
            }



            response = _service.Add(newproduct);
            return response.Code != (int)Constants.ResponseCode.SUCCESS ? StatusCode(500, response) : StatusCode(201, response);
        }

        [HttpPost]
        [Route("Update")]
        public IActionResult Update(ProductDTO product)
        {
            Product newproduct = new Product
            {
                ID = (int)product.ID,
                ProductName = product.ProductName,
                Description = product.Description,
                Price = product.Price,
                Size = product.Size,
                Color = product.Color,
                AvailableCount = product.AvailableCount,
                isActive = product.isActive,
                CategoryID = product.CategoryID
            };
            BaseResponse response = _service.Update(newproduct);
            return response.Code != (int)Constants.ResponseCode.SUCCESS ? StatusCode(500, response) : StatusCode(200, response);
        }

        [HttpPost]
        [Route("Delete")]
        public IActionResult Delete(int id)
        {
            Product newproduct = new Product
            {
                ID = id
            };
            BaseResponse response = _service.Delete(newproduct);
            return response.Code != (int)Constants.ResponseCode.SUCCESS ? StatusCode(500, response) : StatusCode(200, response);
        }

        [HttpPost]
        [Route("GetProducts")]
        public IActionResult GetProducts(GetProductRequest request)
        {
            ProductModelResponse response = _service.GetProducts(request);
            return response.Code != (int)Constants.ResponseCode.SUCCESS ? StatusCode(500, response) : StatusCode(200, response);
        }

        [HttpPost]
        [Route("GetBanners")]
        public IActionResult GetBanners()
        {

            BannerResponse response = _service.GetBanners();
            return response.Code != (int)Constants.ResponseCode.SUCCESS ? StatusCode(500, response) : StatusCode(200, response);
        }

        [HttpPost]
        [Route("GetSpecialProducts")]
        public IActionResult GetSpecialProducts(GetSpecialProductRequest request)
        {
            BaseResponse response = _service.GetSpecialProducts(request);
            return response.Code != (int)Constants.ResponseCode.SUCCESS ? StatusCode(500, response) : StatusCode(200, response);
        }

    }
}