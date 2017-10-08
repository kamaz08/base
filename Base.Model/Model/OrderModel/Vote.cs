using Base.Model.Model.Enum;
using Base.Model.Model.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Base.Model.Model.OrderModel
{
    public class Vote
    {
        public int Id { get; set; }
        public VoteTypeEnum Type { get; set; }
        public String AppUserId { get;set;}
        public String RaterId { get; set; }
        public String OrderName { get; set; }
        public DateTime VoteDate { get; set; }
        public int Note { get; set; }
        public String Description { get; set; }

        public virtual AppUser AppUser { get; set; }
        public virtual AppUser Rater { get; set; }
    }
}