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
        private static extern int enablePin(int pin); //, CallbackDelegate print);
        [DllImport("libHardwareController")]
        private static extern int disablePin(int pin); //, CallbackDelegate print);
        [DllImport("libHardwareController")]
        private static extern int pinMode(int pin, string mode); //, string sysPath, CallbackDelegate print);
        [DllImport("libHardwareController")]
        private static extern int digitalWrite(int pin, int value); //, string sysPath, CallbackDelegate print);
        [DllImport("libHardwareController")]
        private static extern int digitalRead(int pin); //, string sysPath, CallbackDelegate print);

        private readonly IDoorAccessor _doorAccessor;
        private readonly ILightAccessor _lightAccessor;
        public HardwareService(IDoorAccessor doorAccessor, ILightAccessor lightAccessor)
        {
            _doorAccessor = doorAccessor;
            _lightAccessor = lightAccessor;
        }

        private async Task StartService()
        {
            if (!isConfigured)
            {
                var lights = await _lightAccessor.GetAsync();
                lights.ToList().ForEach(light =>
                {
                    enablePin(light.Pin); //, sysPath, delegateInstance);
                    Console.WriteLine($"Pin Enabled: {light.Pin}");
                    pinMode(light.Pin, OUTPUT); //, sysPath, delegateInstance);
                });

                var doors = await _doorAccessor.GetAsync();
                doors.ToList().ForEach(door =>
                {
                    enablePin(door.Pin); //, sysPath, delegateInstance);
                    Console.WriteLine($"Pin Enabled: {door.Pin}");
                    pinMode(door.Pin, INPUT); //, sysPath, delegateInstance);
                });

                isConfigured = true;
            }
        }

        public Task<Boolean> IsLightOn(int pin)
            => IsItemActive(pin);

        public async Task<int> SwitchLight(int pin, HardwareStatus value)
        {
            await this.StartService();
            int result = digitalWrite(pin, (int)value); //, sysPath, delegateInstance);
            return result;
        }

        public Task<Boolean> IsDoorOpen(int pin)
            => IsItemActive(pin);

        private async Task<Boolean> IsItemActive(int pin)
        {
            await this.StartService();
            bool result = digitalRead(pin) == (int)HardwareStatus.ON;
            return result;
        }

        private static void Print(IntPtr value)
        {
            Console.WriteLine($"Dynamic Library says: {Marshal.PtrToStringAuto(value)}");
        }
    }
}
