using System;
using System.Runtime.Serialization;

namespace MessageBoard.Exceptions
{
    [Serializable]
    public class MessageBoardException : Exception
    {
        public MessageBoardException()
        {
        }
        public MessageBoardException(string message) : base(message)
        {
        }

        public MessageBoardException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected MessageBoardException(SerializationInfo serializationInfo, StreamingContext streamingContext) : base(serializationInfo, streamingContext)
        {
        }
    }
}
