using Base.Model.ViewModel.Orders;
using Base.Model.ViewModel.UserVM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Base.Model.ViewModel.Location
{
    public class AddressVM
    {
        public String Street { get; set; }
        public String ZipCode { get; set; }
        public String HouseNumber { get; set; }
        public String FlatNumber { get; set; }
        public String City { get; set; }
        public String State { get; set; }

        public static implicit operator AddressVM(PersonalDataVM model) => new AddressVM
        {
            Street = model.Street,
            ZipCode = model.ZipCode,
            HouseNumber = model.HouseNumber,
            FlatNumber = model.FlatNumber,
            City = model.City,
            State = model.State,
        };

        public static implicit operator AddressVM(OrderVM model) => new AddressVM
        {
            State = model.State,
            City = model.City,
            Street = model.Street
        };


    }
}