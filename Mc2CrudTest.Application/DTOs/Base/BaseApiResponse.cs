using Mc2.CrudTest.Common.Enum;
using Mc2.CrudTest.Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mc2CrudTest.Application.DTOs.Base
{
    public abstract class BaseApiResponse
    {
        public bool IsSucceed { get; set; } = true;

        public bool IsAccessDenied { get; set; } = false;

        public List<Message> Messages { get; private set; } = new List<Message>();

        protected BaseApiResponse(bool isSucced = true, List<Message> messages = null)
        {
            IsSucceed = isSucced;

            if (messages != null)
            {
                Messages = messages;
            }
        }

        public void AddMessage(Message message)
        {
            if (Messages == null)
                Messages = new List<Message>();

            Messages.Add(message);
        }

        public void AddMessageRange(List<Message> message)
        {
            if (Messages == null)
                Messages = new List<Message>();

            Messages.AddRange(message);
        }

        public void ClearMessages()
        {
            Messages.Clear();
        }

        public void Failed()
        {
            IsSucceed = false;
        }

        public void AccessDenied()
        {
            IsAccessDenied = true;

            Failed();
        }

        public void Succeed()
        {
            IsSucceed = true;
        }

        public void SuccessMessage(string message = null, string data = null)
        {
            AddMessage(new Message
            {
                Title = "Successful !",
                Body = message != null ? message : "The process was successful.",
                Type = MessageType.Success
            });
        }

        public void FailedMessage(string message = null, string data = null)
        {
            AddMessage(new Message
            {
                Title = "Failed !",
                Body = message != null ? message : "The operation failed.",
                Type = MessageType.Error
            });
        }

        public void WarningMessage(string message, string data = null)
        {
            AddMessage(new Message
            {
                Title = "Warring !",
                Body = message,
                Type = MessageType.Warning,
            });
        }
    }

    public class BaseApiResponse<T> : BaseApiResponse
    {
        public T Result { get; set; }
    }
}
