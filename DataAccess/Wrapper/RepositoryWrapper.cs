using DataAccess.Context;
using Domain.Interfaces;
using DataAccess.Repositories;

namespace DataAccess.Wrapper
{
    public class RepositoryWrapper : IRepositoryWrapper
    {
        private InternetShopContext _repoContext;

        private IUserRepository _user;

        public IUserRepository User
        {
            get
            {
                if (_user == null)
                {
                    _user = new UserRepository(_repoContext);
                }

                return _user;
            }
        }

        public RepositoryWrapper(InternetShopContext repositoryContext) => _repoContext = repositoryContext;    

        public async Task Save() => await _repoContext.SaveChangesAsync();
    }
}