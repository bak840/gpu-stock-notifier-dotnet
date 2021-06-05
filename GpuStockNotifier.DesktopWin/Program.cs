using GpuStockNotifier.Common;
using System.Threading.Tasks;

namespace GpuStockNotifier.DesktopWin
{
    class Program
    {
        async static Task Main(string[] args)
        {
            var app = new App(new ToastNotifier(new BrowserNotifier(new BasicNotifier())));

            await app.Run();
        }
    }
}
