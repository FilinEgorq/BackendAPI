using BusinessLogic.Services;
using Domain.Interfaces;
using Domain.Models;
using Moq;

namespace BusinessLogic.Tests
{
	public class GoodServiceTest
	{
		private readonly GoodService service;
		private readonly Mock<IGoodRepository> goodRepositoryMock;

		public GoodServiceTest()
		{
			var repositoryWrapperMock = new Mock<IRepositoryWrapper>();
			goodRepositoryMock = new Mock<IGoodRepository>();


			repositoryWrapperMock.Setup(x => x.Good).Returns(goodRepositoryMock.Object);

			service = new GoodService(repositoryWrapperMock.Object);
		}

		//Возвращает список неправильных товаров (для тестов)
		public static IEnumerable<object[]> GetInvalidGoods()
		{
			return new List<object[]>()
			{
				new object[] { new Good { Name = "", Amount = -2, Price = (decimal)-2.49 } },
				new object[] { new Good { Name = "TestName", Amount = -2, Price = (decimal)-2.49 } },
				new object[] { new Good { Name = "TestName", Amount = 13, Price = (decimal)-2.49 } }
			};
		}

		//Тест на проверку вызова исключения при попытке создать новый товар в корзине с аргументом null
		[Fact]
		public async Task CreateAsync_NullGood_ShouldThrownNullArgumentException()
		{
#pragma warning disable CS8625
			var ex = await Assert.ThrowsAnyAsync<ArgumentNullException>(() => service.Create(null));

			Assert.IsType<ArgumentNullException>(ex);
			goodRepositoryMock.Verify(x => x.Create(It.IsAny<Good>()), Times.Never);
		}

		[Theory]
		[MemberData(nameof(GetInvalidGoods))]
		public async Task CreateAsyncNewGoodShouldNotCreateNewGood(Good good)
		{
			var newGood = good;
			var ex = await Assert.ThrowsAnyAsync<ArgumentException>(() => service.Create(newGood));

			goodRepositoryMock.Verify(x => x.Create(It.IsAny<Good>()), Times.Never);
			Assert.IsType<ArgumentException>(ex);
		}
	}
}