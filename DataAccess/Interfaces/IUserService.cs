using DataAccess.Models;

namespace DataAccess.Interfaces
{
    public interface IUserService
    {
        Task<List<User>> GetAll();
    }
}
