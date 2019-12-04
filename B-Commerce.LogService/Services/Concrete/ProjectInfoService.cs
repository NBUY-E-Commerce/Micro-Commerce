using B_Commerce.Common.Repository;
using B_Commerce.Common.UOW;
using B_Commerce.LogService.DomainClasses;
using B_Commerce.LogService.Services.Abstract;
using B_Commerce.LogService.Services.Response;
using System;
using System.Linq;
using System.Linq.Expressions;
using static B_Commerce.LogService.Common.Constants;

namespace B_Commerce.LogService.Services.Concrete
{
    public class ProjectInfoService : IProjectInfoService
    {
        private IRepository<ProjectInfo> _repository;
        private IUnitOfWork _unitOfWork;

        public ProjectInfoService(IRepository<ProjectInfo> repository, IUnitOfWork unitOfWork)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
        }
        public BaseResponse Add(ProjectInfo projectInfo)
        {
            BaseResponse baseResponse = new BaseResponse();
            try
            {
                _repository.Add(projectInfo);
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

        public BaseResponse Delete(ProjectInfo projectInfo)
        {
            BaseResponse baseResponse = new BaseResponse();
            try
            {
                _repository.Delete(projectInfo);
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

        public EntityListResponse<ProjectInfo> Get(Expression<Func<ProjectInfo, bool>> filter = null)
        {
            EntityListResponse<ProjectInfo> serviceResponse = new EntityListResponse<ProjectInfo>();
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

        public int GetIdByCode(string projectCode)
        {
            return _repository.Get(t=>t.ProjectCode==projectCode).Select(t=>t.ID).FirstOrDefault();
        }

        public BaseResponse Update(ProjectInfo projectInfo)
        {
            BaseResponse baseResponse = new BaseResponse();
            try
            {
                _repository.Update(projectInfo);
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
