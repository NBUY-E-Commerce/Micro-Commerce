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


            RuleFor(x => x.Email).NotEmpty().WithMessage("Email boş olamaz").EmailAddress().WithMessage("Geçerli bir eposta adresi giriniz.");
            RuleFor(x => x.Password).MinimumLength(6).NotEmpty().WithMessage("Şifre boş olamaz.");
            
        }
    }
}
