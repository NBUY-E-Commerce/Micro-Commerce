using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
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
    public class MasterCategoryController : ControllerBase
    {
        IMasterCategoryService _masterService;
        public MasterCategoryController(IMasterCategoryService masterCategoryService) {
            _masterService = masterCategoryService;
        }
      
        [HttpGet]
        [Route("/[controller]/Categories")]
        public IActionResult GetCategories() {
            QueryableBaseResponse<MasterCategory> result=null;
            try
            {
                 result = _masterService.GetMasterCategories();
                if (result.code == ResponseCode.SUCCESS)
                {
                    return Ok(result.queryableResponse);
                }
                else {
                    return BadRequest();
                }
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpGet]
        [Route("/[controller]/Category/{id}")]
        public IActionResult GetCategoryByID(int id)
        {
            QueryableBaseResponse<MasterCategory> result = null;
            try
            {
                result = _masterService.GetMasterCategoryById(id);
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