using Base.Model.Model.OrderModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Base.Model.Model.MessageModel
{
    public class PublicMessage
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public int? OrderId { get; set; }

        public virtual Order Order { get; set; }
        public virtual ICollection<Message> Message { get; set; }
        public virtual ICollection<AppUserPublicMessage> AppUserPublicMessage { get; set; }
    }
}