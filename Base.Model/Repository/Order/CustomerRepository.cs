using Base.Model.Model;
using Base.Model.Model.User;
using Base.Model.ViewModel.Orders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Base.Model.Repository.OrderNameSpace
{
    public class CustomerRepository
    {
        private PracaDorywczaDbContext db;

        public CustomerRepository()
        {
            this.db = new PracaDorywczaDbContext();
        }

        public List<CustomerVM> GetCandidates(String userId, int orderId)
        {
            var order = db.Order
                .Where(x => x.Id == orderId)
                .Where(x => x.EmployerId == userId)
                .FirstOrDefault();

            if (order == null)
                return null;

            var result = order
                .Customer
                .Where(x => x.IsAccepted)
                .Select(x => x.AppUser)
                .ToList()
                .Select<AppUser, CustomerVM>(x => x)
                .ToList();

            result.ForEach(x => x.isAccepted = true);

            return result.Concat(order
                .Customer
                .Where(x => x.IsAccepted == false)
                .Select(x => x.AppUser)
                .ToList()
                .Select<AppUser, CustomerVM>(x => x)
                .ToList()).ToList();
        }

        public bool ChooseCandidates(String userId, int orderId, List<string> candidateIdList)
        {
            var order = db.Order
                .Where(x => x.Id == orderId)
                .Where(x => x.EmployerId == userId)
                .Where(x => x.IsOpen)
                .FirstOrDefault();

            if (order == null)
                return false;

            var candidate = order.Customer.Where(x => candidateIdList.Exists(y => y == x.AppUserId)).ToList();

            candidate.ForEach(x => x.IsAccepted = true);

            var result = db.SaveChanges();

            if (result > 0)
            {
                order.IsOpen = false;
                db.SaveChanges();
                GenerateVote(order.Name, order.WorkDate, order.EmployerId, candidate.Select(x => x.AppUserId).ToList());
                return true;
            }
            return false;
        }

        private void GenerateVote(String orderName, DateTime workDate, String employerID, List<String> candidateList)
        {
            candidateList.ForEach(x =>
            {
                db.Vote.Add(new Model.OrderModel.Vote
                {
                    Type = Model.Enum.VoteTypeEnum.EmployerRaw,
                    AppUserId = employerID,
                    RaterId = x,
                    OrderName = orderName,
                    WorkDate = workDate,
                    VoteDate = DateTime.Now
                });
                db.Vote.Add(new Model.OrderModel.Vote
                {
                    Type = Model.Enum.VoteTypeEnum.CustomerRaw,
                    AppUserId = x,
                    RaterId = employerID,
                    OrderName = orderName,
                    WorkDate = workDate,
                    VoteDate = DateTime.Now
                });

            });
            db.SaveChanges();
        }

        public List<AddVoteVM> GetRawVote(String userId, int? lastId)
        {
            var last = lastId.HasValue ? db.Vote.Where(x => x.Id == lastId).FirstOrDefault() : null;

            var query = db.Vote
                .Where(x => x.RaterId == userId)
                .Where(x => (int)x.Type > 1);

            query = last == null ? query : query.Where(x => x.VoteDate > last.VoteDate);

            return query
                .OrderBy(x => x.WorkDate)
                .ThenBy(x => x.VoteDate)
                .Take(5)
                .ToList()
                .Select<Model.OrderModel.Vote, AddVoteVM>(x => x)
                .ToList();
        }

        public List<VoteVM> GetVote(String userId, int? lastId)
        {
            var last = lastId.HasValue ? db.Vote.Where(x => x.Id == lastId).FirstOrDefault() : null;

            var query = db.Vote
                .Where(x => x.AppUserId == userId)
                .Where(x => (int)x.Type < 2);

            query = last == null ? query : query.Where(x => x.VoteDate < last.VoteDate);

            var x1 = query.ToList();

            return query
                .OrderByDescending(x => x.VoteDate)
                .Take(5)
                .ToList()
                .Select<Model.OrderModel.Vote, VoteVM>(x => x)
                .ToList();
        }

        public bool AddVote(String userId, int id, int vote, String description)
        {
            var result = db.Vote.Where(x => x.Id == id)
                .Where(x => x.RaterId == userId)
                .Where(x => (int)x.Type > 1)
                .FirstOrDefault();

            var hehe = db.Vote.Where(x => x.Id == id).FirstOrDefault();

            if (result == null) return false;

            result.VoteDate = DateTime.Now;
            result.Note = vote;
            result.Description = description;
            result.Type = result.Type == Model.Enum.VoteTypeEnum.CustomerRaw ? Model.Enum.VoteTypeEnum.Customer : Model.Enum.VoteTypeEnum.Employer;

            db.SaveChanges();

            return true;
        }
    }
}