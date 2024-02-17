namespace IMS.Application.Wrappers
{
    public class ResponseBuilder
    {
        public static Response<T> Success<T>(T data)
        {
            return new Response<T>(data, string.Empty);
        }

        public static Response<T> Error<T>(string message)
        {
            return new Response<T>(message);
        }

    }
}
