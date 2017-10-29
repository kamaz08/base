using Base.Model.Model;
using Base.Model.Model.User;
using Base.Model.Repository.Location;
using Base.Model.ViewModel.Location;
using Base.Model.ViewModel.UserVM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace Base.Model.Repository.User
{
    public class PersonalDataRepository
    {
        private PracaDorywczaDbContext db;

        public PersonalDataRepository()
        {
            this.db = new PracaDorywczaDbContext();
        }

        public async Task SavePersonalData(string userName, PersonalDataVM data)
        {
            var user = db.AppUser.Where(x => x.UserName == userName).First();

            if (user.PersonalData == null)
                user.PersonalData = db.PersonalData.Add(new PersonalData
                {
                    AppUserId = user.Id,
                    DateCreated = DateTime.Now,
                });

            user.PersonalData.FirstName = data.FirstName;
            user.PersonalData.LastName = data.LastName;
            user.PersonalData.BirthDate = data.BirthDate;
            user.PersonalData.Pesel = data.Pesel;
            user.PersonalData.PhoneNumber = data.PhoneNumber;
            user.PersonalData.DateModifield = DateTime.Now;

            user.PersonalData.Address = new LocationRepository().AddOrUpdate(data, user.PersonalData.Address);

            var res = await db.SaveChangesAsync();
        }

        public PersonalDataVM GetPersonalData(string userName)
        {
            var user = db.AppUser.Where(x => x.UserName == userName).First();
            return user.PersonalData ?? new PersonalDataVM();
        }

        public PersonalProfileVM GetPersonalProfile(string userId)
        {
            var user = db.AppUser.Where(x => x.Id == userId).First();
            return user.PersonalProfile ?? new PersonalProfileVM();
        }

        public async Task SavePersonalProfile(string userId, PersonalProfileVM data)
        {
            var user = db.AppUser.Where(x => x.Id == userId).First();

            if (user.PersonalProfile == null)
                user.PersonalProfile = db.PersonalProfile.Add(new PersonalProfile
                {
                    AppUserId = userId
                });

            user.PersonalProfile.ShowFirstName = data.ShowFirstName;
            user.PersonalProfile.ShowLastName = data.ShowLastName;
            user.PersonalProfile.ShowBirthDate = data.ShowBirthDate;
            user.PersonalProfile.ShowEmail = data.ShowEmail;
            user.PersonalProfile.ShowPhoneNumber = data.ShowPhoneNumber;
            user.PersonalProfile.Education = data.Education;
            user.PersonalProfile.Description = data.Description;

            var res = await db.SaveChangesAsync();
        }

        public PublicDataVM GetPublicDataVM(String userId)
        {
            var result = db.AppUser.Where(x => x.Id == userId).FirstOrDefault();

            if (result == null)
                return null;

            return result;
        }

    }
}