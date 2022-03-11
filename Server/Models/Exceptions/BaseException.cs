using System.Text.Json;

namespace Models.Exceptions
{
    public class BaseException : Exception
    {
        public String UserFriendlyMessage { get; }
        public int StatusCode { get; }
        public BaseException(string message, int statusCode)
        {
            UserFriendlyMessage = message;
            StatusCode = statusCode;
        }
    }
}
