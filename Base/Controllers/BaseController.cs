using Base.App_Start;
using Base.Model.Model.User;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.ModelBinding;

namespace Base.Controllers
{
    public class BaseController : ApiController
    {
        private AppUserManager _AppUserManager = null;
        protected AppUserManager AppUserManager => _AppUserManager ?? Request.GetOwinContext().GetUserManager<AppUserManager>();

        protected IHttpActionResult GetErrorResult(IdentityResult result)
        {
            string errMessage = string.Empty;
            if (result == null)
                return InternalServerError();

            if (!result.Succeeded)
            {
                if (result.Errors != null)
                    errMessage = String.Join("\n", result.Errors);

                if (ModelState.IsValid)
                    return BadRequest();

                return BadRequest(errMessage);
            }
            return null;
        }

        protected IHttpActionResult GetErrorResultModel()
        {
            string errMessage = String.Join("\n", ModelState.SelectMany(x => x.Value.Errors.Select(y => y.ErrorMessage)));

            return BadRequest(errMessage);
        }

        protected async Task SendVerivicationCode(string userid)
        {
            string code = await AppUserManager.GenerateEmailConfirmationTokenAsync(userid);
            var callbackUrl = new Uri(Url.Link("ConfirmEmailRoute", new { userId = userid, code = code }));
            await AppUserManager.SendEmailAsync(userid, "Potwierdź swoje konto", "Proszę potwierdź swój adres email klikając w <a href=\"" + callbackUrl + "\">Ten link</a>");
        }

        protected async Task SendTwoFactorAuthoriazation(string userid)
        {
            string code = await AppUserManager.GenerateTwoFactorTokenAsync(userid, "Email Code");
            await AppUserManager.SendEmailAsync(userid, "Twoje jednorazowe hasło ", $"Twoje jednorazowe hasło to {code}");
        }

        protected async Task SendOTP(string userid, string purpose)
        {
            string code = await AppUserManager.GenerateTwoFactorTokenAsync(userid, purpose);
            await AppUserManager.SendEmailAsync(userid, "Twoje jednorazowe hasło ", $"Twoje jednorazowe hasło to {code}");
        }

        protected async Task<AppUser> GetCurrentUserAsync()
        {
            return await AppUserManager.FindByNameAsync(RequestContext.Principal.Identity.GetUserName());
        }

        protected AppUser GetCurrentUser()
        {
            return AppUserManager.FindByName(RequestContext.Principal.Identity.GetUserName());
        }
    }
}
