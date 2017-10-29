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
    public class CandidateController : BaseController
    {
        CandidateRepository candidateRepository;

        public CandidateController()
        {
            candidateRepository = new CandidateRepository();
        }


        [HttpGet]
        public async Task<List<CandidateVM>> GetOrderCandidates(int id)
        {
            var user = await GetCurrentUser();
            return candidateRepository.GetCandidates(user.Id, id);
        }
        


    }
}
