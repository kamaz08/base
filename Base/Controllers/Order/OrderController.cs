using Base.Model.Repository.OrderNameSpace;
using Base.Model.ViewModel.Orders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace Base.Controllers.Order
{
    [Authorize]
    public class OrderController : BaseController
    {
        private OrderRepository orderRepository;
        public OrderController()
        {
            this.orderRepository = new OrderRepository();
        }

        [HttpPost]
        public async Task<IHttpActionResult> AddOrder(OrderVM data)
        {
            var user = await GetCurrentUser();

            orderRepository.AddOrder(user, data);

            return Ok();
        }

        [HttpGet]
        public async Task<IHttpActionResult> SignInOrder(int id)
        {
            var user = await GetCurrentUser();

            if (orderRepository.SingInOrder(user.Id, id))
                return Ok();
            return BadRequest("Nie możesz dołączyć do rekrutacji");
        }

        [HttpGet]
        public async Task<IHttpActionResult> SignOutOrder(int id)
        {
            var user = await GetCurrentUser();

            if (orderRepository.SingOutOrder(user.Id, id))
                return Ok();
            return BadRequest("Nie możesz dołączyć do rekrutacji");
        }

        [HttpDelete]
        public async Task<IHttpActionResult> DeleteOrder(int id)
        {
            var user = await GetCurrentUser();

            if (orderRepository.DeleteOrder(user.Id, id))
                return Ok();
            return BadRequest("Nie możesz dołączyć do rekrutacji");
        }

        [HttpGet]
        public List<OrderDisplayVM> GetOrder()
        {
            return orderRepository.GetOrderList();
        }

        [AllowAnonymous]
        [HttpGet]
        public async Task<OrderOwnerEnum> GetOrderOwner(int id)
        {
            var user = await GetCurrentUser();
            return orderRepository.GetOrderOwner(user.Id, id);
        }

    }
}
