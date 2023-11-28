using Entity.Entities;
using Infrastructure.Context;
using Infrastructure.Repositories;
using Moq;
using Moq.EntityFrameworkCore;

namespace Infrastructure.Tests.Repositories
{
    [TestClass]
    public class RepositoryTests
    {
        private readonly Repository<FlowerProduct, DataContext> _sut;
        private readonly Mock<DataContext> _dbContextMock;
        private readonly List<FlowerProduct> _fakeFlowerProductList;

        public RepositoryTests()
        {
            _fakeFlowerProductList = GetFakeFlowerProductList();

            _dbContextMock = new Mock<DataContext>();
            _dbContextMock.Setup(x => x.Set<FlowerProduct>()).ReturnsDbSet(_fakeFlowerProductList);
            _dbContextMock.Setup(x => x.Products).ReturnsDbSet(_fakeFlowerProductList);

            _sut = new Repository<FlowerProduct, DataContext>(_dbContextMock.Object);
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
               Length = 10,
               Weight = 10,
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
                           Name = "Halvbukett",
                           Price = 198,
                      }
                  ]
           }
        };

        [TestMethod]
        public async Task AddAsync_Should_Add_An_Item_To_The_Database()
        {
            // Arrange
            var flowerProduct = new FlowerProduct
            {
                Title = "Torkad brudslöja"
            };

            // Act
            await _sut.CreateAsync(flowerProduct);

            // Assert
            _dbContextMock.Verify(x => x.Set<FlowerProduct>().AddAsync(flowerProduct, default), Times.Once);
            _dbContextMock.Verify(x => x.SaveChangesAsync(default), Times.Once);
        }

        [TestMethod]
        public async Task GetAllAsync_Should_Return_All_Items_From_The_Database()
        {
            // Arrange
            var expected = _fakeFlowerProductList;

            // Act
            var actual = await _sut.GetAllAsync();

            // Assert
            Assert.AreEqual(expected.Count, actual.Count());
            Assert.AreEqual(expected.First().Title, actual.First().Title);
            Assert.AreEqual(expected.Last().Title, actual.Last().Title);
        }

        [TestMethod]
        public async Task GetAsync_Should_Return_An_Item_From_The_Database()
        {
            // Arrange
            var id = 1;
            var expected = _fakeFlowerProductList.First(x => x.Id == id);

            // Act
            var actual = await _sut.GetAsync(id);

            // Assert
            Assert.IsNotNull(actual);
            Assert.AreEqual(expected.Id, actual.Id);
            Assert.AreEqual(expected.Title, actual.Title);
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

        [TestMethod]
        public async Task UpdateAsync_Should_Update_An_Item_In_The_Database()
        {
            // Arrange
            var flowerProduct = _fakeFlowerProductList.First();

            // Act
            await _sut.UpdateAsync(flowerProduct);

            // Assert
            _dbContextMock.Verify(x => x.Set<FlowerProduct>().Update(flowerProduct), Times.Once);
            _dbContextMock.Verify(x => x.SaveChangesAsync(default), Times.Once);
        }

        [TestMethod]
        public async Task DeleteAsync_Should_Delete_An_Item_From_The_Database()
        {
            // Arrange
            var flowerProduct = _fakeFlowerProductList.First();

            // Act
            await _sut.DeleteAsync(flowerProduct);

            // Assert
            _dbContextMock.Verify(x => x.Set<FlowerProduct>().Remove(flowerProduct), Times.Once);
            _dbContextMock.Verify(x => x.SaveChangesAsync(default), Times.Once);
        }

    }
}
