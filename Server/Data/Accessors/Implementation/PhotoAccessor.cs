using Data.Accessors.Contracts;
using Data.Context;
using Data.Models;

namespace Data.Accessors.Implementation
{
    public class PhotoAccessor : AccessorBase<Photo>, IPhotoAccessor
    {
        public PhotoAccessor(HomeContext context) : base(context.Photos, context) { }
    }
}