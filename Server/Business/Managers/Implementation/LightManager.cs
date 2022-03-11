using Business.Managers.Contracts;
using Business.Models;
using Data.Accessors.Contracts;
using Models;
using Services.Constants;
using Services.Contracts;
using Persistence = Data.Models;

namespace Business.Managers.Implementation
{
    public class LightManager : ILightManager
    {
        private readonly IHardwareService _hardwareService;
        private readonly ILightAccessor _lightAccessor;

        public LightManager(IHardwareService hardwareService, ILightAccessor lightAccessor)
        {
            _hardwareService = hardwareService;
            _lightAccessor = lightAccessor;
        }

        public async Task<Light> FindAsync(Guid id)
        {
            Persistence.Light item = await _lightAccessor.FindAsync(i => i.Id == id);

            if (item == null)
                throw new Exception($"{id} not found.");

            Boolean isOpen = await _hardwareService.IsLightOn(item.Pin);

            return new Light().LoadFrom(item, isOpen);
        }

        public async Task<IList<Light>> GetAsync()
        {
            IList<Persistence.Light> items = await _lightAccessor.GetAsync();

            return items.Select(async item => new Light()
                .LoadFrom(item, await _hardwareService.IsLightOn(item.Pin)))
                .Select(item => item.Result).ToList();
        }

        public async Task UpdateAsync(Guid id, Light item)
        {
            Persistence.Light existingValue = await _lightAccessor.FindAsync(i => i.Id == id);

            if (existingValue == null)
                throw new Exception($"{id} not found.");

            await _hardwareService.SwitchLight(existingValue.Pin, item.IsOn? 
                HardwareStatus.ON : 
                HardwareStatus.OFF);
        }
    }
}
