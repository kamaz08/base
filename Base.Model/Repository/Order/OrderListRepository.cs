using Base.Model.Model;
using Base.Model.Model.OrderModel;
using Base.Model.Model.User;
using Base.Model.Repository.Location;
using Base.Model.Repository.Message;
using Base.Model.ViewModel.Orders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Web;

namespace Base.Model.Repository.OrderNameSpace
{
    public class OrderListRepository
    {
        private PracaDorywczaDbContext db;

        public OrderListRepository()
        {
            this.db = new PracaDorywczaDbContext();
        }

        public List<OrderDisplayVM> GetOrderList(int? lastId)
        {
            var lastOrder = lastId.HasValue ? db.Order.Where(x => x.Id == lastId).FirstOrDefault() : null;

            var query = lastOrder == null ? db.Order.Where(x => x.ResultDate >= DateTime.Today) : db.Order.Where(x => x.ResultDate >= lastOrder.ResultDate && x.CreatedDate > lastOrder.CreatedDate);

            return query
                .OrderBy(x => x.ResultDate)
                .ThenBy(x => x.CreatedDate)
                .Take(5)
                .ToList()
                .Select<Order, OrderDisplayVM>(x => x)
                .ToList();
        }

        public List<OrderDisplayVM> GetPreferenceOrderList(String userId, int? lastId)
        {
            var category = db.Preference.Where(x => x.AppUserId == userId)
                .Select(x => x.OrderCategoryId).ToList();

            var city = db.CityPreference.Where(x => x.AppUserId == userId)
                .Select(x => x.CityId).ToList();

            var lastOrder = lastId.HasValue ? db.Order.Where(x => x.Id == lastId).FirstOrDefault() : null;
            var query = lastOrder == null ? db.Order.Where(x => x.ResultDate >= DateTime.Today) : db.Order.Where(x => x.ResultDate >= lastOrder.ResultDate && x.CreatedDate > lastOrder.CreatedDate);

            return query
                .Where(x=>x.Address.CityId.HasValue && city.Contains(x.Address.CityId.Value))
                .Where(x=> category.Contains(x.CategoryId))
                .OrderBy(x => x.ResultDate)
                .ThenBy(x => x.CreatedDate)
                .Take(5)
                .ToList()
                .Select<Order, OrderDisplayVM>(x => x)
                .ToList();
        }

        public List<OrderDisplayVM> GetUserOrderList(String userId, int? lastId)
        {
            var lastOrder = lastId.HasValue ? db.Order.Where(x => x.Id == lastId).FirstOrDefault() : null;
            var query = db.Order.Where(x => x.EmployerId == userId);
            query = lastOrder == null ? query.Where(x => x.ResultDate >= DateTime.Today) : query.Where(x => x.ResultDate >= lastOrder.ResultDate && x.CreatedDate > lastOrder.CreatedDate);
            return query
                .OrderBy(x => x.ResultDate)
                .ThenBy(x => x.CreatedDate)
                .Take(5)
                .ToList()
                .Select<Order, OrderDisplayVM>(x => x)
                .ToList();
        }

        public List<OrderDisplayVM> GetCustomerOrderList(String userId, bool accepted, int? lastId)
        {
            var lastOrder = lastId.HasValue ? db.Order.Where(x => x.Id == lastId).FirstOrDefault() : null;

            var query = db.Order.Where(x => x.Customer.Any(y => y.AppUserId == userId && y.IsAccepted == accepted));

            query = lastOrder == null ? query.Where(x => x.ResultDate >= DateTime.Today) : query.Where(x => x.ResultDate >= lastOrder.ResultDate && x.CreatedDate > lastOrder.CreatedDate);

            return query
                .OrderBy(x => x.ResultDate)
                .ThenBy(x => x.CreatedDate)
                .Take(5)
                .ToList()
                .Select<Order, OrderDisplayVM>(x => x)
                .ToList();
        }
    }
}