using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BLL;
using DAL;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace WebApplication
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });

            services.AddSession();

            //Ajout Restaurants
            services.AddScoped<IRestaurantManager, RestaurantManager>();
            services.AddScoped<IRestaurantDB, RestaurantDB>();

            //Ajouts City
            services.AddScoped<ICityManager, CityManager>();
            services.AddScoped<ICityDB, CityDB>();

            //Ajouts Customer
            services.AddScoped<ICustomerManager, CustomerManager>();
            services.AddScoped<ICustomerDB, CustomerDB>();

            //Ajouts Deliveryman
            services.AddScoped<IDeliverymanManager, DeliverymanManager>();
            services.AddScoped<IDeliverymanDB, DeliverymanDB>();

            //Ajout Delivery
            services.AddScoped<IDeliveryManager, DeliveryManager>();
            services.AddScoped<IDeliveryDB, DeliveryDB>();

            //Ajout Dish
            services.AddScoped<IDishManager, DishManager>();
            services.AddScoped<IDishDB, DishDB>();

            //Ajout Order
            services.AddScoped<IOrderManager, OrderManager>();
            services.AddScoped<IOrderDB, OrderDB>();

            //Ajout Order_Dish
            services.AddScoped<IOrder_DishManager, Order_DishManager>();
            services.AddScoped<IOrder_DishDB, Order_DishDB>();

            //Ajout DeliveryTime
            services.AddScoped<IDelivery_TimeManager, Delivery_TimeManager>();
            services.AddScoped<IDelivery_TimeDB, Delivery_TimeDB>();


            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseCookiePolicy();
            app.UseSession();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
