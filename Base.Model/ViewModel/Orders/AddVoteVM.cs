using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Base.Model.Model.OrderModel;
using Base.Model.Model.Enum;

namespace Base.Model.ViewModel.Orders
{
    public class AddVoteVM
    {
        public int Id { get; set; }
        public String WorkDate { get; set; }
        public String UserName { get; set; }
        public String OrderName { get; set; }
        public VoteTypeEnum Type { get; set; }

        public static implicit operator AddVoteVM(Vote model) => new AddVoteVM
        {
            Id = model.Id,
            WorkDate = model.WorkDate.ToString("dd-MM-yyyy"),
            UserName = model.AppUser.UserName,
            OrderName = model.OrderName,
            Type = model.Type
        };
    }

}