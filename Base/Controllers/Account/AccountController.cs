using Base.App_Start;
using Base.Model.Model.User;
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
    public class AccountController : BaseController
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
                return BadRequest("Nieporawny link");
            

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
            if (model == null || !ModelState.IsValid)
                return GetErrorResultModel();

            AppUser user = new AppUser
            {
                UserName = model.UserName,
                Email = model.Email,
                TwoFactorEnabled = true
            };

            var result = await AppUserManager.CreateAsync(user, model.Password);

            if (!result.Succeeded)
                return BadRequest("Uzytkownik jest zajęty");

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

        [HttpGet]
        [AllowAnonymous]
        public async Task<IHttpActionResult> LoginOtpCode(string login)
        {
            if (string.IsNullOrEmpty(login))
                return BadRequest("Podaj dane");

            var user = await AppUserManager.FindByNameAsync(login);

            if (user == null)
                return BadRequest("Nie ma takiego użytkownika");

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
    }
}
