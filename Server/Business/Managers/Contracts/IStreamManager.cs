namespace Business.Managers.Contracts
{
    public interface IStreamManager<TModel> where TModel : class
    {
        IAsyncEnumerable<TModel> FindStreamAsync(Guid id, CancellationToken cancellationToken, int delay);
        IAsyncEnumerable<IList<TModel>> GetStreamAsync(CancellationToken cancellationToken, int delay);
    }
}
