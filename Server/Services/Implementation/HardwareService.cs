using Services.Contracts;
using System.Runtime.InteropServices;

namespace Services.Implementation
{
    public class HardwareService : IHardwareService
    {
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

        public Task<String?> setPin(int pin)
        {
            // IntPtr helloPtr = GetHello();
            // String? hello = Marshal.PtrToStringAnsi(helloPtr);
            // return Task.FromResult(hello);
        }

        public Task SayHello()
        {
            // int hello = PrintHello();
            // return Task.FromResult(hello);
        }
    }
}
