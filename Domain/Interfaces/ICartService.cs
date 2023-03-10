using Domain.Models;

namespace Domain.Interfaces
{
    public interface ICartService
    {
        Task<List<Cart>> GetAll();

        Task<Cart> GetById(int id);

        Task Create(Cart model);

        Task Update(Cart model);

        Task Delete(int id);
    }
}