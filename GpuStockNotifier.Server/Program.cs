using GpuStockNotifier.Common;
using System.Threading.Tasks;

namespace GpuStockNotifier.Server
{
    class Program
    {
        async static Task Main(string[] args)
        {
            var gpus = Utils.LoadGpusFromFile();
            var minCheckInterval = 30000;
            var maxCheckInterval = 60000;

            var notifier = new SmsNotifier(new EmailNotifier(new BasicNotifier()));
            var app = new MultipleCheckApp(notifier, gpus, minCheckInterval, maxCheckInterval);

            await app.Run();
        }
    }
}
