using BusinessLogic.Services;
using Domain.Interfaces;
using Moq;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Tests
{
    public class UserServiceTest
    {
        private readonly UserService service;
        private readonly Mock<IUserRepository> userRepositoryMock;

        public UserServiceTest()
        {
            var repositoryWrapperMock = new Mock<IRepositoryWrapper>();
            userRepositoryMock = new Mock<IUserRepository>();

            repositoryWrapperMock.Setup(x => x.User).Returns(userRepositoryMock.Object);

            service = new UserService(repositoryWrapperMock.Object);
        }

        [Fact]
        public async Task CreateAsunc_NullUser_ShouldThrownNullArgumentException()
        {
            var ex = await Assert.ThrowsAnyAsync<ArgumentNullException>(() => service.Create(null));

            Assert.IsType<ArgumentNullException>(ex);
            userRepositoryMock.Verify(x => x.Create(It.IsAny<User>()), Times.Never);
        }

        [Fact]
        public async Task CreateAsyncNewUserShouldNotCreateNewUser()
        {
            var newUser = new User()
            {
                Name = "",
                Surname = "",
                Email = "",
                Password = "",
                Balance = 0,
                Role = "",
                CreatedAt = DateTime.Now
            };

            var ex = await Assert.ThrowsAnyAsync<ArgumentException>(() => service.Create(newUser));

            userRepositoryMock.Verify(x => x.Create(It.IsAny<User>()), Times.Never);
            Assert.IsType<ArgumentException>(ex);
        }
    }
}
