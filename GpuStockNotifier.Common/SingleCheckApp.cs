using System.Threading.Tasks;

namespace GpuStockNotifier.Common
{
    public class SingleCheckApp : App
    {
        private readonly Gpu gpu;

        private readonly int minCheckInterval;

        private readonly int maxCheckInterval;

        private string lastLdlcUrl;

        public SingleCheckApp(Notifier notifier, Gpu gpu, int minCheckInterval, int maxCheckInterval) : base(notifier)
        {
            this.gpu = gpu;
            lastLdlcUrl = gpu.LdlcUrl;
            this.minCheckInterval = minCheckInterval;
            this.maxCheckInterval = maxCheckInterval;
        }

        public async Task Run()
        {
            while (true)
            {
                lastLdlcUrl = await CheckAndNotify(gpu, lastLdlcUrl);

                var delay = random.Next(minCheckInterval, maxCheckInterval);
                await Task.Delay(delay);
            }
        }

        public async Task RunTest() => await Test(gpu);
    }
}
