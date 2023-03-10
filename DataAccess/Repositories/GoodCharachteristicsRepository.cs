using Domain.Interfaces;
using Domain.Models;
using DataAccess.Context;

namespace DataAccess.Repositories
{
    public class GoodCharachteristicRepository : RepositoryBase<GoodCharachteristic>, IGoodCharachteristicsRepository
    {
        public GoodCharachteristicRepository(InternetShopContext repositoryContext) : base(repositoryContext) { }
    }
}