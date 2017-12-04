using Base.Model.Model.MessageModel;
using Base.Model.Model.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Base.Model.ViewModel.Message
{
    public class PublicMessageVM
    {
        public String Name { get; set; }
        public int? Id { get; set; }
        public int? OrderId { get; set; }
        public String OrderName { get; set; }
        public bool IsReaded { get; set; }
    }
}