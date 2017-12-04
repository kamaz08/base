using Base.Model.Repository.Location;
using Base.Model.Repository.User;
using Base.Model.ViewModel.Location;
using Base.Model.ViewModel.UserVM;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;

namespace Base.Controllers.User
{

    [Authorize]
    public class UserController : BaseController
    {
        private PersonalDataRepository _personalDataRepository;
        public UserController()
        {
            this._personalDataRepository = new PersonalDataRepository();
        }

        [HttpPost]
        public IHttpActionResult UpdatePersonalData(PersonalDataVM data)
        {
            _personalDataRepository.SavePersonalData(RequestContext.Principal.Identity.GetUserName(), data);
            return Ok();
        }

        [HttpGet]
        public PersonalDataVM GetPersonalData()
        {
            var user = GetCurrentUser();
            return _personalDataRepository.GetPersonalData(RequestContext.Principal.Identity.GetUserName());
        }

        [HttpGet]
        public PersonalProfileVM GetPersonalProfile()
        {
            var user = GetCurrentUser();
            return _personalDataRepository.GetPersonalProfile(user.Id);
        }

        [HttpPost]
        public IHttpActionResult UpdatePersonalProfile(PersonalProfileVM data)
        {
            var user = GetCurrentUser();
            _personalDataRepository.SavePersonalProfile(user.Id, data);

            return Ok();
        }

        [HttpGet]
        public PublicDataVM GetPublicUser(String userId)
        {
            if (userId == null || userId == String.Empty)
                userId = GetCurrentUser().Id;
            var res = _personalDataRepository.GetPublicDataVM(userId);
            return res;
        }
    }
}
