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
        private readonly HttpClient client = new HttpClient();

        private readonly Random random = new Random();
        
        private readonly Notifier notifier;

        private readonly List<Gpu> gpus;

        private const string outOfStockMessage = "out_of_stock";

        private const string ldlcHomeUrl = "https://www.ldlc.com/";

        public App(Notifier notifier)
        {
            this.notifier = notifier;

            var fileName = "gpus.json";
            string jsonGpus = File.ReadAllText(fileName);
            gpus = JsonSerializer.Deserialize<List<Gpu>>(jsonGpus);
        }

        private string GetStatusMessage(Gpu gpu, string status)
        {
            var date = DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss");

            return $"{date}: {gpu.Name} status: {status}";
        }

        private async Task CheckAndNotify(Gpu gpu)
        {
            var response = await client.GetAsync(gpu.ApiUrl);
            if (response.IsSuccessStatusCode)
            {
                var body = await response.Content.ReadAsStringAsync();

                var apiResponse = JsonSerializer.Deserialize<ApiResponse>(body);

                string gpuStatus;
                if (gpu.Id != "3070Ti")
                {
                    var retailers = apiResponse.SearchedProducts.FeaturedProduct.Retailers;
                    gpu.LdlcUrl = (retailers.Count != 0) ? retailers[0].PurchaseLink : ldlcHomeUrl;

                    gpuStatus = apiResponse.SearchedProducts.FeaturedProduct.PrdStatus;
                }
                else
                {
                    var retailers = apiResponse.SearchedProducts.ProductDetails[0].Retailers;
                    gpu.LdlcUrl = (retailers.Count != 0) ? retailers[0].PurchaseLink: ldlcHomeUrl;

                    gpuStatus = apiResponse.SearchedProducts.ProductDetails[0].PrdStatus;
                }

                Console.WriteLine(GetStatusMessage(gpu, gpuStatus));

                if (gpuStatus != outOfStockMessage)
                {
                    notifier.Notify(gpu);
                }
            }
            else
            {
                Console.WriteLine($"Network request to the API failed: {response.StatusCode}");
            }
        }

        public async Task RunOne()
        {
            var gpu = gpus[0];

            while (true)
            {
                await CheckAndNotify(gpu);

                var delay = random.Next(15000, 30000);
                await Task.Delay(delay);
            }
        }

        public async Task RunAll()
        {
            while (true)
            {
                foreach (var gpu in gpus)
                {
                    await CheckAndNotify(gpu);

                    var interDelay = random.Next(2500, 5000);
                    await Task.Delay(interDelay);
                }

                var delay = random.Next(15000, 30000);
                await Task.Delay(delay);
            }
        }

        public async Task Test()
        {
            var gpu = gpus[0];

            Console.WriteLine($"GPU: {gpu.Name}");

            var client = new HttpClient();

            var response = await client.GetAsync(gpu.ApiUrl);

            Console.WriteLine($"Request Status Code: {response.StatusCode}");

            if (response.IsSuccessStatusCode)
            {
                var body = await response.Content.ReadAsStringAsync();

                var apiResponse = JsonSerializer.Deserialize<ApiResponse>(body);

                gpu.LdlcUrl = apiResponse.SearchedProducts.FeaturedProduct.Retailers[0].PurchaseLink;

                var gpuStatus = apiResponse.SearchedProducts.FeaturedProduct.PrdStatus;

                Console.WriteLine($"GPU Status: {gpuStatus}");

                if (gpuStatus == outOfStockMessage)
                {
                    var testNotifier = new BasicNotifier();
                    testNotifier.Notify(gpu);
                }
            }
            else
            {
                Console.WriteLine("Network request to the API failed");
            }
        }
    }
}
