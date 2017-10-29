using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Base.Model.Model.User;

namespace Base.Model.ViewModel.UserVM
{
    public class PublicDataVM
    {
        public String Login { get; set; }
        public String FirstName { get; set; }
        public String LastName { get; set; }
        public String BirthDate { get; set; }
        public String PhoneNumber { get; set; }
        public String Email { get; set; }
        public String[] Education { get; set; }
        public String[] Description { get; set; }

        public static implicit operator PublicDataVM(Base.Model.Model.User.AppUser user)
        {
            var result = new PublicDataVM
            {
                Login = user.UserName
            };
            if(user.PersonalProfile != null)
            {
                result.Education = user.PersonalProfile.Education.Split('\n');
                result.Description = user.PersonalProfile.Description.Split('\n');
                if(user.PersonalData != null)
                {
                    result.FirstName = user.PersonalProfile.ShowFirstName ? user.PersonalData.FirstName : String.Empty;
                    result.LastName = user.PersonalProfile.ShowLastName ? user.PersonalData.LastName : String.Empty;
                    result.BirthDate = user.PersonalProfile.ShowBirthDate ? user.PersonalData.BirthDate?.ToShortDateString() : null;
                    result.PhoneNumber = user.PersonalProfile.ShowPhoneNumber ? user.PersonalData.PhoneNumber : String.Empty;
                    result.Email = user.PersonalProfile.ShowEmail ? user.Email : String.Empty;
                }
            }
            return result;
        }
    }
}