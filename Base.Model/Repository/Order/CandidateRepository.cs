using Base.Model.Model;
using Base.Model.Model.User;
using Base.Model.ViewModel.Orders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Base.Model.Repository.OrderNameSpace
{
    public class CandidateRepository
    {
        private PracaDorywczaDbContext db;

        public CandidateRepository()
        {
            this.db = new PracaDorywczaDbContext();
        }

        public List<CandidateVM> GetCandidates(String userId, int orderId)
        {
            var order = db.Order
                .Where(x => x.Id == orderId)
                .Where(x=>x.EmployerId == userId)
                .FirstOrDefault();

            if (order == null)
                return null;

            return order
                .Candidate
                .Select(x => x.AppUser)
                .ToList()
                .Select<AppUser, CandidateVM>(x=>x)
                .ToList();
        }


    }
}