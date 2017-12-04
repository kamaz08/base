using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Base.Model.ViewModel.Message
{
    public class MessageVM
    {
        public int Id { get; set; }
        public String[] Message { get; set; }
        public String UserName { get; set; }
        public String Date { get; set; }

        public static implicit operator MessageVM(Model.MessageModel.Message model) => new MessageVM
        {
            Id = model.Id,
            Message = model.Mess.Split('\n'),
            UserName = model.AppUser.UserName,
            Date = model.Date.ToShortTimeString()
        };

        public static implicit operator MessageVM(Model.MessageModel.PrivateMessage model) => new MessageVM
        {
            Id = model.Id,
            Message = new String[] { model.Message },
            UserName = model.FromAppUser.UserName,
            Date = model.Date.ToShortDateString()
        };
    }
}