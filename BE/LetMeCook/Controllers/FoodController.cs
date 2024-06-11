using BusinessLayer.Services;
using Microsoft.AspNetCore.Mvc;

namespace LetMeCook.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FoodController : ControllerBase
    {
        private readonly IFoodService _foodService;
        public FoodController(IFoodService foodService)
        {
            _foodService = foodService;
        }

        [HttpGet(Name = "GetFood")]
        public async Task<IActionResult> GiveMeFood([FromQuery] string ingredient)
        {
            var dishes = await _foodService.GetFood(ingredient);
            if (dishes.Count == 0)
            {
                return NotFound();
            }
            return Ok(dishes);
        }
    }
}
