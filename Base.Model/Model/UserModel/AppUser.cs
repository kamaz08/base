using Base.Model.Model.MessageModel;
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
        public override string Email { get => base.Email; set => base.Email = value; }
        public DateTime DateCreated { get; set; }

        public virtual PersonalData PersonalData { get; set; }
        public virtual PersonalProfile PersonalProfile { get; set; }

        public virtual ICollection<Order> UserOrder { get; set; }
        public virtual ICollection<AppUserOrderCustomer> OrderCustomer { get; set; }
        public virtual ICollection<Vote> Vote { get; set; }
        public virtual ICollection<Vote> Rater { get; set; }
        public virtual ICollection<PrivateMessage> PrivateMessage { get; set; }
        public virtual ICollection<PrivateMessage> SendPrivateMessage { get; set; }
        public virtual ICollection<AppUserPublicMessage> AppUserPublicMessage { get; set; }
    }
}