using Base.Model.Repository.Message;
using Base.Model.ViewModel.Message;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Base.Controllers.Message
{
    [Authorize]
    public class MessageController : BaseController
    {
        private MessageRepository messageRepository;

        public MessageController()
        {
            messageRepository = new MessageRepository();
        }

        [HttpGet]
        public List<MessageVM> GetMessages(int publicMessageId, int? lastMessage)
        {
            var user = GetCurrentUser();

            var result = messageRepository.GetNewMessages(user.Id, publicMessageId, lastMessage);

            return result;
        }

        [HttpGet]
        public List<MessageVM> GetOldMessages(int publicMessageId, int lastMessage)
        {
            var user = GetCurrentUser();

            var result = messageRepository.GetOldMessages(user.Id, publicMessageId, lastMessage);

            return result;
        }

        [HttpGet]
        public List<PublicMessageVM> GetPublicMessages(int? orderId)
        {
            var user = GetCurrentUser();
            var result = orderId.HasValue ? messageRepository.GetOrderMessages(orderId.Value, user.Id)
                : messageRepository.GetUserMessages(user.Id);

            return result;
        }

        [HttpPost]
        public IHttpActionResult SendMessage(NameVM mess)
        {
            var user = GetCurrentUser();

            if (messageRepository.SendMessage(user.Id, mess.Id, mess.Name)) return Ok();

            return BadRequest("Nie możesz wysłać wiadomości");
        }

        [HttpPost]
        public IHttpActionResult SendPrivateMessage(PrivMess mess)
        {
            var user = GetCurrentUser();

            if (messageRepository.SendPrivateMessage(user.Id, mess.ToUserId, mess.OrderId, mess.Message)) return Ok();

            return BadRequest("Nie możesz wysłać wiadomości");
        }

        [HttpGet]
        public List<MessageVM> GetPrivateMessages(String userId, int? orderId, int? lastMessage)
        {
            var user = GetCurrentUser();

            var result = messageRepository.GetNewPrivateMessage(user.Id, userId, orderId, lastMessage);

            return result;
        }

        [HttpGet]
        public List<MessageVM> GetOldPrivateMessages(String userId, int? orderId, int lastMessage)
        {
            var user = GetCurrentUser();

            var result = messageRepository.GetOldPrivateMessage(user.Id, userId, orderId, lastMessage);

            return result;
        }

        [HttpGet]
        public List<PrivateMessageUserVM> GetPrivateMessagesUser(int? orderId)
        {
            var user = GetCurrentUser();
            var result = orderId.HasValue ? messageRepository.GetOrderPrivateMessageUsers(orderId.Value, user.Id)
                : messageRepository.GetPrivateMessageUsers(user.Id);

            return result;
        }

        [HttpPost]
        public IHttpActionResult CheckPublicKey(ShortName pubkey)
        {
            var user = this.GetCurrentUser();

            if (!messageRepository.CheckPublicKey(user.Id, pubkey.Name)) return BadRequest("Nie poprawny klucz lub hasło");

            return Ok();
        }

        [HttpPost]
        public IHttpActionResult UpdatePublicKey(ShortName pubkey)
        {
            var user = this.GetCurrentUser();

            messageRepository.ChangePublicKey(user.Id, pubkey.Name);

            return Ok();
        }

        public class ShortName
        {
            public String Name;
        }


        public class NameVM
        {
            public int Id { get; set; }
            public String Name { get; set; }
        }

        public class PrivMess
        {
            public String ToUserId { get; set; }
            public int? OrderId { get; set; }
            public String Message { get; set; }
        }
    }
}
