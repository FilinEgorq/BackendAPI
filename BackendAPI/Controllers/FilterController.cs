using Microsoft.AspNetCore.Mvc;
using Domain.Interfaces;
using Domain.Models;
using Mapster;
using BackendAPI.Contracts.Filter;

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

        /// <summary>
        /// Получает фильтр по его Id
        /// </summary>
        /// <param name="id">Id фильтра</param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = _filterService.GetById(id).Adapt<GetFilterResponse>();

            return Ok(result);
        }

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
        /// <param name="request">Фильтр</param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> Add(CreateFilterRequest request)
        {
            var filterDto = request.Adapt<Filter>();

            await _filterService.Create(filterDto);

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