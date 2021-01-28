using System;
using System.Runtime.Serialization;

namespace HandlingException.CustomException
{
    // .NET custom exception template
    // add the Serializable attribute, to make sure that your exception can be serialized 
    // and works correctly across application domains
    [Serializable]
    public class InvalidNameException : Exception
    {
        // provide at least a parameterless constructor
        public InvalidNameException() { }
        // one that takes string
        public InvalidNameException(string message)
            : base(message) { }
        // one that takes both string and exception
        public InvalidNameException(string message, Exception inner)
            : base(message, inner) { }
        // and one for serialization
        protected InvalidNameException(SerializationInfo info, StreamingContext context)
            : base(info, context) { }
    }
}