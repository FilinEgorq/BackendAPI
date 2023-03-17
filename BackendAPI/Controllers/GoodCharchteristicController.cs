using Microsoft.AspNetCore.Mvc;
using Domain.Interfaces;
using Domain.Models;

namespace BackendAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GoodCharachteristicController : ControllerBase
    {
        private IGoodCharachteristicService _userService;

        public GoodCharachteristicController(IGoodCharachteristicService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll() => Ok(await _userService.GetAll());

        [HttpGet("{id}/{filterId}")]
        public async Task<IActionResult> GetById(int goodId, int filterId) => Ok(await _userService.GetById(goodId, filterId));

        [HttpPost]
        public async Task<IActionResult> Add(GoodCharachteristic user)
        {
            await _userService.Create(user);

            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> Update(GoodCharachteristic user)
        {
            await _userService.Update(user);

            return Ok();
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int goodId, int filterId)
        {
            await _userService.Delete(goodId, filterId);

            return Ok();
        }
    }
}
