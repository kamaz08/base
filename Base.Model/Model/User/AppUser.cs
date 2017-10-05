using Base.Model.Model.OrderModel;
using Base.Model.Model.User;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Base.Model.Model.User
{
    public class AppUser : IdentityUser
    {
        [Required]
        [Display(Name = "Adres email")]
        public override string Email { get => base.Email; set => base.Email = value; }
        public virtual PersonalData PersonalData { get; set; } 
        public virtual PersonalProfile PersonalProfile { get; set; }
        public virtual ICollection<Order> UserOrder { get; set; }
        public virtual ICollection<Order> Order { get; set; }
    }
}