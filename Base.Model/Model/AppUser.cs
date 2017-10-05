using Base.Model.Model.User;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Base.Model.Model
{
    public class AppUser : IdentityUser
    {
        [Required]
        public override string Email { get => base.Email; set => base.Email = value; }

        public Address Address { get; set; } 
    }
}