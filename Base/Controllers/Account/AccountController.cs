using Base.App_Start;
using Base.Model.Model;
using Base.Model.Repository;
using Base.Model.ViewModel.AppUser;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
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
        //private AuthRepository _repository = null;

        private AppUserManager _AppUserManager = null;

        protected AppUserManager AppUserManager
        {
            get
            {
                return _AppUserManager ?? Request.GetOwinContext().GetUserManager<AppUserManager>();
            }
        }

        public AccountController()
        {
        }

        [HttpGet]
        [Route("ConfirmEmail", Name = "ConfirmEmailRoute")]
        public async Task<IHttpActionResult> ConfirmEmail(string userId = "", string code = "")
        {
            if (string.IsNullOrWhiteSpace(userId) || string.IsNullOrWhiteSpace(code))
            {
                ModelState.AddModelError("", "User Id and Code are required");
                return BadRequest(ModelState);
            }

            IdentityResult result = await this.AppUserManager.ConfirmEmailAsync(userId, code);

            if (result.Succeeded)
            {
                return Ok();
            }
            else
            {
                return GetErrorResult(result);
            }
        }

        [AllowAnonymous]
        public async Task<IHttpActionResult> Register (RegistrationUserVM model)
        {
            if (model == null)
                return BadRequest("Wypełnij pola");

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            AppUser user = new AppUser
            {
                UserName = model.UserName,
                Email = model.Email
            };

            var result = await AppUserManager.CreateAsync(user, model.Password);
            IHttpActionResult errorResult = GetErrorResult(result);

            var userDb = await AppUserManager.FindByNameAsync(model.UserName);

            await SendVerivicationCode(userDb.Id);

            return Ok();
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<IHttpActionResult> ResendVerificationEmail(string username)
        {
            var result = await AppUserManager.FindByNameAsync(username);

            if(result == null)
                return BadRequest("Nie ma takiego użytkownika");

            await SendVerivicationCode(result.Id);

            return Ok();
        }

        private async Task SendVerivicationCode(string userid)
        {
            string code = await this.AppUserManager.GenerateEmailConfirmationTokenAsync(userid);

            var callbackUrl = new Uri(Url.Link("ConfirmEmailRoute", new { userId = userid, code = code }));

            await this.AppUserManager.SendEmailAsync(userid, "Confirm your account", "Please confirm your account by clicking <a href=\"" + callbackUrl + "\">here</a>");
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
