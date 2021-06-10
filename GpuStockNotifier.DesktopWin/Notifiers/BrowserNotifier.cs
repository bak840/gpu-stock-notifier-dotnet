using GpuStockNotifier.Common;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace GpuStockNotifier.DesktopWin
{
    class BrowserNotifier: NotifierDecorator
    {
        public BrowserNotifier(Notifier notifier): base(notifier) { }

        private void OpenLinkInBrowser(string url)
        {
            try
            {
                Process.Start(url);
            }
            catch
            {
                if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
                {
                    Process.Start(new ProcessStartInfo("cmd", $"/c start {url.Replace("&", "^&")}") { CreateNoWindow = true });
                }
                else
                {
                    throw;
                }
            } 
        }

        public override void Notify(Gpu gpu)
        {
            base.Notify(gpu);

            OpenLinkInBrowser(gpu.LdlcUrl);
        }
    }
}
