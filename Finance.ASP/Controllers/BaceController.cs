namespace Finance.ASP.Controllers
{
    public class BaceController<T> : Controller where T : class
    {
        private IServiceProvider _provider;
        private T _service;

        public BaceController(IServiceProvider provider, T service)
        {
            _provider = provider;
            _service = service;
        }

        public BaceController(T service)
        {
            _service = service;
        }

        private protected IServiceProvider GetProvider()
        {
            if (_provider is null)
                throw new InvalidOperationException("Provider is null");

            return _provider;
        }

        private protected T GetService()
        {
            if (_service is null)
                throw new InvalidOperationException("Service is null");

            return _service;
        }
    }
}
