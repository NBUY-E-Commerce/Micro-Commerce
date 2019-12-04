using B_Commerce.Common.Repository;
using B_Commerce.Common.UOW;
using B_Commerce.LogService.DomainClasses;
using B_Commerce.LogService.Services.Abstract;
using B_Commerce.LogService.Services.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using static B_Commerce.LogService.Common.Constants;

namespace B_Commerce.LogService.Services.Concrete
{
    public class ProjectOwnerService : IProjectOwnerService
    {
        private IRepository<ProjectOwner> _repository;
        private IUnitOfWork _unitOfWork;

        public ProjectOwnerService(IRepository<ProjectOwner> repository, IUnitOfWork unitOfWork)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
        }
        public BaseResponse Add(ProjectOwner projectOwner)
        {
            BaseResponse baseResponse = new BaseResponse();
            try
            {
                _repository.Add(projectOwner);
                _unitOfWork.SaveChanges();
                baseResponse.SetStatus(ResponseCode.SUCCESS);
                return baseResponse;
            }
            catch (Exception ex)
            {

                baseResponse.SetStatus(ResponseCode.FAILED_ON_DB_PROCESS, ex.Message);
                return baseResponse;
            }
        }

        public BaseResponse Delete(ProjectOwner projectOwner)
        {
            BaseResponse baseResponse = new BaseResponse();
            try
            {
                _repository.Delete(projectOwner);
                _unitOfWork.SaveChanges();
                baseResponse.SetStatus(ResponseCode.SUCCESS);
                return baseResponse;
            }
            catch (Exception ex)
            {

                baseResponse.SetStatus(ResponseCode.FAILED_ON_DB_PROCESS, ex.Message);
                return baseResponse;
            }
        }

        public EntityListResponse<ProjectOwner> Get(Expression<Func<ProjectOwner, bool>> filter = null)
        {
            EntityListResponse<ProjectOwner> serviceResponse = new EntityListResponse<ProjectOwner>();
            try
            {
                serviceResponse.EntityList = _repository.Get(filter).ToList();
                serviceResponse.SetStatus(ResponseCode.SUCCESS);
                return serviceResponse;
            }
            catch (Exception)
            {

                serviceResponse.SetStatus(ResponseCode.SYSTEM_ERROR);
                return serviceResponse;
            }
        }

        

        public EntityResponse<ProjectOwner> GetByProjectCode(string code)
        {
            EntityResponse<ProjectOwner> entiyResponse = new EntityResponse<ProjectOwner>();
     
            try
            {
                entiyResponse.Entity = _repository.Get(t => t.ProjectInfo.ProjectCode ==code).FirstOrDefault();
                entiyResponse.SetStatus(ResponseCode.SUCCESS);
                return entiyResponse;
            }
            catch (Exception)
            {

                entiyResponse.SetStatus(ResponseCode.SYSTEM_ERROR);
                return entiyResponse;
            }
        }

        public BaseResponse Update(ProjectOwner projectOwner)
        {
            BaseResponse baseResponse = new BaseResponse();
            try
            {
                _repository.Update(projectOwner);
                _unitOfWork.SaveChanges();
                baseResponse.SetStatus(ResponseCode.SUCCESS);
                return baseResponse;
            }
            catch (Exception ex)
            {

                baseResponse.SetStatus(ResponseCode.FAILED_ON_DB_PROCESS, ex.Message);
                return baseResponse;
            }
        }
    }
}
