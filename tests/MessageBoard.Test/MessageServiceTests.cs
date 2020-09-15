using MessageBoard.Model;
using MessageBoard.Daos;
using MessageBoard.Services;
using MessageBoard.Services.Impl;
using Moq;
using Xunit;
using MessageBoard.Exceptions;

namespace MessageBoard.Test
{
    public class MessageServiceTests
    {
        private readonly IMessageService _messageService;
        private readonly Mock<IMessageDao> _daoMock;

        public MessageServiceTests()
        {
            _daoMock = new Mock<IMessageDao>();
            _messageService = new MessageService(_daoMock.Object);
        }

        [Fact]
        public void CreateMessage()
        {
            // Arrange
            var messageToCreate = new Message() { Content = "CreateMessage" };

            _daoMock
                .Setup(d => d.CreateMessage(It.IsAny<Message>()))
                .Returns((Message m) => m);

            // Act
            var createdMessage = _messageService.CreateMessage(messageToCreate);

            // Assert
            Assert.Equal(messageToCreate, createdMessage);
            _daoMock.Verify(m => m.CreateMessage(messageToCreate), Times.Once);
        }

        [Fact]
        public void LoadMessages()
        {
            var createdMessage = new Message() { Content = "LoadMessages" };

            _daoMock
                .Setup(d => d.LoadMessages())
                .Returns(new[] { createdMessage });

            // Act
            var retrievedMessages = _messageService.LoadMessages();

            // Assert
            Assert.Single(retrievedMessages);
            Assert.Contains(createdMessage, retrievedMessages);
            _daoMock.Verify(m => m.LoadMessages(), Times.Once);
        }

        [Fact]
        public void ShouldNotCreateAnEmptyMessage()
        {
            // Arrange
            var messageToCreate = new Message() { Content = "" };

            // Act
            Assert.Throws<MessageBoardException>(() => _messageService.CreateMessage(messageToCreate));

            // Assert
            _daoMock.Verify(m => m.CreateMessage(messageToCreate), Times.Never);
        }
    }
}
