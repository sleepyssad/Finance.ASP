namespace Finance.ASP.Controllers
{
    [Controller]
    [Route("api/[controller]")]
    public class CategoriesController : BaceController<CategoriesService>
    {
        public CategoriesController(CategoriesService service)
        {
            SetService(service);
        }

        [HttpGet]
        public async Task<List<Categories>> Get()
        {
            return await GetService().GetAsync();
        }
    }
}
