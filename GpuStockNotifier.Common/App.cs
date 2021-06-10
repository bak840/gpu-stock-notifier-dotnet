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
        private readonly Notifier notifier;

        private readonly List<Gpu> gpus;

        private const string outOfStockMessage = "out_of_stock";

        public App(Notifier notifier)
        {
            this.notifier = notifier;

            var fileName = "gpus.json";
            string jsonGpus = File.ReadAllText(fileName);
            gpus = JsonSerializer.Deserialize<List<Gpu>>(jsonGpus);
        }

        private string GetGpuStatus(Gpu gpu, string status)
        {
            var date = DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss");

            return $"{date}: {gpu.Name} status: {status}";
        }

        public async Task RunOne()
        {
            var gpu = gpus[0];

            var client = new HttpClient();

            var random = new Random();

            while (true)
            {
                var response = await client.GetAsync(gpu.ApiUrl);
                if (response.IsSuccessStatusCode)
                {
                    var body = await response.Content.ReadAsStringAsync();

                    var apiResponse = JsonSerializer.Deserialize<ApiResponse>(body);

                    var gpuStatus = apiResponse.SearchedProducts.FeaturedProduct.PrdStatus;

                    gpu.LdlcUrl = apiResponse.SearchedProducts.FeaturedProduct.Retailers[0].PurchaseLink;

                    Console.WriteLine(GetGpuStatus(gpu, gpuStatus));

                    if (gpuStatus != outOfStockMessage)
                    {
                        notifier.Notify(gpu);
                    }
                }
                else
                {
                    Console.WriteLine($"Network request to the API failed: {response.StatusCode}");
                }

                var delay = random.Next(15000, 30000);
                await Task.Delay(delay);
            }
        }

        public async Task RunAll()
        {
            var client = new HttpClient();

            var random = new Random();

            while (true)
            {
                foreach (var gpu in gpus)
                {
                    var response = await client.GetAsync(gpu.ApiUrl);
                    if (response.IsSuccessStatusCode)
                    {
                        var body = await response.Content.ReadAsStringAsync();

                        var apiResponse = JsonSerializer.Deserialize<ApiResponse>(body);

                        var gpuStatus = (gpu.Id != "3070Ti")
                            ? apiResponse.SearchedProducts.FeaturedProduct.PrdStatus
                            : apiResponse.SearchedProducts.ProductDetails[0].PrdStatus;

                        gpu.LdlcUrl = (gpu.Id != "3070Ti")
                            ? apiResponse.SearchedProducts.FeaturedProduct.Retailers[0].PurchaseLink
                            : apiResponse.SearchedProducts.ProductDetails[0].Retailers[0].PurchaseLink;

                        Console.WriteLine(GetGpuStatus(gpu, gpuStatus));

                        if (gpuStatus != outOfStockMessage)
                        {
                            notifier.Notify(gpu);
                        }
                    }
                    else
                    {
                        Console.WriteLine($"Network request to the API failed: {response.StatusCode}");
                    }

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

            Console.WriteLine(gpu.Name);

            var client = new HttpClient();

            var response = await client.GetAsync(gpu.ApiUrl);

            Console.WriteLine(response.StatusCode);

            if (response.IsSuccessStatusCode)
            {
                var body = await response.Content.ReadAsStringAsync();

                var apiResponse = JsonSerializer.Deserialize<ApiResponse>(body);

                gpu.LdlcUrl = apiResponse.SearchedProducts.FeaturedProduct.Retailers[0].PurchaseLink;

                var gpuStatus = apiResponse.SearchedProducts.FeaturedProduct.PrdStatus;

                Console.WriteLine(GetGpuStatus(gpu, gpuStatus));

                if (gpuStatus == outOfStockMessage)
                {
                    Console.WriteLine("Test notifications");
                    notifier.Notify(gpu);
                }
            }
            else
            {
                Console.WriteLine("Network request to the API failed");
            }

        }
    }
}
