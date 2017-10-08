using Base.Model.Model.User;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Base.Model.Model.Location
{
    public class Address
    {
        public int Id { get; set; }

        public String Street { get; set; }
        public String ZipCode { get; set; }
        public String HouseNumber { get; set; }
        public String FlatNumber { get; set; }
        public int? CityId { get; set; }
        public int? StateId { get; set; }

        public virtual City City { get; set; }
        public virtual State State { get; set; }
    }

}