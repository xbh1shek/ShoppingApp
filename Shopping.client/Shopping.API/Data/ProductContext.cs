using MongoDB.Driver;
using Shopping.API.Models;

namespace Shopping.API.Data
{
    public class ProductContext
    {
        public ProductContext(IConfiguration configuration)
        {
            var client = new MongoClient(configuration["DatabaseSettings:ConnectionString"]);
            var database = client.GetDatabase(configuration["DatabaseSettings:DatabaseName"]);

            Products = database.GetCollection<Product>(configuration["DatabaseSettings:CollectionName"]);
            SeedData(Products);
        }

        public IMongoCollection<Product> Products { get; }

        private static void SeedData(IMongoCollection<Product> productCollection)
        {
            bool existProduct = productCollection.Find(p => true).Any();
            if (!existProduct)
            {
                productCollection.InsertMany(GetPreconfiguredProducts());
            }
        }

        private static IEnumerable<Product> GetPreconfiguredProducts()
        {
            return new List<Product>()
            {
                new Product()
                {
                    Name = "Lightsaber",
                    Description = "A rare plasma blade powered by kyber crystals and capable of cutting through almost anything.",
                    ImageFile = "product-1.png",
                    Price = 950.00M,
                    Category = "Sword"
                },
                new Product()
                {
                    Name = "Omnitrix",
                    Description = "A master-class in alien DNA rewriting unlimited species, real-time transformation, cosmic-level biotech on your wrist.",
                    ImageFile = "product-2.png",
                    Price = 840.00M,
                    Category = "Watch"
                },
                new Product()
                {
                    Name = "Mjölnir",
                    Description = "Enchanted Uru hammer—channels lightning, flies on command, and only bows to the worthy.",
                    ImageFile = "product-3.png",
                    Price = 650.00M,
                    Category = "Hammer"
                },
                new Product()
                {
                    Name = "Blacksaber",
                    Description = "Ancient Mandalorian blade—black plasma, lightsaber tech, symbol of power, forged to rule.",
                    ImageFile = "product-4.png",
                    Price = 470.00M,
                    Category = "Sword"
                },
                new Product()
                {
                    Name = "The One Ring",
                    Description = "Forged by darkness, grants invisibility and dominion—seductive, cursed, and bound to corrupt all who wear it.",
                    ImageFile = "product-5.png",
                    Price = 380.00M,
                    Category = "Ring"
                },
                new Product()
                {
                    Name = "Elixir",
                    Description = "Liquid legend—one drop heals, revives, or grants power beyond mortal limits; bottled magic, priceless in the right hands.",
                    ImageFile = "product-6.png",
                    Price = 240.00M,
                    Category = "Portion"
                }
            };
        }
    }
}