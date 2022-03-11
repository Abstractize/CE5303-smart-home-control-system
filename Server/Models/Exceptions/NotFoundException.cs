namespace Models.Exceptions
{
    public sealed class NotFoundException : NotFoundException<Guid>
    {
        public NotFoundException(Guid id, string message = "Item {0} Not Found") : base(id, message) { }
    }
    public class NotFoundException<TId> : BaseException
    {
        public NotFoundException(TId id, String message = "Item {0} Not Found") : base(String.Format(message, id)) { }
    }
}
