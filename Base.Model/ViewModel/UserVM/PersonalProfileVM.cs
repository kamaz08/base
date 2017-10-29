using Base.Model.Model.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Base.Model.ViewModel.UserVM
{
    public class PersonalProfileVM
    {
        public bool ShowFirstName { get; set; }
        public bool ShowLastName { get; set; }
        public bool ShowBirthDate { get; set; }
        public bool ShowPhoneNumber { get; set; }
        public bool ShowEmail { get; set; }
        public String Education { get; set; }
        public String Description { get; set; }


        public static implicit operator PersonalProfileVM(PersonalProfile model) => new PersonalProfileVM
        {
            ShowFirstName = model.ShowFirstName,
            ShowLastName = model.ShowLastName,
            ShowBirthDate = model.ShowBirthDate,
            ShowEmail = model.ShowEmail,
            ShowPhoneNumber = model.ShowPhoneNumber,
            Description = model.Description,
            Education = model.Education
        };
    }
}