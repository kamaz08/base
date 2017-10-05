using Base.Model.Model.User;
using Base.Model.Model.Location;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Base.Model.Model.OrderModel
{
    public class Order
    {
        [Key]
        public int Id { get; set; }

        [Display(Name ="Nazwa zlecenia")]
        [Required]
        [MaxLength(128)]
        public String Name { get; set; }

        [Display(Name = "Stawka")]
        [Required]
        [MaxLength(64)]
        public String Rate { get; set; }

        [Display(Name = "Ilość osób")]
        public int NumberOfEmploye { get; set; }

        [Display(Name = "Adres zlecenia")]
        public Address Address { get; set; }

        [Display(Name = "Data utworzenia")]
        public DateTime CreatedDate { get; set; }

        [Display(Name = "Data wyników")]
        public DateTime ResultDate { get; set; }

        [Display(Name = "Data pracy")]
        public DateTime WorkDate { get; set; }

        public String AppUserId { get; set; }
        [Display(Name ="Pracodawca")]
        public virtual AppUser Employer { get; set; }

        public virtual OrderDetail OrderDetail { get; set; }

        public virtual ICollection<AppUserOrderCandidate> Candidate { get; set; }
        public virtual ICollection<AppUserOrderCustomer> Customer { get; set; }

    }
}