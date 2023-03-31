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

        /// <summary>
        /// Выводит все фильтры
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> GetAll() => Ok(await _filterService.GetAll());

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id) => Ok(await _filterService.GetById(id));

        /// <summary>
        /// Добавляет новый фильтр
        /// </summary>
        /// <remarks>
        /// Пример запроса:
        /// 
        ///     {
        ///         "id": 1,
        ///         "name": "Тип датчика",
        ///         "categoryId": 1,
        ///         "isDeleted": "31-03-2023 10:07:12" //Опционально
        ///     }
        ///     
        /// </remarks>
        /// <param name="filter">Фильтр</param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> Add(Filter filter)
        {
            await _filterService.Create(filter);

            return Ok();
        }

        /// <summary>
        /// Изменяет фильтр
        /// </summary>
        /// <remarks>
        /// Пример запроса:
        /// 
        ///     {
        ///         "id": 1,
        ///         "name": "Наличие боковых кнопок",
        ///         "categoryId": 1,
        ///         "isDeleted": "31-03-2023 10:07:12" //Опционально
        ///     }
        ///      
        /// </remarks>
        /// <param name="filter">Фильтр</param>
        /// <returns></returns>
        [HttpPut]
        public async Task<IActionResult> Update(Filter filter)
        {
            await _filterService.Update(filter);

            return Ok();
        }

        /// <summary>
        /// Удаляет фильтр
        /// </summary>
        /// <param name="id">Id фильтра</param>
        /// <returns></returns>
        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            await _filterService.Delete(id);

            return Ok();
        }
    }
}