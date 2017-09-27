using Base.Model.Model;
using Base.Model.ViewModel.AppUser;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace Base.Model.Repository
{
    public class AuthRepository : IDisposable
    {
        private PracaDorywczaDbContext _context;
        private UserManager<AppUser> _userManager;

        public AuthRepository()
        {
            _context = new PracaDorywczaDbContext();
            _userManager = new UserManager<AppUser>(new UserStore<AppUser>(_context));
        }

        public async Task<IdentityResult> RegisterAppUser(RegistrationUserVM model)
        {
            AppUser user = new AppUser
            {
                UserName = model.UserName,
                Email = model.Email
            };

            var result = await _userManager.CreateAsync(user, model.Password);

            return result;
        }

        public async Task<AppUser> FindUser(string login, string password)
        {
            AppUser user = await _userManager.FindAsync(login, password);

            return user;
        }

        public void Dispose()
        {
            _context.Dispose();
            _userManager.Dispose();
        }
    }
}