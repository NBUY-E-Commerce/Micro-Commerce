using B_Commerce.Common.Repository;
using LogService.DomainClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LogService.Services.Abstract
{
    public interface IProjectOwnerService:IRepository<ProjectOwner>
    {
    }
}
