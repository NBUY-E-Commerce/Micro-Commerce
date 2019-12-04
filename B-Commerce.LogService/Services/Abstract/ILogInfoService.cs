using B_Commerce.LogService.DomainClasses;
using B_Commerce.LogService.Services.Response;
using System;
using System.Linq.Expressions;

namespace B_Commerce.LogService.Services.Abstract
{
    public interface ILogInfoService
    {
        BaseResponse Add(LogInfo logInfo);
        BaseResponse Delete(LogInfo logInfo);
        BaseResponse Update(LogInfo logInfo);

        EntityListResponse<LogInfo> Get(Expression<Func<LogInfo, bool>> filter = null);
    }
}
