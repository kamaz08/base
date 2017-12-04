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
            var user = await GetCurrentUserAsync();
            return CustomerRepository.GetCandidates(user.Id, id);
        }

        [HttpPost]
        public IHttpActionResult ChooseCandidates(Canditates candidates)
        {
            var user = GetCurrentUser();

            var result = CustomerRepository.ChooseCandidates(user.Id, candidates.OrderId, candidates.CustomerIdList);

            if (result)
                return Ok();
            else
                return BadRequest("Nie możesz zakończyć rekrutacji");
        }

        [HttpGet]
        public List<AddVoteVM> GetRawVote(int? lastId)
        {
            var user = GetCurrentUser();

            return CustomerRepository.GetRawVote(user.Id, lastId);
        }

        [HttpPost]
        public IHttpActionResult AddVote(VoteToAdd model)
        {
            var user = GetCurrentUser();

            CustomerRepository.AddVote(user.Id, model.Id, model.Vote, model.Description);


            return Ok();
        }

        [HttpGet]
        public List<VoteVM> GetVotes(String userId, int? lastId)
        {
            userId = userId ?? GetCurrentUser().Id;
            return CustomerRepository.GetVote(userId, lastId);
        }


        public class Canditates
        {
            public int OrderId { get; set; }
            public List<String> CustomerIdList { get; set; }
        }

        public class VoteToAdd
        {
            public int Id { get; set; }
            public int Vote { get; set; }
            public String Description { get; set; }
        }



    }
}
