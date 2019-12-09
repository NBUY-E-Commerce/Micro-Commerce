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

        [HttpPost]
        [Route("Add")]
        public IActionResult Add(CategoryDTO category)
        {
            if (category.MasterCategoryID == 0) category.MasterCategoryID = null;
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

        [HttpPost]
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

        [HttpPost]
        [Route("Update")]
        public IActionResult Update(CategoryDTO category)
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

        [HttpPost]
        [Route("GetByID")]
        public IActionResult GetByID([FromBody]int id)
        {
            CategoryResponse categoryResponse = _service.GetByID(id);

            CategoryDTO categoryDTO = new CategoryDTO { 
            ID = categoryResponse.Category.ID,
            CategoryName = categoryResponse.Category.CategoryName,
            Description = categoryResponse.Category.Description,
            isActive = categoryResponse.Category.isActive,
            MasterCategoryID = categoryResponse.Category.MasterCategoryID
            };

            CategoryDTOResponse response = new CategoryDTOResponse
            {
                Code = categoryResponse.Code,
                ExceptionMessage = categoryResponse.ExceptionMessage,
                Message = categoryResponse.Message
            };

            response.Category = categoryDTO;

            return response.Code != (int)Constants.ResponseCode.SUCCESS ? StatusCode(500, response) : StatusCode(201, response);
        }

        [HttpPost]
        [Route("GetSubCategoriesByCategoryID")]
        public IActionResult GetSubCategoriesByCategoryID([FromBody]int id)
        {
            CategoryModelResponse response = _service.GetSubCategoriesByCategoryID(id);
            return response.Code != (int)Constants.ResponseCode.SUCCESS ? StatusCode(500, response) : StatusCode(200, response);
        }

        [HttpPost]
        [Route("GetCategoryShortInfo")]
        public IActionResult GetCategoryShortInfo()
        {
            CategoryShortInfoResponse response = new CategoryShortInfoResponse();
            response.CategoryShortInfos = _service.GetCategoriesWithShortInfo();

            return response.Code != (int)Constants.ResponseCode.SUCCESS ? StatusCode(500, response) : StatusCode(200, response);
        }
    }
}
