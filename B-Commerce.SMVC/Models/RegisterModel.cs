using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace B_Commerce.SMVC.Models
{
    public class RegisterModel
    {
        [Required(ErrorMessage = "Username alanı boş geçilemez!")]
        public string Username { get; set; }
        [Required(ErrorMessage = "Password alanı boş geçilemez!")]
        [MinLength(6)]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Compare("Password", ErrorMessage = "İki parola eşleşmiyor!")]
        [Display(Name = "Parola Tekrar")]
        [DataType(DataType.Password)]
        public string ConfirmPassword { get; set; }
        [Required(ErrorMessage = "Name alanı boş geçilemez!")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Surname alanı boş geçilemez!")]
        public string Surname { get; set; }
        [Required(ErrorMessage = "Email alanı boş geçilemez!")]
        [EmailAddress]
        public string Email { get; set; }
        [Required(ErrorMessage = "Phone alanı boş geçilemez!")]
        [Phone]
        public string Phone { get; set; }
    }
}