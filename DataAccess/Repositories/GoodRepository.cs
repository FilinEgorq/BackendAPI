using DataAccess.Context;
using Domain.Interfaces;
using Domain.Models;

namespace DataAccess.Repositories
{
	public class GoodRepository : RepositoryBase<Good>, IGoodRepository
	{
		public GoodRepository(InternetShopContext repositoryContext) : base(repositoryContext) { }
	}
}