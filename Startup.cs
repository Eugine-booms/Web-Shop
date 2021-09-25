using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using WebShop.Data;
using WebShop.Data.Interfaces;
using WebShop.Data.Mocks;
using WebShop.Data.Models;
using WebShop.Data.Repository;

namespace Web_Shop
{
    public class Startup
    {
        private IConfigurationRoot _confstring;

        public Startup(IHostingEnvironment hostEnv)
        {
            _confstring =new ConfigurationBuilder().SetBasePath(hostEnv.ContentRootPath).AddJsonFile("dbsettings.json").Build();
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<ShopDbContext>(options => options.UseSqlServer(_confstring.GetConnectionString("DefaultConnection")));
            services.AddTransient<IGetCars, CarRepository>();
            services.AddTransient<ICarsCategory, CategoryRepositiry>();
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddScoped(sp => ShopCart.GetCart(sp));

            services.AddMvc();
            services.AddMemoryCache();
            services.AddSession();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.UseDeveloperExceptionPage();
            app.UseStatusCodePages();
            app.UseStaticFiles();
            app.UseSession();
            app.UseMvcWithDefaultRoute();
            ShopDbContext context;
            using (var scop = app.ApplicationServices.CreateScope())
            {
                context = scop.ServiceProvider.GetRequiredService<ShopDbContext>();
                DbObjects.Initial(context);
            }
            
        }
    }
}
