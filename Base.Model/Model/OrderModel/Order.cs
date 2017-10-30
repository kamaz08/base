using Base.Model.Model.User;
using Base.Model.Model.Location;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Base.Model.Model.MessageModel;

namespace Base.Model.Model.OrderModel
{
    public class Order
    {
        public int Id { get; set; }
        public String Name { get; set; }
        public String Rate { get; set; }
        public int NumberOfEmploye { get; set; }
        public bool IsOpen { get; set; }

        public int? AddressId { get; set; }
        public Address Address { get; set; }

        public DateTime CreatedDate { get; set; }
        public DateTime ResultDate { get; set; }
        public DateTime WorkDate { get; set; }

        public String EmployerId { get; set; }
        public virtual AppUser Employer { get; set; }

        public int CategoryId { get; set; }
        public virtual OrderCategory Category { get; set; }

        public virtual OrderDetail OrderDetail { get; set; }

        public virtual ICollection<AppUserOrderCustomer> Customer { get; set; }
        public virtual ICollection<PrivateMessage> PrivateMessage { get; set; }

    }
}