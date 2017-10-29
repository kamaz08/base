using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Base.Model.ViewModel.AppUserVM
{
    public class RegistrationUserVM
    {
        [Required]
        [Display(Name = "Nazwa użytkownika")]
        public string UserName { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "{0} musi mieć {2} znaków", MinimumLength = 8)]
        [DataType(DataType.Password)]
        [Display(Name = "Hasło")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Potwiedź hasło")]
        [Compare("Password", ErrorMessage = "Hasła muszą być takie same")]
        public string ConfirmPassword { get; set; }

        [DataType(DataType.EmailAddress)]
        [Display(Name = "Adres email")]
        [EmailAddress(ErrorMessage ="Niepoprawny adres email")]
        public string Email { get; set; }

    }
}