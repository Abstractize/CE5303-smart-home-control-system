using Services.Contracts;
using System.Runtime.InteropServices;

namespace Services.Implementation
{
    public class HardwareService : IHardwareService
    {
        [DllImport("libHardwareController")]
        static extern IntPtr GetHello();
        [DllImport("libHardwareController")]
        static extern int PrintHello();

        public Task<String?> GetHelloAsync()
        {
            IntPtr helloPtr = GetHello();
            String? hello = Marshal.PtrToStringAnsi(helloPtr);
            return Task.FromResult(hello);
        }

        public Task SayHello()
        {
            int hello = PrintHello();
            return Task.FromResult(hello);
        }
    }
}
