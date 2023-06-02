namespace Finance.ASP.Controllers
{
    public class BaceController<T> : Controller where T : class
    {
        private T _service;

        private protected void SetService(T service)
        {
            _service = service;
        }

        private protected T GetService()
        {
            if (_service is null)
                throw new InvalidOperationException("Service is null");

            return _service;
        }
    }
}
