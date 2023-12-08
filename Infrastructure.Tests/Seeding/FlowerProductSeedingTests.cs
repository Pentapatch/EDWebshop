using EDWebshop.Data.Context;
using EDWebshop.Data.Seeding;
using Microsoft.EntityFrameworkCore;

namespace EDWebshop.Data.Tests.Seeding
{
    [TestClass]
    public class FlowerProductSeedingTests
    {
        [TestMethod]
        public async Task Seed_Should_Not_Duplicate_Data_If_Already_Seeded()
        {
            // Arrange
            var options = new DbContextOptionsBuilder<DataContext>()
                .UseInMemoryDatabase(databaseName: "Seed_Should_Not_Duplicate_Data_If_Already_Seeded")
                .Options;

            using var context = new DataContext(options);
            var seeder = new FlowerProductSeeder(context);

            // Seed data initially
            await seeder.Seed();

            var initialCount = await context.Products.CountAsync();

            // Act: Try to seed again
            await seeder.Seed();

            // Assert
            var productCount = await context.Products.CountAsync();
            Assert.AreEqual(initialCount, productCount);
        }

        [TestMethod]
        public async Task Seed_Should_Seed_Data_If_Not_Already_Seeded()
        {
            // Arrange
            var options = new DbContextOptionsBuilder<DataContext>()
                .UseInMemoryDatabase(databaseName: "Seed_Should_Seed_Data_If_Not_Already_Seeded")
                .Options;

            using var context = new DataContext(options);
            var seeder = new FlowerProductSeeder(context);

            var initialCount = await context.Products.CountAsync();

            // Act: Seed data
            await seeder.Seed();

            // Assert: Verify that the product count is as expected
            var productCount = await context.Products.CountAsync();
            Assert.AreNotEqual(initialCount, productCount);
        }
    }
}