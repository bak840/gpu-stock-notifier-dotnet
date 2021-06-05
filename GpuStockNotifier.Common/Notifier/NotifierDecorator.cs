namespace GpuStockNotifier.Common
{
    public abstract class NotifierDecorator: Notifier
    {
        protected Notifier _notifier;

        public NotifierDecorator(Notifier notifier)
        {
            _notifier = notifier;
        }

        public void SetNotifier(Notifier notifier)
        {
            _notifier = notifier;
        }

        public override void Notify(Gpu gpu)
        {
            _notifier.Notify(gpu);
        }
    }
}
