using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace SkyscannerTravel.Exceptions
{
    public class ManyRequestException : Exception
    {
        public ManyRequestException()
        {
        }

        public ManyRequestException(string message) : base(message)
        {
        }

        public ManyRequestException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected ManyRequestException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
