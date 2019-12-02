using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using B_Commerce.ProductService.Api.DTO;
using B_Commerce.ProductService.Common;
using B_Commerce.ProductService.DomainClasses;
using B_Commerce.ProductService.Response;
using B_Commerce.ProductService.Service.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace B_Commerce.ProductService.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : Controller
    {
        ICategoryService _service;
        public CategoryController(ICategoryService service)
        {
            _service = service;
        }

        [HttpGet]
        [Route("Add")]
        public IActionResult Add(CategoryDTO category)
        {
            Category newcategory = new Category
            {
                CategoryName = category.CategoryName,
                Description = category.Description,
                isActive = category.isActive,
                MasterCategoryID = category.MasterCategoryID
            };
            BaseResponse response = _service.Add(newcategory);
            return response.Code != (int)Constants.ResponseCode.SUCCESS ? StatusCode(500, response) : StatusCode(201, response);
        }

        [HttpGet]
        [Route("Delete")]
        public IActionResult Delete(int id)
        {
            Category newcategory = new Category
            {
                ID=id
            };
            BaseResponse response = _service.Delete(newcategory);
            return response.Code != (int)Constants.ResponseCode.SUCCESS ? StatusCode(500, response) : StatusCode(200, response);
        }

        [HttpGet]
        [Route("Update")]
        public IActionResult Update(Category category)
        {
            Category updatecategory = new Category
            {
                ID=category.ID,
                CategoryName = category.CategoryName,
                Description = category.Description,
                isActive = category.isActive,
                MasterCategoryID = category.MasterCategoryID
            };
            BaseResponse response = _service.Update(updatecategory);
            return response.Code != (int)Constants.ResponseCode.SUCCESS ? StatusCode(500, response) : StatusCode(200, response);
        }

        [HttpGet]
        [Route("GetCategories")]
        public IActionResult GetCategories()
        {
            CategoryResponse response = _service.GetCategories();
            return response.Code != (int)Constants.ResponseCode.SUCCESS ? StatusCode(500, response) : StatusCode(200, response);
        }

        [HttpGet]
        [Route("GetMasterCategories")]
        public IActionResult GetMasterCategories()
        {
            CategoryResponse response = _service.GetMasterCategories();
            return response.Code != (int)Constants.ResponseCode.SUCCESS ? StatusCode(500, response) : StatusCode(200, response);
        }

        [HttpPost]
        [Route("GetSubCategoriesByCategoryID")]
        public IActionResult GetSubCategoriesByCategoryID(int id)
        {
            CategoryModelResponse response = _service.GetSubCategoriesByCategoryID(id);
            return response.Code != (int)Constants.ResponseCode.SUCCESS ? StatusCode(500, response) : StatusCode(200, response);
        }
    }
}
