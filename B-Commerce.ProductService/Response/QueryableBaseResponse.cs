using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace B_Commerce.ProductService.Response
{
    public class QueryableBaseResponse<T>:BaseResponse
    {

        public IList<T> queryableResponse;
    }
}
