using System.Collections.Generic;
using System.IO;
using System.Text.Json;

namespace GpuStockNotifier.Common
{
    public class Utils
    {
        public static List<Gpu> LoadGpusFromFile()
        {
            var fileName = "gpus.json";
            string jsonGpus = File.ReadAllText(fileName);
            return JsonSerializer.Deserialize<List<Gpu>>(jsonGpus);
        }
    }
}
