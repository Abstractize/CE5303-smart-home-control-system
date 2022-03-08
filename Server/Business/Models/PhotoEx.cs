using Presentation = Models;
using Persistance = Data.Models;
using Microsoft.AspNetCore.Mvc;

namespace Business.Models;

public static class PhotoEx
{
    public static Presentation.Photo LoadFrom(this Presentation.Photo dest, Persistance.Photo src)
    {
        dest.Id = src.Id;
        dest.Name = src.FileName;

        return dest;
    }
    public static FileContentResult LoadTo(this Persistance.Photo src)
    {
        return new FileContentResult(src.Data, "image/png");
    }
}

