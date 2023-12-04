using EDWebshop.Contracts.Entities;
using EDWebshop.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace EDWebshop.Data.Seeding
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

            var products = GetFlowerProducts();

            _context.Products.AddRange(products);
            await _context.SaveChangesAsync();
        }

        private static List<FlowerProduct> GetFlowerProducts() => new()
            {
                new() {
                    Title = "Ulleternell",
                    Description = "Ulleterneller är helt ljuvliga med sina vita ulliga blommor. Fina att hänga upp och ner i en bunt men passar också bra till pyssel. Välj hel eller halvbunt (bilden visar helbunt).",
                    LongDescription = "Ulleterneller är helt ljuvliga med sina vita ulliga blommor. Ulleterneller passar väldigt bra att hänga upp och ner i en bunt med ett fint band, men passar även bra till pyssel och dekoration med torkade blommor. Rensa stjälkarna från blad för mer elegans, eller behåll bladen för ett mer rustik intryck.",
                    ImagePath = "https://blombruket.se/wp-content/uploads/2023/11/Torkat-ulleternell-1560-1221x1536.jpg.webp",
                    Length = 50,
                    Weight = 70,
                    Variants =
                    [
                        new ProductVariant
                        {
                            Name = "Helbunt",
                            Price = 265,
                        },
                        new ProductVariant
                        {
                            Name = "Halvbunt",
                            Price = 165,
                        }
                    ]
                },
                new() {
                    Title = "Helichrysum Aprikos",
                    Description = "Torkad Helichrysum är en av våra mest klassiska eterneller som finns i många härliga färger. Blomman har många användningsområden och är lika fin i en torkad bukett som för sig själv i en vas.",
                    LongDescription = "Helichrysum är en av de mest klassiska blommorna att torka och är den blomma som många förknippar med ordet eternell. Att den är så populär beror troligtvis på sin skira papperslika kvalitet och att den finns i många härliga färger. Här i härliga aprikosa toner! Helichrysum går att använda till mycket. Arrangera i en vas för sig själv eller i en torkad bukett. Häng i påskriset eller julgranen. Använd som dekoration i gamla fönster eller stick i blomsterkransen.",
                    ImagePath = "https://blombruket.se/wp-content/uploads/2023/11/torkat-helichrysum-aprikos-1560-1221x1536.jpg.webp",
                    Length = 55,
                    Weight = 70,
                    Variants =
                    [
                        new ProductVariant
                        {
                            Name = "Bukett",
                            Price = 265,
                        }
                    ]
                },
                new() {
                    Title = "Torkad Achillea",
                    Description = "Torkad Achillea med sin dova gula färg för tankarna till svensk sommar. En trendig och naturlig inredningsdetalj som passar bra tillsammans med andra blommor i en torkad bukett. Välj storlek (bilden visar helbunt).",
                    LongDescription = "Torkad Achillea är en gul härlig blomma som för tankarna till svensk sommar. En trendig och naturlig inredningsdetalj som passar i alla hem. Achillea är fin att arrangera i en större bunt eller tillammans med andra torkade blommor i en torkad bukett. Tips på andra sorter som passar tillsammans med Lona är till exempel vit riddarsporre, vallmokapsel och havre.",
                    ImagePath = "https://blombruket.se/wp-content/uploads/2023/11/torkat-achillea-1560-625x800.jpg.webp",
                    Length = 55,
                    Weight = 100,
                    Variants =
                    [
                        new ProductVariant
                        {
                            Name = "Helbunt",
                            Price = 245,
                        },
                        new ProductVariant
                        {
                            Name = "Halvbunt",
                            Price = 145,
                        }
                    ]
                },
                new() {
                    Title = "Torkad Lagurus",
                    Description = "Naturlig torkad lagurus (harsvans) av högsta kvalitet. Ett torkat gräs som passar i alla hem. Arrangera för sig själv eller tillsammans med andra torkade blommor. Välj storlek (bilden visar helbunt).",
                    LongDescription = "Torkad lagurus, eller harsvans (hartass) som gräset även kallas, är en av våra mest populära torkade produkter och kanske även den som mest vanlig att inreda med. Lagurus går att använda till mycket och passar väldigt bra att arrangera tillsammans med andra gräs eller sädesslag, som till exempel havre.",
                    ImagePath = "https://blombruket.se/wp-content/uploads/2021/03/torkat-lagurus-1560-625x800.jpg.webp",
                    Length = 60,
                    Weight = 100,
                    Variants =
                    [
                        new ProductVariant
                        {
                            Name = "Helbunt",
                            Price = 245,
                        },
                        new ProductVariant
                        {
                            Name = "Halvbunt",
                            Price = 145,
                        }
                    ]
                },
                new() {
                    Title = "Torkat Lin",
                    Description = "Torkat Lin passar utmärk för sig självt i en urna eller att hänga på väggen för ett lantligt och naturligt intryck. Lin passar även bra till pyssel med torkade blommor.",
                    LongDescription = "Torkat lin passar dig som vill inreda med en naturlig och lantlig allmogestil och funkar lika bra i sommarstugan som till jul. Lin gör sig bäst för sig själv i en vas eller att hänga upp och ner på väggen. Tack vare de starka stjälkarna passar Lin också bra till pyssel och DIY med torkade blommor, kanske en krans av torkade blommor eller små knippen i en girlang?",
                    ImagePath = "https://blombruket.se/wp-content/uploads/2023/10/Torkat-Lin-1560-625x800.jpg.webp",
                    Length = 50,
                    Weight = 100,
                    Variants =
                    [
                        new ProductVariant
                        {
                            Name = "Helbunt",
                            Price = 245,
                        }
                    ]
                },
                new() {
                    Title = "Torkade Träblommor",
                    Description = "Torkade träblommor blir en fin inredningsdetalj i ditt hem och passar för dig som vill ha något naturligt och hållbart i vasen. Arrangera i en låg vas eller i en blomsterfakir.",
                    LongDescription = "Torkade träblommor är den perfekta inredningsdetaljen för dig som vill ha något enkelt och hållbart i vasen. Träblommorna som är en fröställning från Protea är väldigt tåliga och behåller både färg och form. Arrangera mullbär för sig själva i en låg eller i en blomsterfakir eller blomgroda. Blommorna passar också bra som dekoration. exempelvis i en krans.",
                    ImagePath = "https://blombruket.se/wp-content/uploads/2023/10/Torkad-trablomma-helbild-1560-625x800.jpg",
                    Length = 35,
                    Weight = 130,
                    Variants =
                    [
                        new ProductVariant
                        {
                            Name = "5 blommor",
                            Price = 145,
                        },
                        new ProductVariant
                        {
                            Name = "10 blommor",
                            Price = 245,
                        }
                    ]
                },
                new() {
                    Title = "Torkat kvastgräs",
                    Description = "Torkat Kvastgräs passar utmärk att hänga på väggen för ett naturligt och svenskt intryck. Kvastgräs passar även bra till pyssel, exempelvis i en torkad krans.",
                    LongDescription = "Torkat kvastgräs passar dig som vill inreda med en naturlig och svensk stil och funkar lika bra i sommarstugan som till jul. Kvastgräs passar bäst att hänga i en bunt eller för att använda till pyssel med torkade blommor. Kanske i en krans eller i en liten bukett på servetten?",
                    ImagePath = "https://blombruket.se/wp-content/uploads/2023/10/Torkat-kvastgras-1560-1221x1536.jpg",
                    Length = 50,
                    Weight = 70,
                    Variants =
                    [
                        new ProductVariant
                        {
                            Name = "Bukett",
                            Price = 245,
                        }
                    ]
                },
                new() {
                    Title = "Torkad Havre",
                    Description = "Torkad havre är ett härligt svenskt sädesslag som passar utmärkt som bas i en torkad bukett. Blanda med exempelvis lagurus för ett mer lyxigt intryck. Välj storlek (bilden visar helbunt).",
                    LongDescription = "Torkad havre är ett härligt svenskt sädesslag som passar utmärkt som bas i en torkad bukett. Blanda med exempelvis torkad lagurus för ett mer lyxigt intryck. Arrangera buketten i en stor vid vas för bästa resultat.",
                    ImagePath = "https://blombruket.se/wp-content/uploads/2023/04/torkat-havre-1560-1221x1536.jpg.webp",
                    Length = 60,
                    Weight = 100,
                    Variants =
                    [
                        new ProductVariant
                        {
                            Name = "Helbunt",
                            Price = 195,
                        },
                        new ProductVariant
                        {
                            Name = "Halvbunt",
                            Price = 125,
                        }
                    ]
                }
            };
    }
}