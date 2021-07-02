using GpuStockNotifier.Common;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace GpuStockNotifier.DesktopMac
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
                if (RuntimeInformation.IsOSPlatform(OSPlatform.OSX))
                {
                    Process.Start("open", url);
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
