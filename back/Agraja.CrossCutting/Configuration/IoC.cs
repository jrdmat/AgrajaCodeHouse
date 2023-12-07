
using Agraja.Application.Contracts.Services;
using Agraja.Application.Services;
using Agraja.Infrastructure;
using Agraja.Infrastructure.Contracts;
using Agraja.Infrastructure.Repositories;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agraja.CrossCutting.Configuration
{
    public static class IoC
    {
        public static IServiceCollection Register(this IServiceCollection services)
        {
            AddRepositories(services);
            AddServices(services);
            AddDbContext(services);

            return services;
        }

        public static IServiceCollection AddDbContext(IServiceCollection services)
        {
            //Conexión a dbcontext
            services.AddTransient<AgrajaDbContext>();

            return services;
        }

        public static IServiceCollection AddServices(IServiceCollection services)
        {
            //Conexión a servicios
            services.AddTransient<IBoxService, BoxService>();
            services.AddTransient<IAgroService, AgroService>();
            services.AddTransient<IProductService, ProductService>();
            services.AddTransient<IUserService, UserService>();
            services.AddTransient<IAgroxProductService, AgroxProductService>();
            services.AddTransient<IBoxxProductService, BoxxProductService>();
            services.AddTransient<IPaymentTypeService, PaymentTypeService>();

            return services;
        }

        public static IServiceCollection AddRepositories(IServiceCollection services)
        {
            //Conexion a repositorios
            services.AddTransient<IAgroRepository, AgroRepository>();
            services.AddTransient<IBoxRepository, BoxRepository>();
            services.AddTransient<IProductRepository, ProductRepository>();
            services.AddTransient<IUserRepository, UserRepository>();
            services.AddTransient<IAgroxProductRepository, AgroxProductRepository>();
            services.AddTransient<IBoxxProductRepository, BoxxProductRepository>();
            services.AddTransient<IPaymentTypeRepository, PaymentTypeRepository>();

            return services;

        }
    }
}
