using System;
using System.Runtime.Serialization;

namespace ByteBank
{
    [Serializable]
    internal class FileNotException : Exception
    {
        public FileNotException()
        {
        }

        public FileNotException(string message) : base(message)
        {
        }

        public FileNotException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected FileNotException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}