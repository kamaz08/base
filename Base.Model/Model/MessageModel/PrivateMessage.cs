using Base.Model.Model.OrderModel;
using Base.Model.Model.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Base.Model.Model.MessageModel
{
    public class PrivateMessage
    {
        public int Id { get; set; }
        public String FromAppUserId { get; set; }
        public String ToAppUserId { get; set; }
        public DateTime Date { get; set; }
        public int? OrderId { get; set; }
        public String Message { get; set; }

        public virtual AppUser FromAppUser { get; set; }
        public virtual AppUser ToAppUser { get; set; }
        public virtual Order Order { get; set; }
    }
}