using System;
using System.Runtime.Serialization;

namespace BattleshipStateTracker.Core.Exceptions
{
    public class BusinessObjectNotFoundException : Exception
    {
        public BusinessObjectNotFoundException()
        {
        }

        public BusinessObjectNotFoundException(string message) : base(message)
        {
        }

        public BusinessObjectNotFoundException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected BusinessObjectNotFoundException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
