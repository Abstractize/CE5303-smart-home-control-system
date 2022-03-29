using Microsoft.AspNetCore.Http;

namespace Models.Exceptions
{
    public sealed class NotFoundException : NotFoundException<Guid>
    {
        public NotFoundException(Guid id) : base(id) { }
        public NotFoundException(Guid id, String message) : base(id, message) { }
    }
    public class NotFoundException<TId> : BaseException
    {
        public NotFoundException(TId id, String message = "Item {0} Not Found") : base(String.Format(message, id), StatusCodes.Status404NotFound) { }
    }
}
