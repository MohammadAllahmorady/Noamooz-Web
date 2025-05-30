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
                context.Categories.Add(new Category { Name = "لباس" });
                context.SaveChanges();
            }

            if (!context.Products.Any())
            {
                context.Products.AddRange(
                   new Product
                   {
                       Name = "توپ تنیس",
                       CategoryId = 1,
                       Description = "ساخت ژاپن",
                       Price = 100000,

                   },
                    new Product
                    {
                        Name = "توپ والیبال",
                        CategoryId = 1,
                        Description = "ساخت ایتالیا",
                        Price = 200000,

                    },
                    new Product
                    {
                        Name = "توپ فوتبال",
                        CategoryId = 1,
                        Description = "ساخت ایران",
                        Price = 30000,

                    },
                    new Product
                    {
                        Name = "توپ بسکتبال",
                        CategoryId = 1,
                        Description = "ساخت امریکا",
                        Price = 400000,

                    },
                    new Product
                    {
                        Name = "توپ پینگ پونگ",
                        CategoryId = 1,
                        Description = "ساخت چین",
                        Price = 500000,

                    }
                    ,
                    new Product
                    {
                        Name = "توپ بدمینتون",
                        CategoryId = 1,
                        Description = "ساخت چین",
                        Price = 600000,

                    }
                    ,
                    new Product
                    {
                        Name = "توپ راگبی",
                        CategoryId = 1,
                        Description = "ساخت چین",
                        Price = 700000,

                    }
                    ,
                    new Product
                    {
                        Name = "توپ گلف",
                        CategoryId = 1,
                        Description = "ساخت چین",
                        Price = 800000,

                    }
                    ,
                    new Product
                    {
                        Name = "توپ هندبال",
                        CategoryId = 1,
                        Description = "ساخت ایران",
                        Price = 900000,

                    }
                    ,
                    new Product
                    {
                        Name = "توپ هاکی",
                        CategoryId = 1,
                        Description = "ساخت ایران",
                        Price = 1000000,

                    }
                    ,
                    new Product
                    {
                        Name = "توپ بولینگ",
                        CategoryId = 1,
                        Description = "ساخت ایران",
                        Price = 1100000,

                    }
                    ,
                    new Product
                    {
                        Name = "توپ واترپلو",
                        CategoryId = 1,
                        Description = "ساخت امریکا",
                        Price = 1200000,

                    }
                    ,
                    new Product
                    {
                        Name = "توپ فوتسال",
                        CategoryId = 1,
                        Description = "ساخت امریکا",
                        Price = 1300000,

                    }
                    ,
                    new Product
                    {
                        Name = "توپ اسکواش",
                        CategoryId = 1,
                        Description = "ساخت امریکا",
                        Price = 1400000,

                    }
                    ,
                    new Product
                    {
                        Name = "توپ بیس بال",
                        CategoryId = 1,
                        Description = "ساخت ایتالیا",
                        Price = 1500000,

                    }
                    ,
                    new Product
                    {
                        Name = "توپ کریکت",
                        CategoryId = 1,
                        Description = "ساخت ایتالیا",
                        Price = 1500000,

                    }
                    ,
                    new Product
                    {
                        Name = "توپ چوگان",
                        CategoryId = 1,
                        Description = "ساخت ایتالیا",
                        Price = 1500000,

                    }
                    ,
                    new Product
                    {
                        Name = "توپ گلبال",
                        CategoryId = 1,
                        Description = "ساخت ژاپن",
                        Price = 1400000,

                    }
                    ,
                    new Product
                    {
                        Name = "توپ پینگ پونگ",
                        CategoryId = 1,
                        Description = "ساخت ژاپن",
                        Price = 100000,

                    }
                    ,
                    new Product
                    {
                        Name = "توپ فیلدبال",
                        CategoryId = 1,
                        Description = "ساخت ژاپن",
                        Price = 1400000,

                    }
                    ,
                    new Product
                    {
                        Name = "توپ پینگ پونگ",
                        CategoryId = 1,
                        Description = "ساخت چین",
                        Price = 1400000,

                    }
                    ,
                    new Product
                    {
                        Name = "توپ پتانک",
                        CategoryId = 1,
                        Description = "ساخت چین",
                        Price = 1300000,


                    }
                    ,
                    new Product
                    {
                        Name = "توپ بیلیارد",
                        CategoryId = 1,
                        Description = "ساخت چین",
                        Price = 1300000,

                    },
                    new Product
                    {
                        Name = "لباس تیم ملی آرژانتین",
                        CategoryId = 2,
                        Description = "ساخت چین",
                        Price = 1300000,

                    },
                    new Product
                    {
                        Name = "لباس تیم ملی برزیل",
                        CategoryId = 2,
                        Description = "ساخت چین",
                        Price = 1300000,

                    },
                    new Product
                    {
                        Name = "لباس تیم ملی ایران",
                        CategoryId = 2,
                        Description = "ساخت چین",
                        Price = 1300000,

                    },
                    new Product
                    {
                        Name = "لباس تیم ملی هلند",
                        CategoryId = 2,
                        Description = "ساخت چین",
                        Price = 1300000,

                    },
                    new Product
                    {
                        Name = "لباس تیم ملی ایتالیا",
                        CategoryId = 2,
                        Description = "ساخت چین",
                        Price = 1300000,

                    },
                    new Product
                    {
                        Name = "لباس تیم ملی آلمان",
                        CategoryId = 2,
                        Description = "ساخت چین",
                        Price = 1300000,

                    }
                );
                context.SaveChanges();
            }
        }
    }
}