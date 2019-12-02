using LogService.DomainClasses;
using LogService.DTO.Request;
using LogService.DTO.Response;
using LogService.Services.Abstract;
using MQService;
using System;
using System.Linq;
using static LogService.Common.Constants;

namespace LogService.Helpers
{
    internal class StatusControlHelper
    {

        private IProjectInfoService _projectInfoService;
        private IProjectOwnerService _projectOwnerService;
        public StatusControlHelper(
            IProjectInfoService projectInfoService,
            IProjectOwnerService projectOwnerService)
        {

            _projectInfoService = projectInfoService;
            _projectOwnerService = projectOwnerService;
        }

        public InsertLogReponse CheckRequestParameters(InsertLogRequest insertLogRequest)
        {
            InsertLogReponse insertLogReponse = new InsertLogReponse();
            try
            {
                var validation_result = _projectInfoService.Get(t => t.ProjectCode == insertLogRequest.ProjectCode && t.Password == insertLogRequest.Password).FirstOrDefault();

                if (validation_result == null)
                {
                    insertLogReponse.SetStatus(ResponseCode.INVALID_CODE_OR_PASSWORD);
                    return insertLogReponse;
                }

                if (insertLogRequest.queuName == null)
                {
                    insertLogReponse.SetStatus(ResponseCode.EMPTY_QUEUE_NAME);
                    return insertLogReponse;
                }
                if (insertLogRequest.Email == null && insertLogRequest.IsRequestEmail)
                {
                    insertLogReponse.SetStatus(ResponseCode.EMPTY_EMAIL_ADDRESS);
                    return insertLogReponse;
                }

            }
            catch (Exception)
            {

                insertLogReponse.SetStatus(ResponseCode.SYSTEM_ERROR);
                return insertLogReponse;
            }

            insertLogReponse.SetStatus(ResponseCode.SUCCESS);
            return insertLogReponse;
        }

        public InsertLogReponse CheckDbParameters(InsertLogRequest insertLogRequest)
        {
            InsertLogReponse insertLogReponse = new InsertLogReponse();
            try
            {

                var projectInfo_result = _projectInfoService.Get(t => t.ProjectCode == insertLogRequest.ProjectCode).FirstOrDefault();

                var projectOwner_result = _projectOwnerService.Get(t => t.ProjectID == projectInfo_result.ID).FirstOrDefault();

                if (projectOwner_result == null)
                {

                    ProjectOwner projectOwner = new ProjectOwner
                    {
                        ProjectID = projectInfo_result.ID,
                        Email = insertLogRequest.Email,
                        IsRequestEmail = insertLogRequest.IsRequestEmail,
                    };
                    _projectOwnerService.Add(projectOwner);
                }

                if (projectOwner_result.Email != insertLogRequest.Email)
                {

                    ProjectOwner projectOwner = new ProjectOwner
                    {
                        ProjectID = projectInfo_result.ID,
                        Email = insertLogRequest.Email,
                        IsRequestEmail = insertLogRequest.IsRequestEmail,
                    };
                    _projectOwnerService.Add(projectOwner);
                }


            }
            catch (Exception)
            {

                insertLogReponse.SetStatus(ResponseCode.SYSTEM_ERROR);
                return insertLogReponse;
            }

            insertLogReponse.SetStatus(ResponseCode.SUCCESS);
            return insertLogReponse;
        }
       
    }
}
