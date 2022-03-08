using Data.Accessors.Contracts;
using Data.Context;
using Data.Models;

namespace Data.Accessors.Implementation
{
    public class DoorAccessor : AccessorBase<Door>, IDoorAccessor
    {
        public DoorAccessor(HomeContext context) : base(context.Doors, context)
        {
        }
    }
}