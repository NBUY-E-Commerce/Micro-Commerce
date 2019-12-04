using System.Collections.Generic;

namespace B_Commerce.LogService.Services.Response
{
    public class EntityListResponse<T>:BaseResponse where T:class
    {
        public List<T> EntityList { get; set; }
    }
}
