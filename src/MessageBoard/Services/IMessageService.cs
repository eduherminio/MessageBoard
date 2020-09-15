using System;
using System.Collections.Generic;
using System.Text;
using MessageBoard.Model;

namespace MessageBoard.Services
{
    public interface IMessageService
    {
        ICollection<Message> LoadMessages();

        Message CreateMessage(Message message);
    }
}
