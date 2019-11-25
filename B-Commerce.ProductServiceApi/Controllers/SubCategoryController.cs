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
    public class SubCategoryController : ControllerBase
    {
        ISubCategoryService _subService;
        public SubCategoryController(ISubCategoryService subCategoryService)
        {
            _subService = subCategoryService;
        }

        [HttpGet]
        [Route("/[controller]/Categories")]
        public IActionResult GetSubCategories() {
            QueryableBaseResponse<SubCategory> result = null;
            try
            {
                result = _subService.GetSubCategories();
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
        [Route("/[controller]/Categories/{id}")]
        public IActionResult GetSubCategoryById(int Id)
        {
            QueryableBaseResponse<SubCategory> result = null;
            try
            {
                result = _subService.GetSubCategoryById(Id);
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
        [Route("/[controller]/Categories/Master/{id}")]
        public IActionResult GetSubCategoryByMasterId(int Id)
        {
            QueryableBaseResponse<SubCategory> result = null;
            try
            {
                result = _subService.GetSubCategoryByMasterId(Id);
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