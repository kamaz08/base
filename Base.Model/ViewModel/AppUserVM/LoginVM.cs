﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Base.Model.ViewModel.AppUserVM    
{
    public class LoginVM
    {
        [Required]
        public string Login { get; set; }
    }

    public class LoginWithPassword
    {
        [Required]
        public string Login { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        public string OtpPassword { get; set; }
    }
}