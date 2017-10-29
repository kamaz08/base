using Base.Model.Model.OrderModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Base.Model.ViewModel.Orders
{
    public class OrderVM
    {
        public String Name { get; set; }
        public String Rate { get; set; }
        public int NumberOfEmploye { get; set; }
        public String Category { get; set; }

        public String State { get; set; }
        public String City { get; set; }
        public String Street { get; set; }

        public DateTime ResultDate { get; set; }
        public DateTime WorkDate { get; set; }


        public String Description { get; set; }
        public String ExecutionTime { get; set; }
        public String Requirements { get; set; }

        public static implicit operator OrderVM(Order model) => new OrderVM
        {
            Name = model.Name,
            Rate = model.Rate,
            NumberOfEmploye = model.NumberOfEmploye,
            Category = model.Category?.Name,
            State = model.Address?.State?.Name,
            City = model.Address?.City?.Name,
            Street = model.Address?.Street,
            ResultDate = model.ResultDate,
            WorkDate = model.WorkDate,
        };
    }
}