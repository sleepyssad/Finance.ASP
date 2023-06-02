namespace Finance.ASP.Controllers
{
    [Controller]
    [Route("api/[controller]")]
    public class SpendingController : BaceController<SpendingService>
    {
        public SpendingController(SpendingService service)
        {
            SetService(service);
        }

        [HttpGet]
        public async Task<List<Spending>> Get()
        {
            return await GetService().GetAsync();
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Spending spending)
        {
            await GetService().CreateAsync(spending);
            return CreatedAtAction(nameof(Get), new { id = spending.Id }, spending);
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
