using DataAccess.Context;
using Domain.Interfaces;
using Domain.Models;

namespace DataAccess.Repositories
{
	public class UserRepository : RepositoryBase<User>, IUserRepository
	{
		public UserRepository(InternetShopContext repositoryContext) : base(repositoryContext) { }

		public async Task<User?> GetByEmailAndPassword(string email, string password)
		{
			var result = await base.FindByCondition(x => x.Email == email && x.Password == password);

			if (result == null || result.Count == 0) return null;

			return result.First();
		}
	}
}