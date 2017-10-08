using Base.Model.Model.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Base.Model.Model.MessageModel
{
    public class Message
    {
        public int Id { get; set; }
        public int PublicMessageId { get; set; }
        public String AppUserId { get; set; }
        public DateTime Date { get; set; }
        public String Mess { get; set; }

        public virtual AppUser AppUser { get; set; }
        public virtual PublicMessage PublicMessage { get; set; }
    }
}