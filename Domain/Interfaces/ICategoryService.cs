﻿using Domain.Models;

namespace Domain.Interfaces
{
	public interface ICategoryService
	{
		Task<List<Category>> GetAll();

		Task<Category> GetById(int id);

		Task Create(Category model);

		Task Update(Category model);

		Task Delete(int id);
	}
}