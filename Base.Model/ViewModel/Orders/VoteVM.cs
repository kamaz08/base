using Base.Model.Model.Enum;
using Base.Model.Model.OrderModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Base.Model.ViewModel.Orders
{
    public class VoteVM
    {
        public int Id { get; set; }
        public String WorkDate { get; set; }
        public String UserName { get; set; }
        public String OrderName { get; set; }
        public VoteTypeEnum Type { get; set; }
        public int Note { get; set; }
        public String Description { get; set; }

        public static implicit operator VoteVM(Vote model) => new VoteVM
        {
            Id = model.Id,
            WorkDate = model.WorkDate.ToString("dd-MM-yyyy"),
            UserName = model.AppUser.UserName,
            OrderName = model.OrderName,
            Type = model.Type,
            Note = model.Note.Value,
            Description = model.Description
        };
    }
}