using API.Hubs.Contracts;
using Microsoft.AspNetCore.SignalR;
using Models;

namespace API.Hubs.Implementation
{
    public class DoorHub : Hub<IDoorHub> { }
}
