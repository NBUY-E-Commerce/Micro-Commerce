using B_Commerce.Common.Repository;
using B_Commerce.Common.UOW;
using B_Commerce.LogService.DomainClasses;
using B_Commerce.LogService.Services.Abstract;
using B_Commerce.LogService.Services.Response;
using System;
using System.Linq.Expressions;
using System.Linq;
using static B_Commerce.LogService.Common.Constants;

namespace B_Commerce.LogService.Services.Concrete
{
    public class LogInfoService : ILogInfoService 
    {
        private IRepository<LogInfo> _repository;
        private IUnitOfWork _unitOfWork;

        public LogInfoService(IRepository<LogInfo> repository, IUnitOfWork unitOfWork)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
        }
        public BaseResponse Add(LogInfo logInfo)
        {
            BaseResponse baseResponse = new BaseResponse();
            try
            {
                _repository.Add(logInfo);
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

        public BaseResponse Delete(LogInfo logInfo)
        {
            BaseResponse baseResponse = new BaseResponse();
            try
            {
                _repository.Delete(logInfo);
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

        public EntityListResponse<LogInfo> Get(Expression<Func<LogInfo, bool>> filter = null)
        {
            EntityListResponse<LogInfo> serviceResponse = new EntityListResponse<LogInfo>();
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

        public BaseResponse Update(LogInfo logInfo)
        {
            BaseResponse baseResponse = new BaseResponse();
            try
            {
                _repository.Update(logInfo);
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
