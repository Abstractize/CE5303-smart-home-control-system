using Services.Contracts;
using System.Runtime.InteropServices;

namespace Services.Implementation
{
    public class HardwareService : IHardwareService
    {
        public enum HardwareStatus
        {
            OFF = 0,
            ON = 1,
        }

        [DllImport("libHardwareController")]
        static extern int enablePin(int pin);
        [DllImport("libHardwareController")]
        static extern int disablePin(int pin);
        [DllImport("libHardwareController")]
        static extern int pinMode(int pin, string mode);
        [DllImport("libHardwareController")]
        static extern int digitalWrite(int pin, int value);
        [DllImport("libHardwareController")]
        static extern int digitalRead(int pin);


        public Task<Boolean> IsLightOn(int pin)
        {
            bool result = digitalRead(pin) == (int) HardwareStatus.ON;
            return Task.FromResult(result);
        }

        public Task<int> SwitchLight(int pin, HardwareStatus value)
        {
            int result = digitalWrite(pin, (int) value);
            return Task.FromResult(result);
        }

        public Task<int> EnablePin(int pin)

        {
            int _enablePin = enablePin(pin);
            return Task.FromResult(_enablePin);
        }

        public Task<int> DisablePin(int pin)
        {
            int _disablePin = disablePin(pin);
            return Task.FromResult(_disablePin);
        }

        public Task<int> PinMode(int pin, string mode)
        {
            int _pinMode = pinMode(pin, mode);
            return Task.FromResult(_pinMode);
        }

        public Task<int> DigitalWrite(int pin, int value)
        {
            int _digitalWrite = digitalWrite(pin, value);
            return Task.FromResult(_digitalWrite);
        }

        public Task<int> DigitalRead(int pin)
        {
            int _digitalRead = digitalRead(pin);
            return Task.FromResult(_digitalRead);
        }
        
        public Task<Boolean> IsDoorOpen(int pin)
        {
            Random random = new Random();
            return Task.FromResult(random.Next(2) == 1);
        }
        
    }
}
