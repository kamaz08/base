using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Base.Model.Model.OrderModel
{
    public class OrderDetail
    {
        public int Id { get; set; }
        public String Description { get; set; }
        public String ExecutionTime { get; set; }
        public String Requirements { get; set; }
        public int OrderId { get; set; }

        public virtual Order Order { get; set; }
    }
}