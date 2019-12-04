using B_Commerce.LogService.DomainClasses;
using B_Commerce.LogService.Helpers.Abstract;
using B_Commerce.LogService.Helpers.Request;
using B_Commerce.LogService.MqServices.Request;
using B_Commerce.LogService.Services.Abstract;
using B_Commerce.LogService.Services.Concrete;
using B_Commerce.LogService.Services.Response;
using System;
using System.Collections.Generic;

using static B_Commerce.LogService.Common.Constants;

namespace B_Commerce.LogService.Helpers.Concrete
{
    public class DBHelper:IDBHelper
    {
        private ILogInfoService _logInfoService;
        private IProjectInfoService _projectInfoService;
        private IProjectOwnerService _projectOwnerService;
        public DBHelper(ILogInfoService logInfoService,
        IProjectInfoService projectInfoService,
        IProjectOwnerService projectOwnerService) {
            _logInfoService = logInfoService;
            _projectInfoService = projectInfoService;
            _projectOwnerService = projectOwnerService;
        }

        public BaseResponse Add(List<InserLogRequest> publishers)
        {
            BaseResponse baseResponse = new BaseResponse();
            try
            {
                /*InserLogRequest
      public string ProjectCode { get; set; }
        public string Password { get; set; }
        public string queuName { get; set; }
        public string LoginInfoMessage { get; set; }
        public string Email { get; set; }
        public bool IsEmailRequired { get; set; }
                 */

                foreach (InserLogRequest item in publishers) {
                    int projectID = _projectInfoService.GetIdByCode(item.ProjectCode);
                    _logInfoService.Add(new LogInfo
                    {
                        ProjectID = projectID,
                        insertDateTime = DateTime.Now,
                        LogInfoMessage = item.LoginInfoMessage
                    });
                }
                baseResponse.SetStatus(ResponseCode.SUCCESS);
                return baseResponse;
            }
            catch (Exception)
            {

                throw;
            }
            return null;
        }

        public BaseResponse Authentication(AuthenticationRequest request)
        {
            BaseResponse baseResponse = new BaseResponse();
            try
            {
                EntityListResponse<ProjectInfo> autResult = _projectInfoService.Get(t=>t.ProjectCode==request.ProjectCode && t.Password==request.Password);
                if (autResult.Code!=(int)ResponseCode.SUCCESS
                    ||autResult.EntityList.Count<1) {

                    baseResponse.SetStatus(ResponseCode.INVALID_PROJECT_CODE);
                    return baseResponse;
                }
                baseResponse.SetStatus(ResponseCode.SUCCESS);
                return baseResponse;

            }
            catch (Exception ex)
            {

                baseResponse.SetStatus(ResponseCode.SYSTEM_ERROR);
                return baseResponse;
            }
        }

        //autantication


        /*
         *   var validation_result = _projectInfoService.Get(t => t.ProjectCode == insertLogRequest.ProjectCode && t.Password == insertLogRequest.Password).FirstOrDefault();
         */
    }
}
