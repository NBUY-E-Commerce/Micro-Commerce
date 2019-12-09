using B_Commerce.SMVC.Areas.Admin.Models;
using B_Commerce.SMVC.WebApiReqRes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace B_Commerce.SMVC.Models
{
    public class CategoryShortInfoResponse : CommonResponse
    {
        public List<CategoryShortInfo> CategoryShortInfos { get; set; }
    }
}