using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Base.Model.Model.User
{
    public class Address
    {
        [Key]
        public int Id { get; set; }
        [Display(Name = "Miasto")]
        [MaxLength(64)]
        public String City { get; set; }
        [Display(Name = "Województwo")]
        [MaxLength(64)]
        public String State { get; set; }
        [Display(Name = "Ulica")]
        [MaxLength(64)]
        public String Street { get; set; }
        [Display(Name = "Kod pocztowy")]
        [MaxLength(8)]
        public String ZipCode { get; set; }
        [Display(Name = "Numer domu")]
        [MaxLength(8)]
        public String HouseNumber { get; set; }
        [Display(Name = "Numer mieszkania")]
        [MaxLength(8)]
        public String FlatNumber { get; set; }
        [Required]
        [Display(Name = "Data dodania")]
        public DateTime DateCreated { get; set; }
        [Required]
        [Display(Name = "Data modyfikacji")]
        public DateTime DateModifield { get; set; }
        public String AppUserId { get; set; }
        public virtual AppUser AppUser {get;set;}
    }

}