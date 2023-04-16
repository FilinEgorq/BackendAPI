using Microsoft.AspNetCore.Mvc;
using Domain.Interfaces;
using Domain.Models;
using Mapster;
using BackendAPI.Contracts.Category;

namespace BackendAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        /// <summary>
        /// Выводит все категории
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> GetAll() => Ok(await _categoryService.GetAll());

        /// <summary>
        /// Выводит категории товара
        /// </summary>
        /// <param name="id">Id товара</param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var category = await _categoryService.GetById(id);

            return Ok(category.Adapt<GetCategoryResponse>());
        }

        /// <summary>
        /// Добавляет категорию
        /// </summary>
        /// <remarks>
        /// Пример запроса:
        /// 
        ///     {
        ///         "id": 1,
        ///         "parentId": 2 //Опционально
        ///         "name": "Периферийные устройства",
        ///         "description": "Все периферийные устройства" //Опционально
        ///         "isDeleted": "03-31-2023 10:00:00" //Опционально
        ///     }
        ///     
        /// </remarks>
        /// <param name="category">Категория товара</param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> Add(CreateCategoryRequest request)
        {
            var categoryDto = request.Adapt<Category>();

            await _categoryService.Create(categoryDto);

            return Ok();
        }

        /// <summary>
        /// Изменяет категорию
        /// </summary>
        /// <remarks>
        /// Пример запроса:
        /// 
        ///     {
        ///         "id": 1,
        ///         "parentId": 2 //Опционально
        ///         "name": "Компьютерные мыши",
        ///         "description": "Компьютерные мыши для ПК и ноутбуков" //Опционально
        ///         "isDeleted": "03-31-2023 10:00:00" //Опционально
        ///     }
        ///     
        /// </remarks>
        /// <param name="category">Категория товара</param>
        /// <returns></returns>
        [HttpPut]
        public async Task<IActionResult> Update(Category category)
        {
            await _categoryService.Update(category);

            return Ok();
        }

        /// <summary>
        /// Удаляет категорию
        /// </summary>
        /// <param name="id">id категории</param>
        /// <returns></returns>
        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            await _categoryService.Delete(id);

            return Ok();
        }
    }
}
