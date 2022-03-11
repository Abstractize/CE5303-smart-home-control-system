namespace Models.Exceptions
{
    public class BaseException : Exception
    {
        public String UserFriendlyMessage { get; }
        public BaseException(string message)
        {
            UserFriendlyMessage = message;
        }
    }
}
