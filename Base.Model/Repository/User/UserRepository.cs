using Base.Model.Model;
using Base.Model.Model.User;
using Base.Model.ViewModel.AppUserVM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Base.Model.Repository.User
{
    public class UserRepository
    {
        private  PracaDorywczaDbContext db;

        public UserRepository()
        {
            this.db = new PracaDorywczaDbContext();
        }

        public AppUser CreateUser(RegistrationUserVM user)
        {
            return new AppUser
            {
                UserName = user.UserName,
                Email = user.Email,
                DateCreated = DateTime.Now,
                TwoFactorEnabled = true
            };
        }

        public void ChangeEmail(string userId, string email)
        {
            db.Users.Where(x => x.Id == userId).First().Email = email;
            db.SaveChanges();
        }
    }
}