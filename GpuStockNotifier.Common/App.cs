using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace GpuStockNotifier.Common
{
    public class App
    {
        private readonly Notifier _notifier;

        private readonly List<Gpu> gpus = new();

        public App(Notifier notifier)
        {
            _notifier = notifier;

            var fileName = "gpus.json";
            string jsonGpus = File.ReadAllText(fileName);
            gpus = JsonSerializer.Deserialize<List<Gpu>>(jsonGpus);
        }

        private string GetGpuStatus(Gpu gpu, string status)
        {
            var date = DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss");

            return $"{date}: {gpu.Name} status: {status}";
        }

        public async Task Run()
        {
            var gpu = gpus[0];

            var client = new HttpClient();

            var random = new Random();

            while (true)
            {
                var response = await client.GetAsync(gpu.ApiUrl);

                var body = await response.Content.ReadAsStringAsync();

                var apiResponse = JsonSerializer.Deserialize<ApiResponse>(body);

                var gpuStatus = apiResponse.SearchedProducts.FeaturedProduct.PrdStatus;

                Console.WriteLine(GetGpuStatus(gpu, gpuStatus));

                if (gpuStatus == "out_of_stock")
                {
                    _notifier.Notify(gpu);
                }

                var delay = random.Next(15000, 45000);
                await Task.Delay(delay);
            }
        }

        public async Task Test()
        {
            var gpu = gpus[0];

            Console.WriteLine(gpu.Name);

            var client = new HttpClient();

            var response = await client.GetAsync(gpu.ApiUrl);

            Console.WriteLine(response.StatusCode);

            var body = await response.Content.ReadAsStringAsync();

            var apiResponse = JsonSerializer.Deserialize<ApiResponse>(body);

            var gpuStatus = apiResponse.SearchedProducts.FeaturedProduct.PrdStatus;

            Console.WriteLine(GetGpuStatus(gpu, gpuStatus));

            if (gpuStatus == "out_of_stock")
            {
                _notifier.Notify(gpu);
            }
        }
    }
}
