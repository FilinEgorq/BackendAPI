﻿using Microsoft.AspNetCore.Mvc;
using Domain.Interfaces;
using Domain.Models;

namespace BackendAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CartController : ControllerBase
    {
        private ICartService _cartService;

        public CartController(ICartService userService)
        {
            _cartService = userService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll() => Ok(await _cartService.GetAll());

        [HttpGet("{userId}/{goodId}")]
        public async Task<IActionResult> GetById(int userId, int goodId) => Ok(await _cartService.GetById(userId, goodId));

        [HttpPost]
        public async Task<IActionResult> Add(Cart cart)
        {
            await _cartService.Create(cart);

            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> Update(Cart cart)
        {
            await _cartService.Update(cart);

            return Ok();
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int userId, int goodId)
        {
            await _cartService.Delete(userId, goodId);

            return Ok();
        }
    }
}
