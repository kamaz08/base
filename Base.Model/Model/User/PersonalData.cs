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
        [Key]
        public int Id { get; set; }
        [Display(Name = "Imię")]
        [MaxLength(32)]
        public String FirstName { get; set; }
        [Display(Name = "Nazwisko")]
        [MaxLength(32)]
        public String LastName { get; set; }
        [Display(Name = "Data urodzenia")]
        public DateTime BirthDate { get; set; }
        [Display(Name = "Pesel")]
        [MaxLength(11), MinLength(11)]
        public String Pesel { get; set; }
        [Display(Name = "Numer telefonu")]
        [MaxLength(15)]
        public String PhoneNumber { get; set; }
        public String AppUserId { get; set; }
        public virtual AppUser AppUser { get; set; }
        public int AddressId { get; set; }
        public virtual Address Address { get; set; }
        public int RegisteredAddressId { get; set; }
        public virtual Address RegisteredAddress { get; set; }
    }
}