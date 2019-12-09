using B_Commerce.ProductService.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace B_Commerce.ProductService.Api.DTO
{
    public class CategoryDTOResponse : BaseResponse
    {
        public CategoryDTO Category { get; set; }
    }
}
