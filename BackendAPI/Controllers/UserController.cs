using Microsoft.AspNetCore.Mvc;
using Domain.Interfaces;
using Domain.Models;

namespace BackendAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }
        
        [HttpGet]
        public async Task<IActionResult> GetAll() => Ok(await _userService.GetAll());

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id) => Ok(await _userService.GetById(id));

        /// <summary>
        /// Добавляет нового пользователя
        /// </summary>
        /// <remarks>
        /// Пример запроса:
        /// 
        ///     {
        ///         "name": "Иванов",
        ///         "surname": "Иван",
        ///         "email": "JustEmail@mail.com",
        ///         "password": "12345",
        ///         "phoneNumber": 88005553535, //Опционально
        ///         "balance": 10000.35,
        ///         "role": "User",
        ///         "birthday": "15-04-1999", //Опционально
        ///         "createdAt": "17-03-2023T11:39:43", //Опционально, если не указывать возьмется текущее время и дата
        ///         "isDeleted": "17-03-2023" //Опционально
        ///     }
        /// 
        /// </remarks>
        /// <param name="user">Пользователь</param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> Add(User user)
        {
            await _userService.Create(user);

            return Ok();
        }

        /// <summary>
        /// Изменяет данные пользователя
        /// </summary>
        /// <remarks>
        /// Пример запроса
        /// 
        ///     {
        ///         "id": 1,
        ///         "name": "Иванов",
        ///         "surname": "Иван",
        ///         "email": "JustEmail@mail.com",
        ///         "password": "12345",
        ///         "phoneNumber": 88005553535, //Опционально
        ///         "balance": 10000.35,
        ///         "role": "User",
        ///         "birthday": "15-04-1999", //Опционально
        ///         "createdAt": "17-03-2023T11:39:43", //Опционально, если не указывать возьмется текущее время и дата
        ///         "isDeleted": "17-03-2023" //Опционально
        ///     }
        ///     
        /// </remarks>
        /// <param name="user">Изменённая модели пользователя</param>
        /// <returns></returns>
        [HttpPut]
        public async Task<IActionResult> Update(User user)
        {
            await _userService.Update(user);

            return Ok();
        }

        /// <summary>
        /// Удаляет пользователя
        /// </summary>
        /// <param name="id">id пользователя</param>
        /// <returns></returns>
        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            await _userService.Delete(id);

            return Ok();
        }
     }
}
