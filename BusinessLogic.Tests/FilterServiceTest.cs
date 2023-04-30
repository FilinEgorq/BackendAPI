using BusinessLogic.Services;
using Domain.Interfaces;
using Domain.Models;
using Moq;

namespace BusinessLogic.Tests
{
    public class FilterServiceTest
    {
        private readonly FilterService service;
        private readonly Mock<IFilterRepository> filterRepositoryMock;

        public FilterServiceTest()
        {
            var repositoryWrapperMock = new Mock<IRepositoryWrapper>();
            filterRepositoryMock = new Mock<IFilterRepository>();


            repositoryWrapperMock.Setup(x => x.Filter).Returns(filterRepositoryMock.Object);

            service = new FilterService(repositoryWrapperMock.Object);
        }

        //Тест на проверку вызова исключения при попытке создать новый фильтр с аргументом null
        [Fact]
        public async Task CreateAsync_NullFilter_ShouldThrownNullArgumentException()
        {
#pragma warning disable CS8625
            var ex = await Assert.ThrowsAnyAsync<ArgumentNullException>(() => service.Create(null));

            Assert.IsType<ArgumentNullException>(ex);
            filterRepositoryMock.Verify(x => x.Create(It.IsAny<Filter>()), Times.Never);
        }

        //Тест на проверку вызова исключения при попытке создать новый фильтр, с неправильным именем
        [Fact]
        public async Task CreateAsync_InvalidFilter_ShouldThrownArgumentException()
        {
            var filter = new Filter()
            {
                Name = "",
                CategoryId = 1
            };

#pragma warning disable CS8625
            var ex = await Assert.ThrowsAnyAsync<ArgumentException>(() => service.Create(filter));

            Assert.IsType<ArgumentException>(ex);
            filterRepositoryMock.Verify(x => x.Create(It.IsAny<Filter>()), Times.Never);
        }
    }
}