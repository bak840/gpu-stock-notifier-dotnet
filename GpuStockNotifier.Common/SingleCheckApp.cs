using System;
using System.Threading.Tasks;

namespace GpuStockNotifier.Common
{
    public class SingleCheckApp : App
    {
        private readonly Gpu gpu;

        private readonly Random random = new Random();

        private readonly int minCheckInterval;

        private readonly int maxCheckInterval;

        public SingleCheckApp(Notifier notifier, Gpu gpu, int minCheckInterval, int maxCheckInterval) : base(notifier)
        {
            this.gpu = gpu;
            this.minCheckInterval = minCheckInterval;
            this.maxCheckInterval = maxCheckInterval;
        }

        public async Task Run()
        {
            while (true)
            {
                await CheckAndNotify(gpu);

                var delay = random.Next(minCheckInterval, maxCheckInterval);
                await Task.Delay(delay);
            }
        }
    }
}
