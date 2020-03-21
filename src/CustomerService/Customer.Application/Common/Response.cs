namespace Customer.Application.Common
{
    public class Response<T>
    {
        public Response(T result)
        {
            Result = result;
        }

        public T Result { get; private set; }
    }
}
