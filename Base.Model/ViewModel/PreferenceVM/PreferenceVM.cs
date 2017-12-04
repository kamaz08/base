using Base.Model.Model.Location;
using Base.Model.Model.OrderModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Base.Model.ViewModel.PreferenceVM
{
    public class PreferenceVM
    {
        public int Id { get; set; }
        public String Name { get; set; }
        public bool Selected { get; set; }

        public static implicit operator PreferenceVM(City model) => new PreferenceVM
        {
            Id = model.Id,
            Name = model.Name,
            Selected = false,
        };

        public static implicit operator PreferenceVM(OrderCategory model) => new PreferenceVM
        {
            Id = model.Id,
            Name = model.Name,
            Selected = false
        };
    }


}