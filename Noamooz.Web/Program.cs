using Microsoft.AspNetCore.Identity;
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


            // Identity بخش مربوط به
            builder.Services.AddDbContext<AppIdentityDbContext>(option =>
                option.UseSqlServer(builder.Configuration.GetConnectionString("IdentityConnection")));


            builder.Services.AddIdentity<IdentityUser, IdentityRole>(options =>
            {
                options.Password.RequiredLength = 5;
                options.Password.RequireNonAlphanumeric =
                    false; //این بعنی از کارکتر های ویژه نیازی نیست در پسورد استفاده کرد
                options.Password.RequireDigit = false; //این یعنی عدد هم نیازی نیست در پسورد
                options.Password.RequireUppercase = false;
            }).AddEntityFrameworkStores<AppIdentityDbContext>().AddDefaultTokenProviders();
            //Identity  پایان

            builder.Services.AddTransient<IProductRepository,ProductRepository>();

            // Add services to the container.
            builder.Services.AddControllersWithViews();


            builder.Services.AddMemoryCache();
            builder.Services.AddSession();

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

            app.UseSession();

            app.UseRouting();

            app.UseAuthentication();
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
