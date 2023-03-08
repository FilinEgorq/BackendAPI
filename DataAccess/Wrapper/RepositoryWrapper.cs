using DataAccess.Models;
using DataAccess.Interfaces;
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
            }
        }

        public RepositoryWrapper(InternetShopContext repositoryContext) => _repoContext = repositoryContext;    

        public void Save() => _repoContext.SaveChanges();
    }
}