using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace EntLib6Lab.Application.ExceptionHandling
{
    /// <summary>
    /// Exception for showing user friendly exception message
    /// </summary>
    [Serializable]
    public class NotifyException : Exception
    {
        public NotifyException()
            : base()
        {
        }

        public NotifyException(string message)
            : base(message)
        {
        }

        public NotifyException(string message, Exception inner)
            : base(message, inner)
        {
        }

        // This constructor is needed for serialization.
        protected NotifyException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }
    }
}
