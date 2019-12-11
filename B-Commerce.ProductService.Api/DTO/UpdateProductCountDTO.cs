using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace B_Commerce.ProductService.Api.DTO
{
    public class UpdateProductCountDTO
    {
        public string Token { get; set; }
        public int ProductID { get; set; }
        public int NewCount { get; set; }
    }

    public class UpdateProductCountListRequest
    {
        public List<UpdateProductCountDTO> UpdateProductCounts { get; set; }
    }
}
