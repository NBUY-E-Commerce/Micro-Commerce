using B_Commerce.Login.Request;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace B_Commerce.Login.FluentValidation
{
    public class MailRequestValidation : AbstractValidator<MailRequest>
    {
        public MailRequestValidation()
        {
            RuleFor(x => x.Subject).NotEmpty().WithMessage("Konu alanı boş olamaz.");
            RuleFor(x => x.ToMail).NotEmpty().WithMessage("Gönderileceği alan boş olamaz");
            RuleFor(x => x.ProjectCode).NotEmpty().WithMessage("Proje kodu boş olamaz.");
       
        }
    }
}
