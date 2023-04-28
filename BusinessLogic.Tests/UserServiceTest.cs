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

        //Содержит список неправильных моделей пользователей
        public static IEnumerable<object[]> GetIncorrectUsers()
        {
            return new List<object[]>()
            {
                new object[] { new User { Name = "", Surname = "", Email = "", Password = "", Balance = -9, Role = "", CreatedAt = DateTime.Now } },
                new object[] { new User { Name = "Test", Surname = "", Email = "", Password = "", Balance = -9, Role = "", CreatedAt = DateTime.Now } },
                new object[] { new User { Name = "Test", Surname = "Test", Email = "", Password = "", Balance = -9, Role = "", CreatedAt = DateTime.Now } },
                new object[] { new User { Name = "Test", Surname = "Test", Email = "MyEmail@mail.com", Password = "", Balance = -9, Role = "", CreatedAt = DateTime.Now } },
                new object[] { new User { Name = "Test", Surname = "Test", Email = "MyEmail@mail.com", Password = "12345q", Balance = -9, Role = "", CreatedAt = DateTime.Now } },
                new object[] { new User { Name = "Test", Surname = "Test", Email = "MyEmail@mail.com", Password = "12345q", Balance = -9, Role = "User", CreatedAt = DateTime.Now } }
            };
        }

        //Тест на проверку вызова исключения при попытке создать нового пользователя с аргументом null
        [Fact]
        public async Task CreateAsunc_NullUser_ShouldThrownNullArgumentException()
        {
            #pragma warning disable CS8625
            var ex = await Assert.ThrowsAnyAsync<ArgumentNullException>(() => service.Create(null));

            Assert.IsType<ArgumentNullException>(ex);
            userRepositoryMock.Verify(x => x.Create(It.IsAny<User>()), Times.Never);
        }

        //Проверка на корректность работы валидации данных при создании пользователя
        [Theory]
        [MemberData(nameof(GetIncorrectUsers))]
        public async Task CreateAsyncNewUserShouldNotCreateNewUser(User user)
        {
            var newUser = user;

            var ex = await Assert.ThrowsAnyAsync<ArgumentException>(() => service.Create(newUser));

            userRepositoryMock.Verify(x => x.Create(It.IsAny<User>()), Times.Never);
            Assert.IsType<ArgumentException>(ex);
        }
    }
}
