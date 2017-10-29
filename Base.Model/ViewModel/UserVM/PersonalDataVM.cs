using Base.Model.Model.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Base.Model.ViewModel.UserVM
{
    public class PersonalDataVM
    {
        public String FirstName { get; set; }
        public String LastName { get; set; }
        public DateTime? BirthDate { get; set; }
        public String Pesel { get; set; }
        public String PhoneNumber { get; set; }
        public String City { get; set; }
        public String State { get; set; }
        public String Street { get; set; }
        public String ZipCode { get; set; }
        public String HouseNumber { get; set; }
        public String FlatNumber { get; set; }


        public static implicit operator PersonalDataVM(PersonalData model) => new PersonalDataVM
        {
            FirstName = model.FirstName,
            LastName = model.LastName,
            BirthDate = model.BirthDate,
            Pesel = model.Pesel,
            PhoneNumber = model.PhoneNumber,
            City = model.Address != null && model.Address.City != null ? model.Address.City.Name : String.Empty,
            State = model.Address != null && model.Address.State != null ? model.Address.State.Name : String.Empty,
            Street = model.Address != null ? model.Address.Street : String.Empty,
            ZipCode = model.Address != null ? model.Address.ZipCode : String.Empty,
            HouseNumber = model.Address != null ? model.Address.HouseNumber : String.Empty,
            FlatNumber = model.Address != null ? model.Address.FlatNumber : String.Empty,
        };
    }
}