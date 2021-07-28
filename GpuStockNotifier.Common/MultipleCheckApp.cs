using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GpuStockNotifier.Common
{
    public class MultipleCheckApp: App
    {
        private readonly List<Gpu> gpus;

        private readonly int minCheckInterval;

        private readonly int maxCheckInterval;

        private string[] lastLdlcUrls;

        public MultipleCheckApp(Notifier notifier, List<Gpu> gpus, int minCheckInterval, int maxCheckInterval) : base(notifier)
        {
            this.gpus = gpus;
            lastLdlcUrls = gpus.Select(gpu => gpu.LdlcUrl).ToArray();
            this.minCheckInterval = minCheckInterval;
            this.maxCheckInterval = maxCheckInterval;
        }

        public async Task Run()
        {
            while (true)
            {
                for(int i = 0; i < gpus.Count; i++)
                {
                    lastLdlcUrls[i] = await CheckAndNotify(gpus[i], lastLdlcUrls[i]);

                    var interDelay = random.Next(2000, 3000);
                    await Task.Delay(interDelay);
                }

                var delay = random.Next(minCheckInterval, maxCheckInterval);
                await Task.Delay(delay);
            }
        }

        public async Task RunTest() => await Test(gpus[0]);
    }
}
