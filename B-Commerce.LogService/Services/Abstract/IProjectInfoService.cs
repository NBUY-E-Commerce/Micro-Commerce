
using B_Commerce.LogService.DomainClasses;
using B_Commerce.LogService.Services.Response;
using System;
using System.Linq.Expressions;

namespace B_Commerce.LogService.Services.Abstract
{
    public interface IProjectInfoService
    {
        BaseResponse Add(ProjectInfo projectInfo);
        BaseResponse Delete(ProjectInfo projectInfo);
        BaseResponse Update(ProjectInfo projectInfo);

        EntityListResponse<ProjectInfo> Get(Expression<Func<ProjectInfo, bool>> filter = null);
        int GetIdByCode(string projectCode);
    }
}
