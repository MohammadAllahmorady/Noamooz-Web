using Microsoft.EntityFrameworkCore;
using Noamooz.Core.Repositories;
using Noamooz.Data.Models;
using Noamooz.Data.Repository;

namespace Noamooz.Web
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            builder.Services.AddDbContext<ApplicationDbContext>(option =>
                option.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
            builder.Services.AddTransient<IProductRepository,ProductRepository>();

            // Add services to the container.
            builder.Services.AddControllersWithViews();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();
            app.MapControllerRoute(
                name: "",
                pattern: "Category{categoryCode:int}/Page{page:int}",
                defaults:new {controller="Product",action="List"});
            app.MapControllerRoute(
                name: "",
                pattern: "Category{categoryCode:int}",
                defaults: new { controller = "Product", action = "List", page=1 });

            app.MapControllerRoute(
                name: "",
                pattern: "Page{page:int}",
                defaults: new { controller = "Product", action = "List",categoryCode =1});

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Product}/{action=List}/{id?}");
            //SeedData.CreateData(app);
            using (var scope = app.Services.CreateScope())
            {
                var serviceProvider = scope.ServiceProvider;
                SeedData.CreateData(serviceProvider);
            }
            app.Run();
        }
    }
}
