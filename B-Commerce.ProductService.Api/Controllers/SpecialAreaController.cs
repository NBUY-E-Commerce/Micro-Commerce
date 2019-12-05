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
    [ApiController]
    [Route("api/[controller]")]
    public class SpecialAreaController : Controller
    {
        ISpecialAreaService _specialAreaService;
        public SpecialAreaController(ISpecialAreaService specialAreaService)
        {
            _specialAreaService = specialAreaService;
        }

        [HttpPost]
        [Route("Add")]
        public IActionResult Add(SpecialAreaDTO spacialArea)
        {
            SpacialArea specialArea = new SpacialArea
            {
                Name = spacialArea.Name,
                Description = spacialArea.Description
            };
            SpecialAreaResponse response = _specialAreaService.Add(specialArea);
            return response.Code != (int)Constants.ResponseCode.SUCCESS ? StatusCode(500, response) : StatusCode(201, response);
        }

        [HttpPost]
        [Route("Delete")]
        public IActionResult Delete(int ID)
        {
            SpecialAreaResponse response = _specialAreaService.Delete(ID);
            return response.Code != (int)Constants.ResponseCode.SUCCESS ? StatusCode(500, response) : StatusCode(200, response);
        }

        [HttpPost]
        [Route("Update")]
        public IActionResult Update(SpecialAreaDTO SpacialArea)
        {
            SpacialArea sa = new SpacialArea
            {
                ID= (int)SpacialArea.ID,
                Name = SpacialArea.Name,
                Description = SpacialArea.Description
            };
            SpecialAreaResponse response = _specialAreaService.Update(sa);
            return response.Code != (int)Constants.ResponseCode.SUCCESS ? StatusCode(500, response) : StatusCode(200, response);
        }

        [HttpPost]
        [Route("GetSpecialAreas")]
        public IActionResult GetSpecialAreas()
        {
            SpecialAreaResponse response = _specialAreaService.GetSpecialAreas();
            return response.Code != (int)Constants.ResponseCode.SUCCESS ? StatusCode(500, response) : StatusCode(200, response);
        }
    }
}