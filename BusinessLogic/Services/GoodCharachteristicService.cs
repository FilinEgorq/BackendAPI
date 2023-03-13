using Domain.Interfaces;
using Domain.Models;

namespace BusinessLogic.Services
{
    public class GoodCharachteristicService
    {
        private IRepositoryWrapper _repositoryWrapper;

        public GoodCharachteristicService(IRepositoryWrapper repositoryWrapper) => _repositoryWrapper = repositoryWrapper;

        public async Task<List<GoodCharachteristic>> GetAll() => await _repositoryWrapper.GoodCharachteristics.FindAll();

        public async Task<GoodCharachteristic> GetById(int goodId, int filterName)
        {
            var user = await _repositoryWrapper.GoodCharachteristics.FindByCondition(x => x.GoodId == goodId && x.FilterName == filterName);

            return user.First();
        }

        public async Task Create(GoodCharachteristic model)
        {
            await _repositoryWrapper.GoodCharachteristics.Create(model);
            await _repositoryWrapper.Save();
        }

        public async Task Update(GoodCharachteristic model)
        {
            await _repositoryWrapper.GoodCharachteristics.Update(model);
            await _repositoryWrapper.Save();
        }

        public async Task Delete(int goodId, int filterName)
        {
            var user = await _repositoryWrapper.GoodCharachteristics.FindByCondition(x => x.GoodId == goodId && x.FilterName == filterName);

            await _repositoryWrapper.GoodCharachteristics.Delete(user.First());
            await _repositoryWrapper.Save();
        }
    }
}