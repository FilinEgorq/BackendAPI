using DataAccess.Context;
using Domain.Interfaces;
using Domain.Models;

namespace DataAccess.Repositories
{
	public class FilterRepository : RepositoryBase<Filter>, IFilterRepository
	{
		public FilterRepository(InternetShopContext repositoryContext) : base(repositoryContext) { }
	}
}