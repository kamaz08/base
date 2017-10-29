using Base.App_Start;
using Base.Model.Model;
using Base.Model.Model.User;
using Base.Model.Repository.User;
using Base.Model.ViewModel.AppUserVM;
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
        private UserRepository _UserRepo;
        public AccountController()
        {
            this._UserRepo = new UserRepository();
        }

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

            AppUser user = _UserRepo.CreateUser(model);

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

        [HttpGet]
        [AllowAnonymous]
        public IHttpActionResult Test()
        {
            PracaDorywczaDbContext x = new PracaDorywczaDbContext();
            var haha = x.Order.ToList();


            AppUser us = AppUserManager.FindByName(RequestContext.Principal.Identity.GetUserName());
            var x1 = x.Order.Add(new Model.Model.OrderModel.Order
            {
                CreatedDate = DateTime.Now,
                ResultDate = DateTime.Now,
                WorkDate = DateTime.Now,
                Name = "test",
                Rate = "chcialbys tyle",
                EmployerId = us.Id
            });
            x.SaveChanges();

            var todele = x.Order.First(r => r.Id == 2);
            x.Order.Where(y => y.Employer == us);

            x.Order.Remove(todele);
            x.SaveChanges();

            return Ok();
        }

        [HttpPost]
        public async Task<IHttpActionResult> ChangeEmail(ChangeEmailVM model)
        {
            if (model == null || !ModelState.IsValid)
                return GetErrorResultModel();

            var user = await GetCurrentUser();
            _UserRepo.ChangeEmail(user.Id, model.Email);

            return Ok();
        }

        [HttpPost]
        public async Task<IHttpActionResult> ChangePassword(ChangePasswordVM model)
        {
            if (model == null || !ModelState.IsValid)
                return GetErrorResultModel();

            var user = await GetCurrentUser();

            var result = await AppUserManager.ChangePasswordAsync(user.Id, model.OldPassword, model.Password);

            if (!result.Succeeded)
                return BadRequest("Niepoprawne hasło");

            return Ok();
        }
    }
}
