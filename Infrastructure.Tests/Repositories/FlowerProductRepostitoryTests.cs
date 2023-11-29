using EDWebshop.Contracts.Entities;
using EDWebshop.Data.Context;
using EDWebshop.Data.Repositories;
using Moq;
using Moq.EntityFrameworkCore;

namespace EDWebshop.Data.Tests.Repositories
{
    [TestClass]
    public class FlowerProductRepostitoryTests
    {
        private readonly FlowerProductRepository _sut;

        public FlowerProductRepostitoryTests()
        {
            var fakeFlowerProductList = GetFakeFlowerProductList();

            var dbContextMock = new Mock<DataContext>();
            dbContextMock.Setup(x => x.Set<FlowerProduct>()).ReturnsDbSet(fakeFlowerProductList);
            dbContextMock.Setup(x => x.Products).ReturnsDbSet(fakeFlowerProductList);

            _sut = new FlowerProductRepository(dbContextMock.Object);
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
        public async Task GetAsync_Should_Return_A_Correctly_Mapped_FlowerProduct_From_The_Database()
        {
            // Act
            var result = await _sut.GetAsync(1);

            // Assert
            AssertFirstFlowerProduct(result);
        }

        [TestMethod]
        public async Task GetAllAsync_Should_Return_All_Items_From_The_Database()
        {
            // Act
            var result = await _sut.GetAllAsync();

            // Assert
            Assert.AreEqual(2, result.Count());
            AssertFirstFlowerProduct(result.First());
            AssertSecondFlowerProduct(result.Last());
        }

        [TestMethod]
        public async Task GetAsync_Should_Return_Null_When_Given_Invalid_Id()
        {
            // Arrange
            var id = -1;

            // Act
            var actual = await _sut.GetAsync(id);

            // Assert
            Assert.IsNull(actual);
        }

        private static void AssertFirstFlowerProduct(FlowerProduct? result)
        {
            Assert.IsNotNull(result);
            Assert.AreEqual(1, result.Id);
            Assert.AreEqual("Torkad lavendel", result.Title);
            Assert.AreEqual("Luktar gott", result.Description);
            Assert.AreEqual("Förgyll ditt hem med en harmonisk doft av lavendel från Frankrike", result.LongDescription);
            Assert.AreEqual("http://image.com/example1.png", result.ImagePath);
            Assert.AreEqual(70, result.Length);
            Assert.AreEqual(120, result.Weight);
            Assert.IsNotNull(result.Variants);
            Assert.AreEqual(2, result.Variants.Count);
            Assert.AreEqual(1, result.Variants[0].Id);
            Assert.AreEqual("Bukett", result.Variants[0].Name);
            Assert.AreEqual(295, result.Variants[0].Price);
            Assert.AreEqual(2, result.Variants[1].Id);
            Assert.AreEqual("Halvbukett", result.Variants[1].Name);
            Assert.AreEqual(198, result.Variants[1].Price);
        }

        private static void AssertSecondFlowerProduct(FlowerProduct? result)
        {
            Assert.IsNotNull(result);
            Assert.AreEqual(2, result.Id);
            Assert.AreEqual("Skäggvete", result.Title);
            Assert.AreEqual("Torkad skäggvete med mörka toppar.", result.Description);
            Assert.AreEqual("Passar utmärkt att arrangera i en smal urna för ett lantligt och naturligt intryck.", result.LongDescription);
            Assert.AreEqual("http://image.com/example2.png", result.ImagePath);
            Assert.AreEqual(68, result.Length);
            Assert.AreEqual(155, result.Weight);
            Assert.IsNotNull(result.Variants);
            Assert.AreEqual(2, result.Variants.Count);
            Assert.AreEqual(3, result.Variants[0].Id);
            Assert.AreEqual("Bukett", result.Variants[0].Name);
            Assert.AreEqual(249, result.Variants[0].Price);
            Assert.AreEqual(4, result.Variants[1].Id);
            Assert.AreEqual("Bunt", result.Variants[1].Name);
            Assert.AreEqual(79, result.Variants[1].Price);
        }
    }
}