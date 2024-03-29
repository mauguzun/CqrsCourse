using ApplicationServices.Implementation;
using ApplicationServices.Interfaces;
using AutoMapper;
using Castle.DynamicProxy;
using DataAccess.MsSql;
using Infrastructure.Interfaces;
using Layers.ApplicationServices.Implementation;
using Layers.ApplicationServices.Implementation.Order;
using Layers.ApplicationServices.Interfaces;
using Layers.ApplicationServices.Interfaces.Product;
using Layers.WebApi;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using WebApi.Services;

namespace WebApi
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
            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "WebApi", Version = "v1" });
            });

            services.AddScoped<IOrderService>(serviceProvider =>
            {
                var serice = serviceProvider.GetRequiredService<OrderService>();
                var inter = serviceProvider.GetRequiredService<CheckOrderAsynInterceptor>();

                var proxy = new ProxyGenerator();

                var result = proxy.CreateInterfaceProxyWithTargetInterface<IOrderService>(serice, inter);

                return result;
            });


            #region interceptor
            //services.AddScoped<OrderService>();
            //services.AddScoped<CheckOrderAsynInterceptor>();

            //services.AddScoped<ReadOnlyOrderService>();

            //services.AddScoped<IReadOnlyOrderService>(serviceProvider =>
            //{
            //    var serice = serviceProvider.GetRequiredService<ReadOnlyOrderService>();
            //    var inter = serviceProvider.GetRequiredService<CheckOrderAsynInterceptor>();

            //    var proxy = new ProxyGenerator();

            //    var result = proxy.CreateInterfaceProxyWithTargetInterface<IReadOnlyOrderService>(serice, inter);

            //    return result;
            //});
            #endregion

            services.AddScoped<IOrderService, OrderService>();
            services.AddScoped<IReadOnlyOrderService, ReadOnlyOrderService>();

            services.AddScoped<IProductService, ProductService>();
            services.AddScoped<IReadOnlyProductService, ReadOnlyProductService>();

            services.AddScoped<IStatisticService, StatisticService>();

            services.AddAutoMapper(typeof(MapperProfile));
            services.AddDbContext<IDbContext, AppDbContext>(builder =>
                builder.UseSqlServer(Configuration.GetConnectionString("Database")));
            services.AddDbContext<IReadOnlyDbContext, ReadOnlyAppDbContext>(builder =>
                builder.UseSqlServer(Configuration.GetConnectionString("Database")));
            services.AddScoped<ICurrentUserService, CurrentUserService>();

            services.AddScoped<CheckOrderFilterAttribute>();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "WebApi v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
