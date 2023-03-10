using Domain.Models;

namespace Domain.Interfaces
{
    public interface IGoodCharachteristicsService
    {
        Task<List<GoodCharachteristic>> GetAll();

        Task<GoodCharachteristic> GetById(int id);

        Task Create(GoodCharachteristic model);

        Task Update(GoodCharachteristic model);

        Task Delete(int id);
    }
}