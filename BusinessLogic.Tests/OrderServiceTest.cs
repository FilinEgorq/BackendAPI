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
	public class OrderServiceTest
	{
		private readonly OrderService service;
		private readonly Mock<IOrderRepository> orderRepositoryMock;

		public OrderServiceTest()
		{
			var repositoryWrapperMock = new Mock<IRepositoryWrapper>();
			orderRepositoryMock = new Mock<IOrderRepository>();


			repositoryWrapperMock.Setup(x => x.Order).Returns(orderRepositoryMock.Object);

			service = new OrderService(repositoryWrapperMock.Object);
		}

		public static IEnumerable<object[]> GetInvalidOrders()
		{
			return new List<object[]>()
			{
				new object[] { new Order { UserId = 1, FullCost = -3, DeliveryMethod = "", Status = "" } },
				new object[] { new Order { UserId = 1, FullCost = (decimal)21999.99, DeliveryMethod = "", Status = "" } },
				new object[] { new Order { UserId = 1, FullCost = (decimal)21999.99, DeliveryMethod = "Курьером", Status = "" } }
			};
		}

		//Тест на проверку вызова исключения при попытке создать новый заказ с аргументом null
		[Fact]
		public async Task CreateAsync_NullOrder_ShouldThrownNullArgumentException()
		{
#pragma warning disable CS8625
			var ex = await Assert.ThrowsAnyAsync<ArgumentNullException>(() => service.Create(null));

			Assert.IsType<ArgumentNullException>(ex);
			orderRepositoryMock.Verify(x => x.Create(It.IsAny<Order>()), Times.Never);
		}

		//Тест на проверку вызова исключения при попытке создать новый заказ с неправильными данными
		[Theory]
		[MemberData(nameof(GetInvalidOrders))]
		public async Task CreateAsyncNewOrderShouldNotCreateNewOrder(Order order)
		{
			var newOrder = order;
			var ex = await Assert.ThrowsAnyAsync<ArgumentException>(() => service.Create(newOrder));

			orderRepositoryMock.Verify(x => x.Create(It.IsAny<Order>()), Times.Never);
			Assert.IsType<ArgumentException>(ex);
		}
	}
}
