using Base.Model.Model.Location;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;


namespace Base.Model.Model.User
{
    public class PersonalData
    {
        public int id { get; set; }
        public String AppUserId { get; set; }
        public int? AddressId { get; set; }
        public String FirstName { get; set; }
        public String LastName { get; set; }
        public DateTime BirthDate { get; set; }
        public String Pesel { get; set; }
        public String PhoneNumber { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateModifield { get; set; }

        public virtual Address Address { get; set; }
        public virtual AppUser AppUser {get;set;}
    }
}