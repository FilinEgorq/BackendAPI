﻿using DataAccess.Context;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace DataAccess.Repositories
{
	public abstract class RepositoryBase<T> : IRepositoryBase<T> where T : class
	{
		protected InternetShopContext RepositoryContext { get; set; }

		public RepositoryBase(InternetShopContext internetShopContext) => RepositoryContext = internetShopContext;

		public async Task<List<T>> FindAll() => await RepositoryContext.Set<T>().AsNoTracking().ToListAsync();

		public async Task<List<T>> FindByCondition(Expression<Func<T, bool>> expression) => await RepositoryContext.Set<T>()
																							.Where(expression).AsNoTracking().ToListAsync();

		public async Task Create(T entity) => await RepositoryContext.Set<T>().AddAsync(entity);

		public async Task Update(T entity) => RepositoryContext.Set<T>().Update(entity);

		public async Task Delete(T entity) => RepositoryContext.Set<T>().Remove(entity);
	}
}