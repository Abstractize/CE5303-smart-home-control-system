using Microsoft.AspNetCore.Http;

namespace Models.Exceptions
{
    public class IncorrectPasswordException : BaseException
    {
        public IncorrectPasswordException(String email) : base($"Wrong password for {email}", StatusCodes.Status417ExpectationFailed)
        {
        }
    }
}
