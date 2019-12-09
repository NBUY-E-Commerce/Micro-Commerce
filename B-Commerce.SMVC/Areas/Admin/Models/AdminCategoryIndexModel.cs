using B_Commerce.SMVC.Models;
using B_Commerce.SMVC.WebApiReqRes.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace B_Commerce.SMVC.Areas.Admin.Models
{
    public class AdminCategoryIndexModel
    {
        public AdminCategoryIndexModel()
        {
            CategoryAddRequest = new CategoryAddRequest();
            CategoryModelResponse = new CategoryModelResponse();
        }
        public CategoryAddRequest CategoryAddRequest { get; set; }
        public CategoryUpdateRequest CategoryUpdateRequest { get; set; }
        public CategoryModelResponse CategoryModelResponse { get; set; }
    }
}