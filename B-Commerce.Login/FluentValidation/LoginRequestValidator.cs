using B_Commerce.Login.Request;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace B_Commerce.Login.FluentValidation
{
    public class LoginRequestValidator : AbstractValidator<LoginRequest>
    {
        public LoginRequestValidator()
        {
           
           
            RuleFor(x => x.Email).EmailAddress().WithMessage("Geçerli bir eposta adresi giriniz.").When(x => !string.IsNullOrEmpty(x.Email));
            RuleFor(x => x.Password).MinimumLength(6).NotEmpty().WithMessage("Şifre boş olamaz.");
            
        }
    }
}
