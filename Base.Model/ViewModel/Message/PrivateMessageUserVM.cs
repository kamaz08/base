using Base.Model.Model.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Base.Model.ViewModel.Message
{
    public class PrivateMessageUserVM
    {
        public String UserName { get; set; }
        public String UserId { get; set; }
        public String PublicKey { get; set; }

        public static implicit operator PrivateMessageUserVM(AppUser model) => new PrivateMessageUserVM
        {
            UserName = model.UserName,
            UserId = model.Id,
            PublicKey = model.PublicKey
        };
    }
}