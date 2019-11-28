using B_Commerce.Login.Request;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace B_Commerce.Login.FluentValidation
{
    public class RegisterRequestValidator : AbstractValidator<RegisterRequest>
    {
        public RegisterRequestValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("Name alanı boş olamaz.");
            RuleFor(x => x.Surname).NotEmpty().WithMessage("Surname alanı boş olamaz.");
            RuleFor(x => x.Email).EmailAddress().WithMessage("Geçerli bir eposta adresi giriniz.").When(x => !string.IsNullOrEmpty(x.Email));
            RuleFor(x => x.Password).NotEmpty().WithMessage("Şifre boş olamaz.").NotEqual(t=>t.Name).WithMessage("Şifreye isim yazmakta ne biliyim xD");
            RuleFor(x => x.Phone).NotEmpty().WithMessage("Phone boş olamaz.");
            RuleFor(x => x.Username).NotEmpty().WithMessage("Username boş olamaz.");
        }
    }
}
