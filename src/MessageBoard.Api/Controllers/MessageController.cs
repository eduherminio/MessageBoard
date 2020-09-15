using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using MessageBoard.Model;
using MessageBoard.Api.Attributes;

namespace MessageBoard.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MessageController : ControllerBase
    {
        private readonly AuthorHelper test;

        public MessageController(AuthorHelper test)
        {
            test = test;
        }

        /// <summary>
        /// Retrieve all messages from the board
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ICollection<Message> Get()
        {
            return null;
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
            //test.RequesterIp;

            return null;
        }
    }
}
