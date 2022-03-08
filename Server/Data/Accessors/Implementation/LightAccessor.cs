using Data.Accessors.Contracts;
using Data.Context;
using Data.Models;

namespace Data.Accessors.Implementation
{
    public class LightAccessor : AccessorBase<Light>, ILightAccessor
    {
        public LightAccessor(HomeContext context) : base(context.Lights, context)
        {
        }
    }
}
