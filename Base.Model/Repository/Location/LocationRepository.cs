using Base.Model.Model;
using Base.Model.Model.Location;
using Base.Model.ViewModel.Location;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace Base.Model.Repository.Location
{
    public class LocationRepository
    {
        private PracaDorywczaDbContext db;

        public LocationRepository()
        {
            this.db = new PracaDorywczaDbContext();
        }

        public Address AddOrUpdate(AddressVM data, Address model)
        {
            var cityName = GetFirstCharakterUpper(data.City);

            var city = db.City.Where(x => x.Name == cityName).FirstOrDefault();
            if (city == null)
                city = db.City.Add(new City { Name = cityName });

            var stateName = GetFirstCharakterUpper(data.State);
            var state = db.State.Where(x => x.Name == stateName).FirstOrDefault();
            if (state == null)
                state = db.State.Add(new State { Name = stateName });

            if (model == null)
                model = db.Address.Add(new Address());


            if(city.Id == 0)
                model.City = city;
            else
                model.CityId = city.Id;

            if (state.Id == 0)
                model.State = state;
            else
                model.StateId = state.Id;

            model.HouseNumber = data.HouseNumber;
            model.FlatNumber = data.FlatNumber;
            model.Street = data.Street;
            model.ZipCode = data.ZipCode;

            return model;
        }


        private String GetFirstCharakterUpper(String text)
        {
            text = text.ToLower();
            String[] tab = text.Split(' ');
            return String.Join(" ", tab.Where(x => x.Length > 0).Select(x => Char.ToUpper(x[0]) + x.Substring(1)));
        }

    }
}