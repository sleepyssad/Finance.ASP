namespace Finance.ASP.Controllers
{
    [Controller]
    [Route("api/[controller]")]
    public class SpendingController : BaceController<SpendingService>
    {
        public SpendingController(IServiceProvider provider, SpendingService service) : base(provider, service)
        {
        }

        [HttpGet]
        public async Task<List<Spending>> Get()
        {
            return await GetService().GetAsync();
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Spending spending)
        {
            using (var scope = GetProvider().CreateScope())
            {
                var categories = await scope.ServiceProvider.GetRequiredService<CategoryService>().GetAsync();
                if (categories is List<Category> && categories.Count > 0) 
                {
                    foreach (var category in categories)
                    {
                        if (category.name.ToLower() == spending.category.ToLower())
                        {
                            await GetService().CreateAsync(spending);
                            return CreatedAtAction(nameof(Get), new { id = spending.Id }, spending);
                        }
                    }
                }
            }

            return BadRequest("Category not found");
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(string id, [FromBody] int newAmount)
        {
            await GetService().ChangeAmountAsync(id, newAmount);
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
