using BusinessLogic.Services;
using Domain.Interfaces;
using Domain.Models;
using Moq;

namespace BusinessLogic.Tests
{
    public class CartServiceTest
    {
        private readonly CartService service;
        private readonly Mock<ICartRepository> cartRepositoryMock;

        public CartServiceTest()
        {
            var repositoryWrapperMock = new Mock<IRepositoryWrapper>();
            cartRepositoryMock = new Mock<ICartRepository>();


            repositoryWrapperMock.Setup(x => x.Cart).Returns(cartRepositoryMock.Object);

            service = new CartService(repositoryWrapperMock.Object);
        }

        //Тест на проверку вызова исключения при попытке создать новую позицию в корзине с аргументом null
        [Fact]
        public async Task CreateAsync_NullCart_ShouldThrownNullArgumentException()
        {
#pragma warning disable CS8625
            var ex = await Assert.ThrowsAnyAsync<ArgumentNullException>(() => service.Create(null));

            Assert.IsType<ArgumentNullException>(ex);
            cartRepositoryMock.Verify(x => x.Create(It.IsAny<Cart>()), Times.Never);
        }

        //Тест на проверку вызова исключения при попытке создать новую позицию в корзине с количеством товара, меньшее чем 1
        [Fact]
        public async Task CreateAsync_InvalidCart_ShouldThrownArgumentException()
        {
            var cart = new Cart()
            {
                UserId = 1,
                GoodId = 1,
                Count = -3
            };

#pragma warning disable CS8625
            var ex = await Assert.ThrowsAnyAsync<ArgumentException>(() => service.Create(cart));

            Assert.IsType<ArgumentException>(ex);
            cartRepositoryMock.Verify(x => x.Create(It.IsAny<Cart>()), Times.Never);
        }
    }
}