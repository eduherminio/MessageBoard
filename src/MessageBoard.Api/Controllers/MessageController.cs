using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using MessageBoard.Services;
using MessageBoard.Model;
using MessageBoard.Api.Attributes;

namespace MessageBoard.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MessageController : ControllerBase
    {
        private readonly IMessageService _messageService;

        public MessageController(IMessageService messageService)
        {
            _messageService = messageService;
        }

        /// <summary>
        /// Retrieve all messages from the board
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ICollection<Message> Get()
        {
            return _messageService.LoadMessages();
        }

        /// <summary>
        /// Add a message to the board
        /// </summary>
        /// <param name="message"></param>
        /// <returns></returns>
        [HttpPost]
        [ServiceFilter(typeof(AuthorFilterAttribute))]
        public Message Create(Message message)
        {
            return _messageService.CreateMessage(message);
        }
    }
}
