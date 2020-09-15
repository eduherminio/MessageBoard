using MessageBoard.Model;
using MessageBoard.Daos;
using System.Collections.Generic;
using MessageBoard.Exceptions;

namespace MessageBoard.Services.Impl
{
    public class MessageService : IMessageService
    {
        private readonly IMessageDao _messageRepository;

        public MessageService(IMessageDao messageRepository)
        {
            _messageRepository = messageRepository;
        }

        public Message CreateMessage(Message message)
        {
            if (string.IsNullOrWhiteSpace(message.Content))
            {
                throw new MessageBoardException("Messages require a non empty content");
            }

            return _messageRepository.CreateMessage(message);
        }

        public ICollection<Message> LoadMessages()
        {
            return _messageRepository.LoadMessages();
        }
    }
}
