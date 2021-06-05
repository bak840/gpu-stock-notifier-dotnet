using GpuStockNotifier.Common;
using System.Threading.Tasks;

namespace GpuStockNotifier.Server
{
    class Program
    {
        async static Task Main(string[] args)
        {
            var app = new App(new SmsNotifier(new EmailNotifier(new BasicNotifier())));

            await app.Run();
        }
    }
}
