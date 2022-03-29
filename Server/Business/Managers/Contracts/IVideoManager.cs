using Microsoft.AspNetCore.Mvc;
using Models;

namespace Business.Managers.Contracts
{
    public interface IVideoManager
    {
        Task<Video> GetVideoAsync();
    }
}