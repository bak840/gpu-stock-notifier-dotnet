using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace GpuStockNotifier.Common
{
    public class App
    {
        protected readonly HttpClient client = new HttpClient();
        
        protected readonly Notifier notifier;

        protected readonly Random random = new Random();

        protected const string outOfStockMessage = "out_of_stock";

        protected const string ldlcHomeUrl = "https://www.ldlc.com/";

        public App(Notifier notifier)
        {
            this.notifier = notifier;
        }

        protected string GetStatusMessage(Gpu gpu, string status)
        {
            var date = DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss");

            return $"{date}: {gpu.Name} status: {status}";
        }

        protected async Task<string> CheckAndNotify(Gpu gpu, string lastLdlcUrl)
        {
            var response = await client.GetAsync(gpu.ApiUrl);
            if (response.IsSuccessStatusCode)
            {
                var body = await response.Content.ReadAsStringAsync();

                var apiResponse = JsonSerializer.Deserialize<ApiResponse>(body);

                string gpuStatus;
                List<Retailer> retailers;
                if (gpu.Id != "3070Ti")
                {
                    retailers = apiResponse.SearchedProducts.FeaturedProduct.Retailers;
                    gpuStatus = apiResponse.SearchedProducts.FeaturedProduct.PrdStatus;
                }
                else
                {
                    retailers = apiResponse.SearchedProducts.ProductDetails[0].Retailers;
                    gpuStatus = apiResponse.SearchedProducts.ProductDetails[0].PrdStatus;
                }

                gpu.LdlcUrl = (retailers.Count != 0) ? retailers[0].PurchaseLink : ldlcHomeUrl;
                if (lastLdlcUrl == string.Empty) lastLdlcUrl = gpu.LdlcUrl;

                Console.WriteLine(GetStatusMessage(gpu, gpuStatus));

                if (gpuStatus != outOfStockMessage || gpu.LdlcUrl != lastLdlcUrl)
                {
                    notifier.Notify(gpu);
                }

                return gpu.LdlcUrl;
            }
            else
            {
                Console.WriteLine($"Network request to the API failed: {response.StatusCode}");
                return lastLdlcUrl;
            }
        }

        protected async Task Test(Gpu gpu)
        {
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
                    // notifier.Notify(gpu);
                }
            }
            else
            {
                Console.WriteLine("Network request to the API failed");
            }
        }
    }
}
