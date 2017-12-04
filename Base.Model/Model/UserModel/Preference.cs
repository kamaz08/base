using Base.Model.Model.OrderModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Base.Model.Model.User
{
    public class Preference
    {
        public int Id { get; set; }
        public String AppUserId { get; set; }
        public int OrderCategoryId { get; set; }

        public virtual AppUser AppUser { get; set; }
        public virtual OrderCategory Category { get; set; }
    }
}