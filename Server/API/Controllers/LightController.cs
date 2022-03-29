using Business.Managers.Contracts;
using Models;
using Microsoft.AspNetCore.Mvc;


namespace API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class LightController : ControllerBase
    {
        private readonly ILightManager _lightManager;

        public LightController(ILightManager lightManager)
        {
            _lightManager = lightManager;
        }

        [HttpGet]
        public Task<IList<Light>> Get()
            => _lightManager.GetAsync();

        [HttpGet("{id}")]
        public Task<Light> Get(Guid id)
            => _lightManager.FindAsync(id);
        
        [HttpPut("{id}")]
        public Task Put(Guid id, Light item)
            => _lightManager.UpdateAsync(id, item);
        
    }
}
