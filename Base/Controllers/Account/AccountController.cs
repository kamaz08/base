using Base.Model.Model;
using Base.Model.Repository;
using Base.Model.ViewModel.AppUser;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace Base.Controllers.Account
{
    public class AccountController : ApiController
    {
        private AuthRepository _repository = null;

        public AccountController()
        {
            _repository = new AuthRepository();
        }

        [AllowAnonymous]
        public async Task<IHttpActionResult> Register (RegistrationUserVM model)
        {
            if (model == null)
                return BadRequest("Wypełnij pola");

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            IdentityResult result = await _repository.RegisterAppUser(model);
            IHttpActionResult errorResult = GetErrorResult(result);

            if(errorResult != null)
                return errorResult;

            return Ok();
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
                _repository.Dispose();

            base.Dispose(disposing);
        }

        private IHttpActionResult GetErrorResult(IdentityResult result)
        {
            if(result == null)
                return InternalServerError();

            if (!result.Succeeded)
            {
                if(result.Errors != null)
                    foreach (string error in result.Errors)
                        ModelState.AddModelError("", error);

                if (ModelState.IsValid)
                    return BadRequest();

                return BadRequest(ModelState);
            }

            return null;
        }
    }
}
