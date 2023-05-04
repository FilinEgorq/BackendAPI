using DataAccess.Context;
using Domain.Interfaces;
using Domain.Models;

namespace DataAccess.Repositories
{
    public class CategoryRepository : RepositoryBase<Category>, ICategoryRepository
    {
        public CategoryRepository(InternetShopContext repositoryContext) : base(repositoryContext) { }
    }
}