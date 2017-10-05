using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Base.Model.Model.OrderModel
{
    public class OrderDetail
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "Szczegóły")]
        public String Description { get; set; }

        [Display(Name = "Czas wykonania")]
        public String ExecutionTime { get; set; }

        [Display(Name = "Wymagania")]
        public String Requirements { get; set; }

        public virtual Order Order { get; set; }
    }
}