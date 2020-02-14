using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace SkyscannerTravel.Exceptions
{
    public class ManyRequestsException : Exception
    {
        public ManyRequestsException()
        {

        }

        public ManyRequestsException(string message) : base(message)
        {
        }

        public ManyRequestsException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected ManyRequestsException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
