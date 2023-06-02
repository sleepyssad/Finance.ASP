namespace Finance.ASP.Controllers
{
    [Controller]
    [Route("api/[controller]")]
    public class CategoriesController : BaceController<CategoryService>
    {
        public CategoriesController(CategoryService service) : base(service)
        {
        }

        [HttpGet]
        public async Task<List<Category>> Get()
        {
            return await GetService().GetAsync();
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Category category)
        {
            await GetService().CreateAsync(category);
            return CreatedAtAction(nameof(Get), new { id = category.Id }, category);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(string id, [FromBody] string newName)
        {
            await GetService().ChangeAsync(id, newName);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            await GetService().DeleteAsync(id);
            return NoContent();
        }
    }
}
