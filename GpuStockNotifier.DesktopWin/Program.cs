using GpuStockNotifier.Common;
using System.Threading.Tasks;

namespace GpuStockNotifier.DesktopWin
{
    class Program
    {
        async static Task Main(string[] args)
        {
            var gpus = Utils.LoadGpusFromFile();
            var gpu = gpus[0];
            var minCheckInterval = 2000;
            var maxCheckInterval = 5000;

            var notifier = new ToastNotifier(new BrowserNotifier(new BasicNotifier()));
            var app = new SingleCheckApp(notifier, gpu, minCheckInterval, maxCheckInterval);

            await app.RunTest();
        }
    }
}
