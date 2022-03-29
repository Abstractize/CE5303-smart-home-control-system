using Presentation = Models;
using Persistance = Data.Models;

namespace Business.Models;

public static class LightEx
{
    public static Presentation.Light LoadFrom(this Presentation.Light dest, Persistance.Light src, Boolean isOn = false)
    {
        dest.Id = src.Id;
        dest.RoomName = src.Room.Name;
        dest.IsOn = isOn;

        return dest;
    }
}

