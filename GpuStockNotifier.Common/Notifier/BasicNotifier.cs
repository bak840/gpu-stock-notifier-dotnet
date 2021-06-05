using System;

namespace GpuStockNotifier.Common
{
    public class BasicNotifier : Notifier
    {
        public override void Notify(Gpu gpu)
        {
            Console.WriteLine($"{gpu.Name} AVAILABLE!!!");
        }
    }
}
