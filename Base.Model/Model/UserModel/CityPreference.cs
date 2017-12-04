using Base.Model.Model.Location;
using Base.Model.Model.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Base.Model.Model.User
{
    public class CityPreference
    {
        public int Id { get; set; }
        public String AppUserId { get; set; }
        public int CityId { get; set; }

        public virtual AppUser AppUser { get; set; }
        public virtual City City { get; set; }
    }
}