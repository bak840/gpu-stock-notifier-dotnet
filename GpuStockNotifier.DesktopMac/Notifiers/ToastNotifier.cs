using System.Diagnostics;
using GpuStockNotifier.Common;

namespace GpuStockNotifier.DesktopMac
{
    class ToastNotifier: NotifierDecorator
    {
        public ToastNotifier(Notifier notifier): base(notifier) { }

        private void ShowToast(string content)
        {
            var startInfo = new ProcessStartInfo()
            {
                FileName = "/bin/bash",
                Arguments = $" -c \"osascript -e \' display notification \\\"GPU AVAILABLE!!!\\\" with title \\\"{content}\\\" \' \"",
                UseShellExecute = false,
                CreateNoWindow = false,
                RedirectStandardOutput = true,
                RedirectStandardError = true
            };

            var process = new Process()
            {
                StartInfo = startInfo,
            };

            process.Start();
        }

        public override void Notify(Gpu gpu)
        {
            base.Notify(gpu);

            ShowToast(gpu.Subject);
        }
    }
}
