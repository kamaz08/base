using Base.Model.Model.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Base.Model.ViewModel.Orders
{
    public class CustomerVM
    {
        public String Id { get; set; }
        public String Name { get; set; }
        public Decimal Rate { get; set; }
        public bool isAccepted { get; set; }

        public static implicit operator CustomerVM(AppUser model) => new CustomerVM
        {
            Id = model.Id,
            Name = model.UserName,
            Rate = Decimal.Round(model.Vote.Where(x=> ((int)x.Type) < 2).ToList().Count > 0 ? (decimal)model.Vote.Average(x => x.Note) : 0m, 1),
            isAccepted = false
        };
    }
}