using Presentation = Models;
using Persistance = Data.Models;


namespace Business.Models;

public static class UserEx
{
    public static Presentation.User LoadFrom(this Presentation.User dest, Persistance.User src)
    {
        dest.Id = src.Id;

        return dest;
    }
}

