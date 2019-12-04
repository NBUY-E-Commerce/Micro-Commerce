

using B_Commerce.LogService.DomainClasses;
using B_Commerce.LogService.Services.Response;
using System;
using System.Linq.Expressions;

namespace B_Commerce.LogService.Services.Abstract
{
    public interface IProjectOwnerService
    {
        BaseResponse Add(ProjectOwner projectOwner);
        BaseResponse Delete(ProjectOwner projectOwner);
        BaseResponse Update(ProjectOwner projectOwner);

        EntityListResponse<ProjectOwner> Get(Expression<Func<ProjectOwner, bool>> filter = null);
        EntityResponse<ProjectOwner> GetByProjectCode(string code);
    }
}
