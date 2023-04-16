using Microsoft.AspNetCore.Mvc;
using Domain.Interfaces;
using Domain.Models;
using Mapster;
using BackendAPI.Contracts.Order;

namespace BackendAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private IOrderService _orderService;

        public OrderController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        /// <summary>
        /// Выводит все заказы
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> GetAll() => Ok(await _orderService.GetAll());

        /// <summary>
        /// Выводит конкретный заказ по его id
        /// </summary>
        /// <param name="id">Id заказа</param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            return Ok(_orderService.GetById(id).Adapt<GetOrderResponse>());
        }

        /// <summary>
        /// Добавляет новый заказ
        /// </summary>
        /// <remarks>
        /// Пример запроса:
        /// 
        ///     {
        ///         "userId": 1,
        ///         "fullCost" : 7891.45,
        ///         "DeliveryMethod": "Доставка в постамат",
        ///         "Status": "В обработке",
        ///         "CreatedAt": "31-03-2023 10:23:00" //Опционально, если не указывать, то возьмётся текущая дата и время
        ///         "deletedAt": "31-03-2023 10:24:00" //Опционально
        ///     }
        ///     
        /// </remarks>
        /// <param name="request">Заказ</param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> Add(CreateOrderRequest request)
        {
            var orderDto = request.Adapt<Order>();

            await _orderService.Create(orderDto);

            return Ok();
        }

        /// <summary>
        /// Изменяет заказ
        /// </summary>
        /// <remarks>
        /// Пример запроса:
        /// 
        ///     {
        ///         "userId": 1,
        ///         "fullCost" : 7891.45,
        ///         "DeliveryMethod": "Доставка в постамат",
        ///         "Status": "Доставлено",
        ///         "CreatedAt": "31-03-2023 10:23:00" //Опционально, если не указывать, то возьмётся текущая дата и время
        ///         "deletedAt": "31-03-2023 10:24:00" //Опционально
        ///     }
        ///     
        /// </remarks>
        /// <param name="order">Заказ</param>
        /// <returns></returns>
        [HttpPut]
        public async Task<IActionResult> Update(Order order)
        {
            await _orderService.Update(order);

            return Ok();
        }

        /// <summary>
        /// Удаляет заказ
        /// </summary>
        /// <param name="id">Id заказа</param>
        /// <returns></returns>
        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            await _orderService.Delete(id);

            return Ok();
        }
    }
}
