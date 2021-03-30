using System;
using System.Runtime.Serialization;

namespace BLL.Exceptions
{
    [Serializable]
    public class NoPermissionException : Exception
    {
        public NoPermissionException() { }

        public NoPermissionException(string message) : base(message) { }

        public NoPermissionException(string message, Exception innerException) :
            base(message, innerException) { }

        protected NoPermissionException(SerializationInfo info,
            StreamingContext context) : base(info, context) { }
    }
}