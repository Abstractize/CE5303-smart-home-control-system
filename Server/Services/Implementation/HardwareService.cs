using Services.Contracts;
using System.Runtime.InteropServices;

namespace Services.Implementation
{
    public class HardwareService : IHardwareService
    {
        private const String LIBRARY_NAME = "libHardwareController";
        [DllImport(LIBRARY_NAME)]
        static extern IntPtr GetHello();
        [DllImport(LIBRARY_NAME)]
        static extern void PrintHello();

        public Task<Boolean> IsDoorOpen(int pin)
        {
            Random random = new Random();
            return Task.FromResult(random.Next(2) == 1);
        }

        public Task<String?> GetHelloAsync()
        {
            IntPtr helloPtr = GetHello();
            String? hello = Marshal.PtrToStringAnsi(helloPtr);
            return Task.FromResult(hello);
        }

        public Task SayHello()
        {
            PrintHello();
            return Task.FromResult(0);
        }
    }
}
