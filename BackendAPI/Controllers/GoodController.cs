using Microsoft.AspNetCore.Mvc;
using Domain.Interfaces;
using Domain.Models;

namespace BackendAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GoodController : ControllerBase
    {
        private IGoodService _goodService;

        public GoodController(IGoodService goodService)
        {
            _goodService = goodService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll() => Ok(await _goodService.GetAll());

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id) => Ok(await _goodService.GetById(id));

        [HttpPost]
        public async Task<IActionResult> Add(Good good)
        {
            await _goodService.Create(good);

            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> Update(Good good)
        {
            await _goodService.Update(good);

            return Ok();
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            await _goodService.Delete(id);

            return Ok();
        }
    }
}
