using System.Collections.Generic;

namespace Customer.Application.Common
{
    public class Response<T>
    {
        public Response(T result)
        {
            Result = result;
        }

        public Response(IEnumerable<string> messages)
        {
            Messages = messages;
        }

        public Response(IEnumerable<string> messages, T result)
        {
            Result = result;
            Messages = messages;
        }

        public T Result { get; private set; }

        public IEnumerable<string> Messages { get; set; }
    }
}
