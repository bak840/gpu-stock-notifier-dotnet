using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GpuStockNotifier.Common
{
    public class MultipleCheckApp: App
    {
        private readonly List<Gpu> gpus;

        private readonly Random random = new Random();

        private readonly int minCheckInterval;

        private readonly int maxCheckInterval;

        public MultipleCheckApp(Notifier notifier, List<Gpu> gpus, int minCheckInterval, int maxCheckInterval) : base(notifier)
        {
            this.gpus = gpus;
            this.minCheckInterval = minCheckInterval;
            this.maxCheckInterval = maxCheckInterval;
        }

        public async Task Run()
        {
            while (true)
            {
                foreach (var gpu in gpus)
                {
                    await CheckAndNotify(gpu);

                    var interDelay = random.Next(2500, 3500);
                    await Task.Delay(interDelay);
                }

                var delay = random.Next(minCheckInterval, maxCheckInterval);
                await Task.Delay(delay);
            }
        }
    }
}
