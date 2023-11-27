using Entity.Entities;
using Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Seeding
{
    public class FlowerProductSeeder(DataContext context) : IDataSeeder
    {
        private readonly DataContext _context = context;

        public async Task Seed()
        {
            if (await _context.Products.AnyAsync())
            {
                return;
            }

            var products = new List<FlowerProduct>
            {
                new() {
                    Title = "Röda rosor",
                    Description = "Vackra röda rosor.",
                    LongDescription = "Vackra röda rosor som passar perfekt året om.",
                    ImagePath = "https://blombruket.se/wp-content/uploads/2023/08/torkat-bukett-skordefest-1560-1221x1536.jpg.webp",
                    Length = 55,
                    Weight = 10,
                    Variants =
                    [
                        new ProductVariant
                        {
                            Name = "Bukett",
                            Price = 300,
                        },
                        new ProductVariant
                        {
                            Name = "Halvbukett",
                            Price = 200,
                        },
                        new ProductVariant
                        {
                            Name = "Bunt",
                            Price = 89,
                        }
                    ]
                },
                new() {
                    Title = "Torkat sortiment",
                    Description = "Vacker blandning av torkade blommor och växter.",
                    LongDescription = "Vacker blandning av torkade blommor och växter som står sig länge.",
                    ImagePath = "https://blombruket.se/wp-content/uploads/2023/08/torkat-bukett-skordefest-1560-1221x1536.jpg.webp",
                    Length = 45,
                    Weight = 5,
                    Variants =
                    [
                        new ProductVariant
                        {
                            Name = "Bukett",
                            Price = 295,
                        },
                        new ProductVariant
                        {
                            Name = "Halvbukett",
                            Price = 199,
                        }
                    ]
                }
            };

            _context.Products.AddRange(products);
            await _context.SaveChangesAsync();
        }
    }
}