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
        [MaxLength(256)]
        public string ForeName { get; set; }
        [MaxLength(256)]
        public string SurName { get; set; }
        [Required]
        public override string Email { get => base.Email; set => base.Email = value; }
    }
}