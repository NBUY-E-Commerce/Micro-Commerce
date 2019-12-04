using System;
using System.Collections.Generic;
using System.Text;

namespace B_Commerce.ProductService.Response
{
    public class GetProductModel
    {
        public int? ID { get; set; }
        public string ProductName { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public string Size { get; set; }
        public string Color { get; set; }
        public int AvailableCount { get; set; }
        public bool isActive { get; set; } = true;
        public int CategoryID { get; set; }
        public List<string> ImageUrls { get; set; }
    }

    public class GetProductModelResponse : BaseResponse
    {
        public GetProductModel GetProductModel { get; set; }
    }
}
