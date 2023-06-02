using Microsoft.AspNetCore.Mvc;

namespace Finance.ASP.Controllers
{
    [Controller]
    [Route("api/[controller]")]
    public class SpendingController : Controller
    {
        private readonly SpendingService _mongoDBService;

        public SpendingController(SpendingService mongoDBService)
        {
            _mongoDBService = mongoDBService;
        }

        [HttpGet]
        public async Task<List<Spending>> Get()
        {
            return await _mongoDBService.GetAsync();
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Spending spending)
        {
            await _mongoDBService.CreateAsync(spending);
            return CreatedAtAction(nameof(Get), new { id = spending.Id }, spending);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(string id, [FromBody] int newAmount)
        {
            await _mongoDBService.ChangeAmountAsync(id, newAmount);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            await _mongoDBService.DeleteAsync(id);
            return NoContent();
        }
    }
}
