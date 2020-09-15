using MessageBoard.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace MessageBoard.Daos.Impl
{
    public class MessageDao : IMessageDao
    {
        private readonly DbContext _dbContext;
        private readonly AuthorHelper _authorHelper;

        public MessageDao(MessageBoardDbContext dbContext, AuthorHelper authorHelper)
        {
            _dbContext = dbContext;
            _authorHelper = authorHelper;
        }

        public Message CreateMessage(Message message)
        {
            message.Id = Guid.NewGuid().ToString();

            message.CreatedDate = DateTime.UtcNow;
            message.LastModifiedDate = message.CreatedDate;

            message.Author = _authorHelper.RequesterIp;
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
