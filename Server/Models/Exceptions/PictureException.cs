using Microsoft.AspNetCore.Http;

namespace Models.Exceptions
{
    public class PictureException : BaseException
    {
        public PictureException() : 
            base("Can't create image. Please try again later.", StatusCodes.Status500InternalServerError)
        {
        }
    }
}
