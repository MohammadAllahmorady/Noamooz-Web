using Microsoft.Extensions.DependencyInjection;
using Noamooz.Core.Models;
using System.Linq;

namespace Noamooz.Data.Models
{
    public static class SeedData
    {
        public static void CreateData(IServiceProvider serviceProvider)
        {
            using var scope = serviceProvider.CreateScope();
            var context = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();

            if (!context.Categories.Any())
            {
                context.Categories.Add(new Category { Name = "توپ" });
                context.SaveChanges();
            }

            if (!context.Products.Any())
            {
                context.Products.AddRange(
                    new Product { Name = "توپ تنیس", CategoryId = 1, Description = "ساخت ژاپن", Price = 10000 },
                    new Product { Name = "توپ والیبال", CategoryId = 1, Description = "ساخت انگلیس", Price = 100000 },
                    new Product { Name = "توپ فوتبال", CategoryId = 1, Description = "ساخت ایران", Price = 20000 },
                    new Product { Name = "توپ بیس بال", CategoryId = 1, Description = "ساخت ژاپن", Price = 32000 }
                );
                context.SaveChanges();
            }
        }
    }
}