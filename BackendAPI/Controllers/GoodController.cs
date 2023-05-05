using BackendAPI.Contracts.Good;
using Domain.Interfaces;
using Domain.Models;
using Mapster;
using Microsoft.AspNetCore.Mvc;

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

		/// <summary>
		/// Выводит все товары
		/// </summary>
		/// <returns></returns>
		[HttpGet]
		public async Task<IActionResult> GetAll() => Ok(await _goodService.GetAll());

		/// <summary>
		/// Выводит товар по id
		/// </summary>
		/// <param name="id">Id товара</param>
		/// <returns></returns>
		[HttpGet("{id}")]
		public async Task<IActionResult> GetById(int id) => Ok(_goodService.GetById(id).Adapt<GetGoodResponse>());

		/// <summary>
		/// Добавляет новый товар
		/// </summary>
		/// <remarks>
		/// Пример запроса:
		/// 
		///     {
		///         "name": "Steelseries Rival 3",
		///         "description": "Компьютерная мышь Steelseries Rival 3",
		///         "amount": 19,
		///         "price": 2999.99,
		///         "preview": null,
		///         "isDeleted": "31-03-2023 10:18:54" //Опционально
		///     }
		///     
		/// </remarks>
		/// <param name="goodRequest">Товар</param>
		/// <returns></returns>
		[HttpPost]
		public async Task<IActionResult> Add(CreateGoodRequest goodRequest)
		{
			var goodDto = goodRequest.Adapt<Good>();

			await _goodService.Create(goodDto);

			return Ok();
		}

		/// <summary>
		/// Изменяет товар
		/// </summary>
		/// <remarks>
		/// Пример запроса:
		/// 
		///     {
		///         "name": "Steelseries Rival 7",
		///         "description": "Компьютерная мышь Steelseries Rival 7",
		///         "amount": 19,
		///         "price": 2999.99,
		///         "preview": null,
		///         "isDeleted": "31-03-2023 10:18:54" //Опционально
		///     }
		///     
		/// </remarks>
		/// <param name="good">Товар</param>
		/// <returns></returns>
		[HttpPut]
		public async Task<IActionResult> Update(Good good)
		{
			await _goodService.Update(good);

			return Ok();
		}

		/// <summary>
		/// Удаляет товар
		/// </summary>
		/// <param name="id">Id товара</param>
		/// <returns></returns>
		[HttpDelete]
		public async Task<IActionResult> Delete(int id)
		{
			await _goodService.Delete(id);

			return Ok();
		}
	}
}
