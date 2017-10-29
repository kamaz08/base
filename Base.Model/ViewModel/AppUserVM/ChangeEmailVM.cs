using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Base.Model.ViewModel.AppUserVM
{
    public class ChangeEmailVM
    {
        [DataType(DataType.EmailAddress)]
        [Display(Name = "Adres email")]
        [EmailAddress(ErrorMessage = "Niepoprawny adres email")]
        public string Email { get; set; }
    }
}