using Microsoft.AspNetCore.Mvc;
using Domain.Interfaces;
using Domain.Models;

namespace BackendAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FilterController : ControllerBase
    {
        private IFilterService _filterService;

        public FilterController(IFilterService filterService)
        {
            _filterService = filterService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll() => Ok(await _filterService.GetAll());

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id) => Ok(await _filterService.GetById(id));

        [HttpPost]
        public async Task<IActionResult> Add(Filter filter)
        {
            await _filterService.Create(filter);

            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> Update(Filter filter)
        {
            await _filterService.Update(filter);

            return Ok();
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            await _filterService.Delete(id);

            return Ok();
        }
    }
}
