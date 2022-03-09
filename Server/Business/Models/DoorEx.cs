using Presentation = Models;
using Persistance = Data.Models;
using Microsoft.AspNetCore.Mvc;

namespace Business.Models;

public static class DoorEx
{
    public static Presentation.Door LoadFrom(this Presentation.Door dest, Persistance.Door src, Boolean isOpen = false)
    {
        dest.Id = src.Id;
        dest.RoomName = src.Room.Name;
        dest.IsOpen = isOpen;

        return dest;
    }
}

