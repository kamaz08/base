using Base.Model.Model;
using Base.Model.Model.OrderModel;
using Base.Model.Model.User;
using Base.Model.Repository.Location;
using Base.Model.ViewModel.Orders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Base.Model.Repository.OrderNameSpace
{
    public class OrderRepository
    {
        private PracaDorywczaDbContext db;

        public OrderRepository()
        {
            this.db = new PracaDorywczaDbContext();
        }

        public OrderDisplayVM GetOrder(int id)
        {
            var result = db.Order.Where(x => x.Id == id).FirstOrDefault();
            if (result == null)
                return null;
            return result;
        }

        public List<OrderDisplayVM> GetOrderList()
        {
            return db.Order
                .OrderBy(x => x.ResultDate)
                .Take(10)
                .ToList()
                .Select<Order, OrderDisplayVM>(x => x)
                .ToList();
        }

        public OrderOwnerEnum GetOrderOwner(String userId, int orderId)
        {
            var order = db.Order.Where(x => x.Id == orderId).First();

            if (order.EmployerId == userId) return OrderOwnerEnum.Author;
            if (order.Customer.Any(x => x.AppUserId == userId && x.IsAccepted)) return OrderOwnerEnum.Customer;
            if (order.Customer.Any(x => x.AppUserId == userId && !x.IsAccepted)) return OrderOwnerEnum.Candidate;

            return OrderOwnerEnum.Guest;
        }


        public void AddOrder(AppUser user, OrderVM model)
        {
            var order = db.Order.Add(new Order
            {
                IsOpen = true,
                Name = model.Name,
                Rate = model.Rate,
                NumberOfEmploye = model.NumberOfEmploye,
                ResultDate = model.ResultDate,
                WorkDate = model.WorkDate,
                EmployerId = user.Id,
                CreatedDate = DateTime.Now
            });

            order.Address = new LocationRepository().AddOrUpdate(model, order.Address);

            order.OrderDetail = db.OrderDetail.Add(new OrderDetail
            {
                Description = model.Description,
                ExecutionTime = model.ExecutionTime,
                Requirements = model.Requirements

            });

            var category = db.OrderCategory.Where(x => x.Name == model.Category.ToLower()).FirstOrDefault();
            if (category == null)
            {
                category = db.OrderCategory.Add(new OrderCategory
                {
                    Name = model.Category.ToLower()
                });
            }

            if (category.Id == 0)
                order.Category = category;
            else
                order.CategoryId = category.Id;


            db.Order.Add(order);

            db.SaveChanges();
        }

        public bool SingInOrder(String userId, int orderId)
        {
            var order = db.Order.Where(x => x.Id == orderId).FirstOrDefault();

            if (order == null || !order.IsOpen || order.EmployerId == userId || order.WorkDate < DateTime.Now)
                return false;

            bool isIn = order.Customer
                .Where(x => x.AppUserId == userId)
                .Count() > 0;

            if (isIn) return true;

            db.OrderCustomer.Add(new AppUserOrderCustomer
            {
                AppUserId = userId,
                OrderId = orderId
            });

            db.SaveChanges();
            return true;
        }

        public bool SingOutOrder(String userId, int orderId)
        {
            var order = db.Order.Where(x => x.Id == orderId).FirstOrDefault();

            if (order == null || !order.IsOpen || order.EmployerId == userId || order.WorkDate < DateTime.Now)
                return false;

            var candidate = order.Customer
                .Where(x => x.AppUserId == userId)
                .Where(x => x.IsAccepted == false)
                .FirstOrDefault();

            if (candidate == null)
                return false;

            db.OrderCustomer.Remove(candidate);

            db.SaveChanges();
            return true;
        }

        public bool DeleteOrder(String userId, int orderId)
        {
            var order = db.Order.Where(x => x.Id == orderId).FirstOrDefault();

            if (order.EmployerId != userId)
                return false;

            db.Address.Remove(order.Address);

            db.OrderCustomer.RemoveRange(order.Customer);

            db.OrderDetail.Remove(order.OrderDetail);

            db.SaveChanges();

            return true;
        }


    }
}