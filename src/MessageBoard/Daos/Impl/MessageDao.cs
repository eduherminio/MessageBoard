using MessageBoard.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace MessageBoard.Daos.Impl
{
    public class MessageDao : IMessageDao
    {
        private readonly DbContext _dbContext;

        public MessageDao(MessageBoardDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Message CreateMessage(Message message)
        {
            message.Id = Guid.NewGuid().ToString();

            message.CreatedDate = DateTime.UtcNow;
            message.LastModifiedDate = message.CreatedDate;

            //message.Author =              TODO
            message.LastModifiedBy = message.Author;

            _dbContext.Add(message);
            _dbContext.SaveChanges();

            return message;
        }

        public ICollection<Message> LoadMessages()
        {
            return new List<Message>(_dbContext.Set<Message>());
        }
    }
}
