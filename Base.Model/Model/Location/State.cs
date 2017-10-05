using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Base.Model.Model.Location
{
    public class State
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(64)]
        [Display(Name = "Województwo")]
        public String Name { get; set; }
    }
}