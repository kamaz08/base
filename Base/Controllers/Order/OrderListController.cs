using Base.Model.Repository.OrderNameSpace;
using Base.Model.ViewModel.Orders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Base.Controllers.Order
{

    public class OrderListController : BaseController
    {
        private OrderListRepository orderListRepository;
        public OrderListController()
        {
            this.orderListRepository = new OrderListRepository();
        }

        [HttpGet]
        public List<OrderDisplayVM> GetOrders(int? orderId, bool preference)
        {
            if (preference)
            {
                var user = GetCurrentUser();
                return orderListRepository.GetPreferenceOrderList(user.Id,orderId);
            }
                

            return orderListRepository.GetOrderList(orderId);
        }

        [HttpGet]
        public List<OrderDisplayVM> GetUserOrders(int? orderId)
        {
            var user = GetCurrentUser();

            return orderListRepository.GetUserOrderList(user.Id, orderId);
        }


        [HttpGet]
        public List<OrderDisplayVM> GetCustomerOrders(int? orderId)
        {
            var user = GetCurrentUser();
            return orderListRepository.GetCustomerOrderList(user.Id, true, orderId);
        }


        [HttpGet]
        public List<OrderDisplayVM> GetCandidateOrders(int? orderId)
        {
            var user = GetCurrentUser();
            return orderListRepository.GetCustomerOrderList(user.Id, false, orderId);
        }

    }
}
