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
    public class CustomerController : BaseController
    {
        CustomerRepository CustomerRepository;

        public CustomerController()
        {
            CustomerRepository = new CustomerRepository();
        }


        [HttpGet]
        public async Task<List<CustomerVM>> GetOrderCustomers(int id)
        {
            var user = await GetCurrentUser();
            return CustomerRepository.GetCandidates(user.Id, id);
        }
        


    }
}
