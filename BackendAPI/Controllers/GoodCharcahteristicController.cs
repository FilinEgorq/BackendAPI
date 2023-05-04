using BackendAPI.Contracts.GoodCharachteristic;
using Domain.Interfaces;
using Domain.Models;
using Mapster;
using Microsoft.AspNetCore.Mvc;

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

        /// <summary>
        /// Получает все характеристики товаров
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> GetAll() => Ok(await _userService.GetAll());

        /// <summary>
        /// Выводит конкретную характеристику товара
        /// </summary>
        /// <param name="goodId">Id товара</param>
        /// <param name="filterId">Id фильтра (характеристики)</param>
        /// <returns></returns>
        [HttpGet("{id}/{filterId}")]
        public async Task<IActionResult> GetById(int goodId, int filterId)
        {
            return Ok(_userService.GetById(goodId, filterId).Adapt<CreateGoodCharachteristicRequest>());
        }

        /// <summary>
        /// Добавляет новую характеристику к товару
        /// </summary>
        /// <remarks>
        /// Пример запроса:
        /// 
        ///     {
        ///         "goodId": 1,
        ///         "filterId": 1,
        ///         "value": "да" //у данного атрибута тип sql_variant, так что можно вставлять любое значение, которое подходит для данной характеристики
        ///     }
        ///     
        /// </remarks>
        /// <param name="goodCharachteristic"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> Add(CreateGoodCharachteristicRequest goodCharachteristic)
        {
            var goodCharachteristicDto = goodCharachteristic.Adapt<GoodCharachteristic>();

            await _userService.Create(goodCharachteristicDto);

            return Ok();
        }

        /// <summary>
        /// Изменяет характеристику у товара
        /// </summary>
        /// <remarks>
        /// Пример запроса:
        /// 
        ///     {
        ///         "goodId": 1,
        ///         "filterId": 1,
        ///         "value": false //у данного атрибута тип sql_variant, так что можно вставлять любое значение, которое подходит для данной характеристики
        ///     }
        ///     
        /// </remarks>
        /// <param name="goodCharachteristic"></param>
        /// <returns></returns>
        [HttpPut]
        public async Task<IActionResult> Update(GoodCharachteristic goodCharachteristic)
        {
            await _userService.Update(goodCharachteristic);

            return Ok();
        }

        /// <summary>
        /// Удаляет характеристику у товара
        /// </summary>
        /// <param name="goodId">Id товара</param>
        /// <param name="filterId">Id фильтра(характеристики)</param>
        /// <returns></returns>
        [HttpDelete]
        public async Task<IActionResult> Delete(int goodId, int filterId)
        {
            await _userService.Delete(goodId, filterId);

            return Ok();
        }
    }
}
