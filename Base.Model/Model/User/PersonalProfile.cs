using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Base.Model.Model.User
{
    public class PersonalProfile
    {
        [Key]
        public int Id { get; set; }
        public String PhotoUrl { get; set; }
        public bool ShowFirstName { get; set; }
        public bool ShowLastName { get; set; }
        public bool ShowBirthDate { get; set; }
        public bool ShowPhoneNumber { get; set; }
        public bool ShowEmail { get; set; }
        public String Education { get; set; }
        public String Description { get; set; }
        public String AppUserId { get; set; }
        public virtual AppUser AppUser { get; set; }

    }
}