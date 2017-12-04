using Base.Model.Model;
using Base.Model.Model.MessageModel;
using Base.Model.Model.OrderModel;
using Base.Model.Model.User;
using Base.Model.ViewModel.Message;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Base.Model.Repository.Message
{
    public class MessageRepository
    {
        private PracaDorywczaDbContext db;

        public MessageRepository()
        {
            this.db = new PracaDorywczaDbContext();
        }


        public List<PublicMessageVM> GetOrderMessages(int orderId, String userId)
        {
            var order = db.Order.Where(x => x.Id == orderId).FirstOrDefault();
            if (order == null) return null;

            var result = order.PublicMessage
                .Where(x => x.AppUserPublicMessage.Any(y => y.AppUserId == userId))
                .OrderByDescending(x => x.Message.Count() > 0 ? x.Message.Max(y => y.Date) : DateTime.MinValue)
                .ToList()
                .Select(x => GetPublicMessage(x, userId))
                .ToList();

            return result;
        }


        public List<PublicMessageVM> GetUserMessages(String userId)
        {
            var hehe = db.AppUserPublicMessage.Where(x => x.AppUserId == userId).First().PublicMessage.Message.Max(x => x.Date);


            var result = db.AppUserPublicMessage
                .Where(x => x.AppUserId == userId)
                .Select(x => x.PublicMessage)
                .OrderByDescending(x => x.Message.Count() > 0 ? x.Message.Max(y => y.Date) : DateTime.MinValue)
                .ToList()
                .Select(x => GetPublicMessage(x, userId))
                .ToList();

            return result;
        }

        public bool SendMessage(String userId, int publicMessageId, String message)
        {
            var publicMessage = db.PublicMessage
                .Where(x => x.Id == publicMessageId)
                .Where(x => x.AppUserPublicMessage.Any(y => y.AppUserId == userId)).FirstOrDefault();
            if (publicMessage == null)
                return false;

            var result = db.Message.Add(new Base.Model.Model.MessageModel.Message
            {
                AppUserId = userId,
                PublicMessageId = publicMessageId,
                Date = DateTime.Now,
                Mess = message
            });

            return db.SaveChanges() != 0;
        }

        public List<MessageVM> GetOldMessages(String userId, int publicMessageId, int messageId)
        {
            var publicMessages = db.PublicMessage
                .Where(x => x.Id == publicMessageId)
                .Where(x => x.AppUserPublicMessage.Any(y => y.AppUserId == userId))
                .FirstOrDefault();

            if (publicMessages == null)
                return null;

            var date = publicMessages.Message
                   .Where(x => x.Id == messageId)
                   .Select(x => x.Date)
                   .FirstOrDefault();

            var result = publicMessages.Message
              .Where(x => x.Date < date)
              .OrderBy(x => x.Date)
              .Take(10)
              .ToList()
              .Select<Model.MessageModel.Message, MessageVM>(x => x)
              .ToList();

            return result;
        }


        public List<MessageVM> GetNewMessages(String userId, int publicMessageId, int? messageId)
        {
            var publicMessages = db.PublicMessage
                .Where(x => x.Id == publicMessageId)
                .Where(x => x.AppUserPublicMessage.Any(y => y.AppUserId == userId))
                .FirstOrDefault();

            if (publicMessages == null)
                return null;


            DateTime? date = null;
            if (messageId.HasValue)
                date = publicMessages.Message
                    .Where(x => x.Id == messageId.Value)
                    .Select(x => x.Date)
                    .FirstOrDefault();


            var result = date.HasValue ?
                publicMessages.Message
                .Where(x => x.Date > date.Value)
                .OrderBy(x => x.Date)
                .Take(10)
                .ToList()
                .Select<Model.MessageModel.Message, MessageVM>(x => x)
                .ToList()
                :
                publicMessages.Message
                .OrderByDescending(x => x.Date)
                .Take(10)
                .ToList()
                .Select<Model.MessageModel.Message, MessageVM>(x => x)
                .Reverse()
                .ToList();

            return result;
        }


        private PublicMessageVM GetPublicMessage(PublicMessage model, String userId)
        {
            return new PublicMessageVM
            {
                Name = model.IsGroup ? "Wszyscy" : string.Join(", ", model.AppUserPublicMessage
                    .Select(x => x.AppUser)
                    .Where(x => x.Id != userId)
                    .Select(x => x.UserName)),
                Id = model.Id,
                OrderId = model.OrderId,
                OrderName = model.Order.Name,
                IsReaded = false
            };
        }

        public void AddUserToPublicMessageGroup(PublicMessage publicMessage, String userId, int? OrderId)
        {
            if (publicMessage == null)
            {
                publicMessage = db.PublicMessage.Add(new PublicMessage
                {
                    Date = DateTime.Now,
                    OrderId = OrderId,
                    IsGroup = true,
                });
                db.SaveChanges();
            }
            else if (publicMessage.AppUserPublicMessage.Any(x => x.AppUserId == userId))
                return;


            db.AppUserPublicMessage.Add(new AppUserPublicMessage
            {
                AppUserId = userId,
                PublicMessageId = publicMessage.Id
            });

            db.SaveChanges();
        }

        public void AddNewOrderMessage(Order order, String userId)
        {
            if (db.PublicMessage
                .Where(x => x.OrderId == order.Id)
                .Where(x => x.IsGroup == false)
                .Where(x => x.AppUserPublicMessage.Any(y => y.AppUserId == userId)).Count() != 0)
                return;

            var publicmess = db.PublicMessage.Add(new PublicMessage
            {
                OrderId = order.Id,
                Date = DateTime.Now,
                IsGroup = false,
            });

            db.SaveChanges();

            db.AppUserPublicMessage.Add(new AppUserPublicMessage
            {
                AppUserId = userId,
                PublicMessageId = publicmess.Id
            });

            db.AppUserPublicMessage.Add(new AppUserPublicMessage
            {
                AppUserId = order.EmployerId,
                PublicMessageId = publicmess.Id
            });

            db.SaveChanges();
        }


        public List<PrivateMessageUserVM> GetOrderPrivateMessageUsers(int orderId, String userId)
        {
            var order = db.Order.Where(x => x.Id == orderId).FirstOrDefault();

            if (order == null) return null;

            if (order.EmployerId == userId)
                return order.Customer
                    .Select(x => x.AppUser)
                    .ToList()
                    .Select<AppUser, PrivateMessageUserVM>(x => x)
                    .ToList();
            else
                return new List<PrivateMessageUserVM> { order.Employer };
        }

        public List<PrivateMessageUserVM> GetPrivateMessageUsers(String userId)
        {
            return db.PrivateMessage
                .Where(x => x.ToAppUserId == userId)
                .OrderByDescending(x => x.Date)
                .Select(x => x.FromAppUser)
                .Distinct()
                .ToList()
                .Select<AppUser, PrivateMessageUserVM>(x => x)
                .ToList();
        }

        public List<MessageVM> GetNewPrivateMessage(String toUserId, String fromUserId, int? orderId, int? messageId)
        {
            DateTime? date = null;
            if (messageId.HasValue)
                date = db.PrivateMessage
                    .Where(x => x.Id == messageId.Value)
                    .Select(x => x.Date)
                    .FirstOrDefault();

            return db.PrivateMessage
                .Where(x => x.ToAppUserId == toUserId)
                .Where(x => x.FromAppUserId == fromUserId)
                .Where(x => orderId.HasValue ? x.OrderId == orderId : true)
                .Where(x => date.HasValue ? x.Date > date : true)
                .OrderByDescending(x => x.Date)
                .Take(10)
                .ToList()
                .Select<PrivateMessage, MessageVM>(x => x)
                .Reverse()
                .ToList();
        }

        public List<MessageVM> GetOldPrivateMessage(String toUserId, String fromUserId, int? orderId, int messageId)
        {
            var date = db.PrivateMessage
                 .Where(x => x.Id == messageId)
                 .Select(x => x.Date)
                 .FirstOrDefault();

            return db.PrivateMessage
                .Where(x => x.ToAppUserId == toUserId)
                .Where(x => x.FromAppUserId == fromUserId)
                .Where(x => orderId.HasValue ? x.OrderId == orderId : true)
                .Where(x => x.Date < date)
                .OrderByDescending(x => x.Date)
                .Take(10)
                .ToList()
                .Select<PrivateMessage, MessageVM>(x => x)
                .Reverse()
                .ToList();
        }

        public bool SendPrivateMessage(String userId, String toUserId, int? OrderId, String message)
        {
            db.PrivateMessage.Add(new PrivateMessage
            {
                ToAppUserId = toUserId,
                FromAppUserId = userId,
                Date = DateTime.Now,
                OrderId = OrderId,
                Message = message
                
            });

            return db.SaveChanges() != 0;
        }

        public bool CheckPublicKey(String userId, String key)
        {
            var user = db.AppUser.Where(x => x.Id == userId).FirstOrDefault();
            if (user == null) return false;

            return user.PublicKey == key;
        }

        public void ChangePublicKey(String userId, String key)
        {
            var user = db.AppUser.Where(x => x.Id == userId).FirstOrDefault();
            if (user == null) return;

            user.PublicKey = key;

            db.SaveChanges();
        }
    }
}