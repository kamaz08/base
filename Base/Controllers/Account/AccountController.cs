using Base.App_Start;
using Base.Model.Model;
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
    [Authorize]
    public class AccountController : ApiController
    {
        private AppUserManager _AppUserManager = null;
        protected AppUserManager AppUserManager => _AppUserManager ?? Request.GetOwinContext().GetUserManager<AppUserManager>();

        public AccountController() { }

        [HttpGet]
        [AllowAnonymous]
        [Route("ConfirmEmail", Name = "ConfirmEmailRoute")]
        public async Task<IHttpActionResult> ConfirmEmail(string userId, string code)
        {
            if (string.IsNullOrWhiteSpace(userId) || string.IsNullOrWhiteSpace(code))
            {
                ModelState.AddModelError("", "Nie poprawny link");
                return BadRequest(ModelState);
            }

            IdentityResult result = await AppUserManager.ConfirmEmailAsync(userId, code);
            if (result.Succeeded)
                return Ok();
            else
                return GetErrorResult(result);
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IHttpActionResult> Register(RegistrationUserVM model)
        {
            if (model == null)
            {
                ModelState.AddModelError("", "Wypełnij pola");
                return BadRequest(ModelState);
            }

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            AppUser user = new AppUser
            {
                UserName = model.UserName,
                Email = model.Email,
                TwoFactorEnabled = true
            };

            var result = await AppUserManager.CreateAsync(user, model.Password);

            if (!result.Succeeded)
                return GetErrorResult(result);

            var userDb = await AppUserManager.FindByNameAsync(model.UserName);
            await SendVerivicationCode(userDb.Id);

            return Ok();
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<IHttpActionResult> ResendVerificationEmail(string username)
        {
            var result = await AppUserManager.FindByNameAsync(username);

            if (result == null)
                return BadRequest("Nie ma takiego użytkownika");

            await SendVerivicationCode(result.Id);

            return Ok();
        }

        public class nodobra
        {
            public string grant_type { get; set; }
            public string username { get; set; }
            public string password { get; set; }
            public string otpkey { get; set; }
        }


        [HttpPost]
        [AllowAnonymous]
        public async Task<IHttpActionResult> TestProsze(nodobra fuck)
        {
            var user = await AppUserManager.FindByNameAsync("asd");


            return Ok("kurde");
        }


        [HttpGet]
        [AllowAnonymous]
        public async Task<IHttpActionResult> LoginOtpCode(string login)
        {
            if (string.IsNullOrEmpty(login))
            {
                ModelState.AddModelError("", "Nie ma takiego użytkownika");
                return BadRequest(ModelState);
            }

            var user = await AppUserManager.FindByNameAsync(login);

            if (user == null)
            {
                ModelState.AddModelError("", "Nie ma takiego użytkownika");
                return BadRequest(ModelState);
            }

            await SendTwoFactorAuthoriazation(user.Id);

            return Ok();
        }

        #region SendEmail
        private async Task SendVerivicationCode(string userid)
        {
            string code = await AppUserManager.GenerateEmailConfirmationTokenAsync(userid);
            var callbackUrl = new Uri(Url.Link("ConfirmEmailRoute", new { userId = userid, code = code }));
            await AppUserManager.SendEmailAsync(userid, "Potwierdź swoje konto", "Proszę potwierdź swój adres email klikając w <a href=\"" + callbackUrl + "\">Ten link</a>");
        }


        public async Task SendTwoFactorAuthoriazation(string userid)
        {
            string code = await AppUserManager.GenerateTwoFactorTokenAsync(userid, "Email Code");

            await AppUserManager.SendEmailAsync(userid, "Twoje jednorazowe hasło ", $"Twoje jednorazowe hasło to {code}");
        }

        #endregion

        #region helper
        private IHttpActionResult GetErrorResult(IdentityResult result)
        {
            if (result == null)
                return InternalServerError();

            if (!result.Succeeded)
            {
                if (result.Errors != null)
                    foreach (string error in result.Errors)
                        ModelState.AddModelError("", error);

                if (ModelState.IsValid)
                    return BadRequest();

                return BadRequest(ModelState);
            }

            return null;
        }

        #endregion
    }
}
