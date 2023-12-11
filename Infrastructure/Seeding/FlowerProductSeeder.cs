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
                    ImagePath = "/products/ulleternell.jpg",
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
                    ImagePath = "/products/helichrysum-aprikos.jpg",
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
                    ImagePath = "/products/achillea.jpg",
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
                    ImagePath = "/products/lagurus.jpg",
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
                    ImagePath = "/products/lin.jpg",
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
                    ImagePath = "/products/trablomma.jpg",
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
                    ImagePath = "/products/kvastgras.jpg",
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
                    ImagePath = "/products/havre.jpg",
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
                },
                new() {
                    Title = "Riddarsporre Vit",
                    Description = "Torkad riddarsporre i naturlig vit färg. Arrangera i en stor urna tillsammans med andra torkade blommor. Välj mellan helbunt eller halvbunt (bilden visar helbunt).",
                    LongDescription = "Underbar torkad riddarsporre i naturlig vit färg. Torkad riddarsporre passar perfekt när du vill inreda med torkade blommor och blir väldigt fin tillsammans med andra torkade sommarblommor i en naturlig torkad bukett. Blanda tillsammans med riddarsporre i andra färger eller komplettera med lagurus och vallmokapsel för att få en vacker och stilren torkad bukett.",
                    ImagePath = "/products/riddarporre.jpg",
                    Length = 70,
                    Weight = 100,
                    Variants =
                    [
                        new ProductVariant
                        {
                            Name = "Helbunt",
                            Price = 295,
                        },
                        new ProductVariant
                        {
                            Name = "Halvbunt",
                            Price = 195,
                        }
                    ]
                },
                new() {
                    Title = "Skäggvete",
                    Description = "Torkad skäggvete med mörka toppar. Passar utmärkt att arrangera i en smal urna för ett lantligt och naturligt intryck. Välj storlek (bilden visar helbunt).",
                    LongDescription = "Torkat vete med långa mörka toppar. Skäggvete blir väldigt fint för sig själva i en smal urna och ger ett härligt lantligt intryck. Passar för dig som vill inreda med torkade blommor i lantlig och naturlig stil.",
                    ImagePath = "/products/skaggvete.jpg",
                    Length = 70,
                    Weight = 230,
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
                    Title = "Kanariegräs",
                    Description = "Kanariegräs med sin dova gröna färg passar utmärkt i en stor urna eller som bas i en torkad bukett. Välj storlek (bilden visar helbunt).",
                    LongDescription = "Kanariegräs, med det latinska namnet Phalaris, är den perfekta basen för en torkad bukett med sin dova gröna färg. Kanariegräs passar också bra att använda i en bukett med färska snittblommor eller för sig själv i en stor urna.",
                    ImagePath = "/products/kanariegras.jpg",
                    Length = 65,
                    Weight = 200,
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
                    Title = "Torkade Mullbär",
                    Description = "Torkade mullbär blir en fin inredningsdetalj i ditt hem och passar för dig som vill ha något naturligt och hållbart i vasen. Arrangera i en vas eller urna, lägg på ett fat eller knyt ett band och häng upp på väggen.",
                    LongDescription = "Torkade pappersmullbär är den perfekta inredningsdetaljen för dig som vill ha något enkelt och hållbart i vasen. Mullbärskvistarna är väldigt tåliga och behåller både färg och form. Arrangera mullbär för sig själva i en vas, knyt ett fint band och häng upp på väggen eller att lägg kvistarna på ett fat eller i en skål.",
                    ImagePath = "/products/mullbar.jpg",
                    Length = 70,
                    Weight = 40,
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
                    Title = "Torkad Färgtistel",
                    Description = "Naturlig torkad färgtistel (Carthamus tinctorius) i en härlig orange färg. Färgtistel är extra fin till hösten, för sig själv eller i en höstbukett. Välj storlek på din bunt (bilden visar helbunt).",
                    LongDescription = "Naturlig torkad färgtistel (Carthamus). En riktig favorit tack vare den härliga oranga färgen som annars kan vara svår att hitta bland torkade blommor. Perfekt för dig som vill ha torkade blommor med mycket volym och blir extra fint att arrangera i helbunt i en stor urna. Färgtistel är egentligen en ört som har odlats som färgväxt sedan antiken. Den rödgula tisteln ger färg till matlagningen och såldes förr som ”saffranpistiller”.",
                    ImagePath = "/products/fargtistel.jpg",
                    Length = 60,
                    Weight = 150,
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
                    Title = "Torkad Nigella Frökapsel",
                    Description = "Nigella är en vacker ängsblomma passar perfekt tillsammans med andra blommor i en torkad bukett. Komplettera med exempelvis helichrysum och vete. Välj storlek (bilden visar helbunt).",
                    LongDescription = "Nigella, eller ”jungfrun i det gröna” som den heter på svenska, är en riktigt favorit bland våra torkade blommor. Nigella passar för dig som vill inreda med torkade blommor och fånga den där ängslika och vilda känslan i en torkad bukett. Kombinera med exempelvis vallmokapsel och kanariegräs.",
                    ImagePath = "/products/nigella-frokapsel.jpg",
                    Length = 0,
                    Weight = 0,
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
                    Title = "Helichrysum Cerise",
                    Description = "Torkad Helichrysum är en av våra mest klassiska eterneller som finns i många härliga färger. Blomman har många användningsområden och är lika fin i en torkad bukett som för sig själv i en vas.",
                    LongDescription = "Helichrysum är en av de mest klassiska blommorna att torka och är den blomma som många förknippar med ordet eternell. Att den är så populär beror troligtvis på sin skira papperslika kvalitet och att den finns i många härliga färger. Här i en ljuvlig cerise variant! Helichrysum går att använda till mycket. Arrangera i en vas för sig själv eller i en torkad bukett. Häng i påskriset eller julgranen. Använd som dekoration i gamla fönster eller stick i blomsterkransen.",
                    ImagePath = "/products/helichrysum.jpg",
                    Length = 55,
                    Weight = 70,
                    Variants =
                    [
                        new ProductVariant
                        {
                            Name = "Helbunt",
                            Price = 265,
                        }
                    ]
                },
                new() {
                    Title = "Helichrysum Vit",
                    Description = "Torkad Helichrysum är en av våra mest klassiska eterneller som finns i många härliga färger. Blomman har många användningsområden och är lika fin i en torkad bukett som för sig själv i en vas.",
                    LongDescription = "Helichrysum är en av de mest klassiska blommorna att torka och är den blomma som många förknippar med ordet eternell. Att den är så populär beror troligtvis på sin skira papperslika kvalitet och att den finns i många härliga färger. Här i en underbar cremevit ton! Helichrysum går att använda till mycket. Arrangera i en vas för sig själv eller i en torkad bukett. Häng i påskriset eller julgranen. Använd som dekoration i gamla fönster eller stick i blomsterkransen.",
                    ImagePath = "/products/helichrysum-vit.jpg",
                    Length = 55,
                    Weight = 70,
                    Variants =
                    [
                        new ProductVariant
                        {
                            Name = "Helbunt",
                            Price = 265,
                        }
                    ]
                }
            };
    }
}