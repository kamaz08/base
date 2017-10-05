using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Base.Model.Model.Location
{
    public class City
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(64)]
        [Display(Name = "Miasto")]
        public String Name { get; set; }
    }
}