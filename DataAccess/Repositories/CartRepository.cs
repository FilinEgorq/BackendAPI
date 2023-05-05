using DataAccess.Context;
using Domain.Interfaces;
using Domain.Models;

namespace DataAccess.Repositories
{
	public class CartRepository : RepositoryBase<Cart>, ICartRepository
	{
		public CartRepository(InternetShopContext repositoryContext) : base(repositoryContext) { }
	}
}