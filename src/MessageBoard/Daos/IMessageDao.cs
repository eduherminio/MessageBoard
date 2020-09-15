using MessageBoard.Model;
using System.Collections.Generic;

namespace MessageBoard.Daos
{
    public interface IMessageDao
    {
        ICollection<Message> LoadMessages();

        Message CreateMessage(Message message);
    }
}
