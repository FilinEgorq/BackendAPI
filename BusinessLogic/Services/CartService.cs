﻿using Domain.Interfaces;
using Domain.Models;
using System.Reflection;

namespace BusinessLogic.Services
{
	public class CartService : ICartService
	{
		private IRepositoryWrapper _repositoryWrapper;

		public CartService(IRepositoryWrapper repositoryWrapper) => _repositoryWrapper = repositoryWrapper;

		public async Task<List<Cart>> GetAll() => await _repositoryWrapper.Cart.FindAll();

		public async Task<Cart> GetById(int userId, int goodId)
		{
			var user = await _repositoryWrapper.Cart.FindByCondition(x => x.GoodId == goodId && x.UserId == userId);

			return user.First();
		}

		public async Task Create(Cart model)
		{
			if (model == null) throw new ArgumentNullException(nameof(model));

			if (model.Count < 1) throw new ArgumentException(nameof(model.Count));

			await _repositoryWrapper.Cart.Create(model);
			await _repositoryWrapper.Save();
		}

		public async Task Update(Cart model)
		{
			await _repositoryWrapper.Cart.Update(model);
			await _repositoryWrapper.Save();
		}

		public async Task Delete(int userId, int goodId)
		{
			var user = await _repositoryWrapper.Cart.FindByCondition(x => x.GoodId == goodId && x.UserId == userId);

			await _repositoryWrapper.Cart.Delete(user.First());
			await _repositoryWrapper.Save();
		}
	}
}