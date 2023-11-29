using AutoMapper;
using EDWebshop.Api.Controllers;
using EDWebshop.Api.MappingProfiles;
using EDWebshop.Contracts.DTOs;
using EDWebshop.Contracts.Entities;
using EDWebshop.Data.Context;
using EDWebshop.Data.Repositories;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Moq.EntityFrameworkCore;

namespace EDWebshop.Api.Tests.Controllers
{
    [TestClass]
    public class ProductControllerTests
    {
        private readonly ProductsController _sut;

        public ProductControllerTests()
        {
            var fakeFlowerProductList = GetFakeFlowerProductList();

            var dbContextMock = new Mock<DataContext>();
            dbContextMock.Setup(x => x.Set<FlowerProduct>()).ReturnsDbSet(fakeFlowerProductList);
            dbContextMock.Setup(x => x.Products).ReturnsDbSet(fakeFlowerProductList);

            var flowerProductRepository = new FlowerProductRepository(dbContextMock.Object);

            var autoMapperConfig = new MapperConfiguration(config => config.AddProfile<MappingProfile>());
            var autoMapper = new Mapper(autoMapperConfig);

            _sut = new ProductsController(flowerProductRepository, autoMapper);
        }

        private static List<FlowerProduct> GetFakeFlowerProductList() => new()
        {
           new FlowerProduct()
           {
               Id = 1,
               Title = "Torkad lavendel",
               Description = "Luktar gott",
               LongDescription = "Förgyll ditt hem med en harmonisk doft av lavendel från Frankrike",
               ImagePath = "http://image.com/example1.png",
               Length = 70,
               Weight = 120,
               Variants =
                  [
                      new ProductVariant()
                      {
                           Id = 1,
                           Name = "Bukett",
                           Price = 295,
                      },
                      new ProductVariant()
                      {
                           Id = 2,
                           Name = "Halvbukett",
                           Price = 198,
                      }
                  ]
           },
           new FlowerProduct()
           {
               Id = 2,
               Title = "Skäggvete",
               Description = "Torkad skäggvete med mörka toppar.",
               LongDescription = "Passar utmärkt att arrangera i en smal urna för ett lantligt och naturligt intryck.",
               ImagePath = "http://image.com/example2.png",
               Length = 68,
               Weight = 155,
               Variants =
                  [
                      new ProductVariant()
                      {
                           Id = 3,
                           Name = "Bukett",
                           Price = 249,
                      },
                       new ProductVariant()
                      {
                           Id = 4,
                           Name = "Bunt",
                           Price = 79,
                      }
                  ]
           }
        };

        [TestMethod]
        public async Task GetAll_Should_Return_200_OK_With_All_Items()
        {
            // Act
            var result = await _sut.GetAll();

            // Assert
            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result.Result, typeof(OkObjectResult));

            var okObject = result.Result as OkObjectResult;
            var okObjectValue = okObject!.Value as List<FlowerProductListDto>;

            Assert.AreEqual(2, okObjectValue!.Count);
        }

        [TestMethod]
        public async Task Get_Should_Return_200_OK_With_The_Item_If_Given_Valid_Id()
        {
            // Arrange
            var id = 1;

            // Act
            var result = await _sut.Get(id);

            // Assert
            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result.Result, typeof(OkObjectResult));

            var okObject = result.Result as OkObjectResult;
            var okObjectValue = okObject!.Value as FlowerProductDto;

            Assert.IsNotNull(okObjectValue);
            Assert.IsInstanceOfType(okObjectValue, typeof(FlowerProductDto));
        }

        [TestMethod]
        public async Task Get_Should_Return_404_Not_Found_If_Given_Invalid_Id()
        {
            // Arrange
            var id = 3;

            // Act
            var result = await _sut.Get(id);

            // Assert
            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result.Result, typeof(NotFoundResult));
        }

        [TestMethod]
        public async Task Create_Should_Return_201_Created_When_Passing_Valid_Object()
        {
            // Arrange
            var product = new FlowerProductDto();

            // Act
            var result = await _sut.Create(product);

            // Assert
            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result.Result, typeof(CreatedAtActionResult));

            var okObject = result.Result as CreatedAtActionResult;
            var okObjectValue = okObject!.Value as FlowerProductDto;

            Assert.IsNotNull(okObjectValue);
            Assert.IsInstanceOfType(okObjectValue, typeof(FlowerProductDto));
        }

        [TestMethod]
        public async Task Create_Should_Return_404_BadRequest_When_Passing_Invalid_Object()
        {
            // Arrange
            var product = new FlowerProductDto() { Id = 1 };

            // Act
            var result = await _sut.Create(product);

            // Assert
            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result.Result, typeof(BadRequestObjectResult));
        }

        [TestMethod]
        public async Task Delete_Should_Return_204_NoContent_When_Passing_Valid_Id()
        {
            // Arrange
            var id = 1;

            // Act
            var result = await _sut.Delete(id);

            // Assert
            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(NoContentResult));
        }

        [TestMethod]
        public async Task Delete_Should_Return_404_NotFound_When_Passing_Invalid_Id()
        {
            // Arrange
            var id = 7;

            // Act
            var result = await _sut.Delete(id);

            // Assert
            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(NotFoundResult));
        }

    }
}