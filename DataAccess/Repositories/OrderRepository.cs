using DataAccess.Context;
using Domain.Interfaces;
using Domain.Models;

namespace DataAccess.Repositories
{
    public class OrderRepository : RepositoryBase<Order>, IOrderRepository
    {
        public OrderRepository(InternetShopContext repositoryContext) : base(repositoryContext) { }
    }
}