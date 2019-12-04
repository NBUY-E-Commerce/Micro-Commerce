

namespace B_Commerce.LogService.Services.Response
{
    public class EntityResponse<T>:BaseResponse where T:class
    {
        public T Entity;
    }
}
