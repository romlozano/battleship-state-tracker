using System;
using System.Runtime.Serialization;

namespace BattleshipStateTracker.Core.Exceptions
{
    public class ShipCollisionException : Exception
    {
        public ShipCollisionException()
        {
        }

        public ShipCollisionException(string message) : base(message)
        {
        }

        public ShipCollisionException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected ShipCollisionException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
