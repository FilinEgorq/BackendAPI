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
	public class CategoryServiceTest
	{
		private readonly CategoryService service;
		private readonly Mock<ICategoryRepository> categoryRepositoryMock;

		public CategoryServiceTest()
		{
			var repositoryWrapperMock = new Mock<IRepositoryWrapper>();
			categoryRepositoryMock = new Mock<ICategoryRepository>();


			repositoryWrapperMock.Setup(x => x.Category).Returns(categoryRepositoryMock.Object);

			service = new CategoryService(repositoryWrapperMock.Object);
		}

		//Тест на проверку вызова исключения при попытке создать новую категорию в корзине с аргументом null
		[Fact]
		public async Task CreateAsync_NullCategory_ShouldThrownNullArgumentException()
		{
#pragma warning disable CS8625
			var ex = await Assert.ThrowsAnyAsync<ArgumentNullException>(() => service.Create(null));

			Assert.IsType<ArgumentNullException>(ex);
			categoryRepositoryMock.Verify(x => x.Create(It.IsAny<Category>()), Times.Never);
		}

		//Тест на проверку вызова исключения при попытке создать новую позицию в корзине с количеством товара, меньшее чем 1
		[Fact]
		public async Task CreateAsync_InvalidCategory_ShouldThrownArgumentException()
		{
			var category = new Category()
			{
				ParentId = null,
				Name = "",
				Description = null
			};

#pragma warning disable CS8625
			var ex = await Assert.ThrowsAnyAsync<ArgumentException>(() => service.Create(category));

			Assert.IsType<ArgumentException>(ex);
			categoryRepositoryMock.Verify(x => x.Create(It.IsAny<Category>()), Times.Never);
		}
	}
}
