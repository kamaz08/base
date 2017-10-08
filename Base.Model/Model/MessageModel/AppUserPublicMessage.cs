using Base.Model.Model.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Base.Model.Model.MessageModel
{
    public class AppUserPublicMessage
    {
        public int Id { get; set; }
        public String AppUserId { get; set; }
        public int PublicMessageId { get; set; }

        public virtual AppUser AppUser { get; set; }
        public virtual PublicMessage PublicMessage { get; set; }
    }
}