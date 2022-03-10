using Data.Accessors.Contracts;
using Services.Contracts;
using System.Runtime.InteropServices;

namespace Services.Implementation
{
    public class HardwareService : IHardwareService
    {
        private static Boolean isConfigured = false;
        private const String INPUT = "in", OUTPUT = "out";

        public enum HardwareStatus
        {
            OFF = 0,
            ON = 1,
        }

        [DllImport("libHardwareController")]
        private static extern int enablePin(int pin);
        [DllImport("libHardwareController")]
        private static extern int disablePin(int pin);
        [DllImport("libHardwareController")]
        private static extern int pinMode(int pin, string mode);
        [DllImport("libHardwareController")]
        private static extern int digitalWrite(int pin, int value);
        [DllImport("libHardwareController")]
        private static extern int digitalRead(int pin);

        public HardwareService(IDoorAccessor doorAccessor, ILightAccessor lightAccessor)
        {
            if (!isConfigured) 
            {
                lightAccessor.GetAsync().Result.ToList().ForEach(light => {
                    enablePin(light.Pin);
                    pinMode(light.Pin, OUTPUT);
                });

                doorAccessor.GetAsync().Result.ToList().ForEach(door => {
                    enablePin(door.Pin);
                    pinMode(door.Pin, INPUT);
                });

                isConfigured = true;
            }
        }

        public Task<Boolean> IsLightOn(int pin) 
            => IsItemActive(pin);

        public Task<int> SwitchLight(int pin, HardwareStatus value)
        {
            int result = digitalWrite(pin, (int) value);
            return Task.FromResult(result);
        }

        public Task<Boolean> IsDoorOpen(int pin) 
            => IsItemActive(pin);

        private Task<Boolean> IsItemActive(int pin)
        {
            bool result = digitalRead(pin) == (int) HardwareStatus.ON;
            return Task.FromResult(result);
        }
        
    }
}
