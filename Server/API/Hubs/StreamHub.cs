using Business.Managers.Contracts;
using Microsoft.AspNetCore.SignalR;

namespace API.Hubs
{
    public abstract class StreamHub<TManager,TModel> : Hub 
        where TManager : class, IStreamManager<TModel> 
        where TModel : class
    {

    }
}
