using MessageBoard.Daos;
using MessageBoard.Daos.Impl;
using MessageBoard.Model;
using Microsoft.EntityFrameworkCore;
using Moq;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using Xunit;

namespace MessageBoard.Test
{
    public class MessageDaoTests
    {
        private readonly MessageBoardDbContext _dbContext;
        private readonly IMessageDao _dao;

        public MessageDaoTests()
        {
            var dbContextOptionsBuilder = new DbContextOptionsBuilder<MessageBoardDbContext>();
            dbContextOptionsBuilder.UseInMemoryDatabase(Assembly.GetAssembly(typeof(MessageDaoTests)).GetName().Name);
            _dbContext = new MessageBoardDbContext(dbContextOptionsBuilder.Options);

            _dao = new MessageDao(_dbContext);
        }

        [Fact]
        public void CreateMessage()
        {
            // Arrange
            var messageToCreate = new Message()
            {
                Content = "CreateMessage"
            };

            var previousDate = DateTime.UtcNow;

            // Act
            var createdMessage = _dao.CreateMessage(messageToCreate);

            // Assert
            Assert.NotNull(createdMessage.Id);
            Assert.Equal(messageToCreate.Content, createdMessage.Content);

            Assert.Equal(createdMessage.CreatedDate, createdMessage.LastModifiedDate);

            Assert.True(previousDate < createdMessage.CreatedDate);
            Assert.True(DateTime.UtcNow > createdMessage.CreatedDate);
        }

        [Fact]
        public void LoadMessages()
        {
            // Arrange
            var createdMessage = new Message()
            {
                Content = "LoadMessages"
            };
            _dbContext.Set<Message>().Add(createdMessage);
            _dbContext.SaveChanges();

            // Act
            var messages = _dao.LoadMessages();

            // Assert
            Assert.Contains(createdMessage, messages);
        }
    }
}
