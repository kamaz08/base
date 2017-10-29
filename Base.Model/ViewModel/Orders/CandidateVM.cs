using Base.Model.Model.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Base.Model.ViewModel.Orders
{
    public class CandidateVM
    {
        public String Id { get; set; }
        public String Name { get; set; }
        public Decimal Rate { get; set; }

        public static implicit operator CandidateVM(AppUser model) => new CandidateVM
        {
            Id = model.Id,
            Name = model.UserName,
            Rate = Decimal.Round(model.Vote.Count > 0 ? (decimal)model.Vote.Average(x => x.Note) : 0m, 1)
        };
    }
}