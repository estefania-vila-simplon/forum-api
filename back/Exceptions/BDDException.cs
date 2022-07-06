using System.Runtime.Serialization;

namespace back.Exceptions
{
    public class BDDException : Exception
    {
        public BDDException()
        {
        }

        public BDDException(string? message) : base(message)
        {
        }

        public BDDException(string? message, Exception? innerException) : base(message, innerException)
        {
        }

        protected BDDException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
