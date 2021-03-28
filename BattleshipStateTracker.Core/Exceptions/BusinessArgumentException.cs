using System;
using System.Runtime.Serialization;

namespace BattleshipStateTracker.Core.Exceptions
{
    public class BusinessArgumentException : ArgumentException
    {
        public BusinessArgumentException()
        {
        }

        public BusinessArgumentException(string message) : base(message)
        {
        }

        public BusinessArgumentException(string message, Exception innerException) : base(message, innerException)
        {
        }

        public BusinessArgumentException(string message, string paramName) : base(message, paramName)
        {
        }

        public BusinessArgumentException(string message, string paramName, Exception innerException) : base(message, paramName, innerException)
        {
        }

        protected BusinessArgumentException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
