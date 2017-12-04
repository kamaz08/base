using Base.Model.Model.OrderModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Base.Model.ViewModel.Orders
{
    public class OrderDisplayVM
    {
        public int Id { get; set; }
        public String Name { get; set; }
        public String Rate { get; set; }
        public int NumberOfEmploye { get; set; }
        public String Category { get; set; }

        public String State { get; set; }
        public String City { get; set; }
        public String Street { get; set; }

        public String ResultDate { get; set; }
        public String WorkDate { get; set; }

        public String EmployerName { get; set; }
        public String EmployerId { get; set; }

        public String[] Description { get; set; }
        public String ExecutionTime { get; set; }
        public String[] Requirements { get; set; }
        public bool IsOpen { get; set; }

        public static implicit operator OrderDisplayVM(Order model) => new OrderDisplayVM
        {
            Id = model.Id,
            Name = model.Name,
            Rate = model.Rate,
            NumberOfEmploye = model.NumberOfEmploye,
            Category = model.Category?.Name,
            State = model.Address?.State?.Name,
            City = model.Address?.City?.Name,
            Street = model.Address?.Street,
            ResultDate = model.ResultDate.ToShortDateString(),
            WorkDate = model.WorkDate.ToShortDateString(),
            EmployerName = model.Employer.UserName,
            EmployerId = model.Employer.Id,
            Description = model.OrderDetail?.Description.Split('\n'),
            Requirements = model.OrderDetail?.Requirements.Split('\n'),
            IsOpen = model.IsOpen
        };
    }
}