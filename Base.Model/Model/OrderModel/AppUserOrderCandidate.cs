using Base.Model.Model.User;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Base.Model.Model.OrderModel
{
    public class AppUserOrderCustomer
    {
        [Key]
        public String Id { get; set; }
        public String AppUserId { get; set; }
        public String OrderId { get; set; }

        public virtual Order Order { get; private set; }
        public virtual AppUser AppUser { get; private set; }
    }
}