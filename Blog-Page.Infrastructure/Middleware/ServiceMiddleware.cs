using Blog_Page.Persistance.Context;
using Blog_Page.Service.Api.Abstract;
using Blog_Page.Service.Api.Concrete;
using Blog_Page.Service.Application.Abstract;
using Blog_Page.Service.Application.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Blog_Page.Infrastructure.Middleware
{
    public class ServiceMiddleware
    {
        public static IServiceProvider serviceProvider { get; set; }
        public static IServiceCollection services{ get; set; }

        public static T GetService<T>()  where T : notnull //DI Bağımlılıkların düzenlenmesi için kullanılır.
        {
            return serviceProvider.GetRequiredService<T>();
        }

        public static void RegisterServices()
        {
            services = new ServiceCollection();
            services.AddDbContext<BlogContext>(opt =>
            {
                opt.UseSqlServer("Server=.\\SQLEXPRESS;Database=BlogDb;Trusted_Connection=True;TrustServerCertificate=True");
            });
            services.AddScoped(typeof(IApiService<>), typeof(ApiService<>));
            services.AddScoped(typeof(IApplicationService<>), typeof(ApplicationService<>));

            serviceProvider = services.BuildServiceProvider();
        }

        public static void RegisterServices(IServiceCollection services)
        {
            services = new ServiceCollection();
            services.AddDbContext<BlogContext>(opt =>
            {
                opt.UseSqlServer("Server=.\\SQLEXPRESS;Database=BlogDb;Trusted_Connection=True;TrustServerCertificate=True");
            });
            services.AddScoped(typeof(IApiService<>), typeof(ApiService<>));
            services.AddScoped(typeof(IApplicationService<>), typeof(ApplicationService<>));

            serviceProvider = services.BuildServiceProvider();
        }

    }
}
