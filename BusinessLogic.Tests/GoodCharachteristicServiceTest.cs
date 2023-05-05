using BusinessLogic.Services;
using Domain.Interfaces;
using Domain.Models;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Tests
{
	public class GoodCharachteristicServiceTest
	{
		private readonly GoodCharachteristicService service;
		private readonly Mock<IGoodCharachteristicRepository> goodCharachteristicRepositoryMock;

		public GoodCharachteristicServiceTest()
		{
			var repositoryWrapperMock = new Mock<IRepositoryWrapper>();
			goodCharachteristicRepositoryMock = new Mock<IGoodCharachteristicRepository>();


			repositoryWrapperMock.Setup(x => x.GoodCharachteristic).Returns(goodCharachteristicRepositoryMock.Object);

			service = new GoodCharachteristicService(repositoryWrapperMock.Object);
		}

		//Тест на проверку вызова исключения при попытке создать новую характеристику для товара в корзине с аргументом null
		[Fact]
		public async Task CreateAsync_NullGoodCharachteristic_ShouldThrownNullArgumentException()
		{
#pragma warning disable CS8625
			var ex = await Assert.ThrowsAnyAsync<ArgumentNullException>(() => service.Create(null));

			Assert.IsType<ArgumentNullException>(ex);
			goodCharachteristicRepositoryMock.Verify(x => x.Create(It.IsAny<GoodCharachteristic>()), Times.Never);
		}

		//Здесь не нужны тесты для проверки каждого свойства, т.к. неправильный id товара отловит СУБД,
		//а значение характеристики может быть совершенно любым
	}
}
