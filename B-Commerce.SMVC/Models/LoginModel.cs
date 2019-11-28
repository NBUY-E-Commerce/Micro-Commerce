using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace B_Commerce.SMVC.Models
{
    public class LoginModel
    {
        
        public string UserName { get; set; }
        [Required(ErrorMessage = "Username alanı boş geçilemez!")]
        [EmailAddress]
        public string Email { get; set; }
        [DataType(DataType.Password)]
        
        [RegularExpression("([a-z]|[A-Z]|[0-9]|[\\W]){4}[a-zA-Z0-9\\W]{3,11}", ErrorMessage = "Invalid password format")]
        [Required(ErrorMessage = "Password alanı boş geçilemez!")]
        public string Password { get; set; }
    }
}