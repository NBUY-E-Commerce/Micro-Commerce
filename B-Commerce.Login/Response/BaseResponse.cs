using B_Commerce.Login.Common;
using B_Commerce.Login.FluentValidation;
using System;
using System.Collections.Generic;
using FluentValidation.Results;
using System.Text;

namespace B_Commerce.Login.Response
{
    public class BaseResponse
    {
        public int Code { get; set; }
        public string Message { get; set; }

        public List<ValidationError> ValidationErrors { get; set; }

        public void SetStatus(Constants.ResponseCode code)
        {
            this.Code = (int)code;
            this.Message = Constants.ResponseCodes[(int)code];
        }

        public void setValidator(ValidationResult result)
        {
            this.ValidationErrors = new List<ValidationError>();

            foreach (ValidationFailure item in result.Errors)
            {
                this.ValidationErrors.Add(new ValidationError
                {
                    PropertyName = item.PropertyName,
                    Messeage = item.ErrorMessage
                });
            }
            this.SetStatus(Constants.ResponseCode.INVALIDREQUEST);



        }
    }


}
