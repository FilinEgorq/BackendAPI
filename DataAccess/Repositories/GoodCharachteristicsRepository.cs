using DataAccess.Context;
using Domain.Interfaces;
using Domain.Models;

namespace DataAccess.Repositories
{
    public class GoodCharachteristicRepository : RepositoryBase<GoodCharachteristic>, IGoodCharachteristicRepository
    {
        public GoodCharachteristicRepository(InternetShopContext repositoryContext) : base(repositoryContext) { }
    }
}