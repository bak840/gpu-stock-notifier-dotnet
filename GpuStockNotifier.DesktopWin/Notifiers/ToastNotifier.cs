using GpuStockNotifier.Common;
using Microsoft.Toolkit.Uwp.Notifications;

namespace GpuStockNotifier.DesktopWin
{
    class ToastNotifier: NotifierDecorator
    {
        public ToastNotifier(Notifier notifier): base(notifier) { }

        private void ShowToast(string content)
        {
            new ToastContentBuilder().AddText(content).Show();
        }

        public override void Notify(Gpu gpu)
        {
            base.Notify(gpu);

            ShowToast(gpu.Subject);
        }
    }
}
