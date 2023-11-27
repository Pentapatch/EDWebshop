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
               Id = 1,
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

        //[TestMethod]
        //public async Task Create_Async_Should_Add_New_Product_To_Database()
        //{
        //    // Arrange
        //    var options = new DbContextOptionsBuilder<DataContext>()
        //        .UseInMemoryDatabase(databaseName: "Create_Async_Should_Add_New_Product_To_Database")
        //        .Options;

        //    var product = new FlowerProduct
        //    {
        //        Title = "Röda rosor",
        //        Description = "Vackra röda rosor.",
        //        LongDescription = "Vackra röda rosor som passar perfekt året om.",
        //        ImagePath = "https://blombruket.se/wp-content/uploads/2023/08/torkat-bukett-skordefest-1560-1221x1536.jpg.webp",
        //        Length = 55,
        //        Weight = 10,
        //        Variants =
        //        [
        //            new ProductVariant
        //            {
        //                Name = "Bukett",
        //                Price = 300,
        //            },
        //            new ProductVariant
        //            {
        //                Name = "Halvbukett",
        //                Price = 200,
        //            },
        //            new ProductVariant
        //            {
        //                Name = "Bunt",
        //                Price = 89,
        //            }
        //        ]
        //    };

        //    // Act
        //    using (var context = new DataContext(options))
        //    {
        //        var repository = new Repository(context);
        //        await repository.CreateAsync(product);
        //    }

        //    // Assert
        //    using (var context = new DataContext(options))
        //    {
        //        Assert.AreEqual(1, context.Products.Count());
        //        Assert.AreEqual("Röda rosor", context.Products.Single().Title);
        //    }
        //}


    }
}
