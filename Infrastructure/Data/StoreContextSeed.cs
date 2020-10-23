using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using Core.Entities;
using Microsoft.Extensions.Logging;

namespace Infrastructure.Data {
    public class StoreContextSeed {
        public static async Task SeedAsync(StoreContext context, ILoggerFactory loggerFactory) {
            try {
                if (!context.ProductBrands.Any()) {
                    var brandsData = File.ReadAllText("../Infrastructure/Data/SeedData/brands.json");
                    var brands = JsonSerializer.Deserialize<List<ProductBrand>>(brandsData);
                    foreach (var item in brands) {
                        context.ProductBrands.Add(item);
                    }
                    await context.SaveChangesAsync();
                }

                if (!context.ProductType.Any()) {
                    var typesData = File.ReadAllText("../Infrastructure/Data/SeedData/types.json");
                    var types = JsonSerializer.Deserialize<List<ProductType>>(typesData);
                    foreach (var item in types) {
                        context.ProductType.Add(item);
                    }
                    await context.SaveChangesAsync();
                }

                if (!context.Products.Any()) {
                    var productz = File.ReadAllText("../Infrastructure/Data/SeedData/products.json");
                    var prodz = JsonSerializer.Deserialize<List<Product>>(productz);
                    foreach (var item in prodz) {
                        context.Products.Add(item);
                    }
                    await context.SaveChangesAsync();
                }
            } catch (Exception ex) {
                var logga = loggerFactory.CreateLogger<StoreContextSeed>();
                logga.LogError(ex.Message);
            }
        }
    }
}