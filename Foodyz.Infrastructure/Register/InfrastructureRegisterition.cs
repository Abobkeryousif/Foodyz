using Foodyz.Application.Contracts.Interfaces;
using Foodyz.Infrastructure.Data;
using Foodyz.Infrastructure.Implemention;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Foodyz.Infrastructure.Register
{
    public static class InfrastructureRegisterition
    {
        public static IServiceCollection InfrastructureRegister(this IServiceCollection services, IConfiguration configuration) 
        {
            services.AddDbContext<ApplicationDbContext>
                (o=> o.UseNpgsql(configuration.GetConnectionString("Default")));
            services.AddScoped(typeof(IGenericRepository<>),typeof(GenericRepository<>));
            services.AddScoped<IRestaurantRepository, RestaurantRepository>();
            services.AddScoped<ICategoryRepository, CategoryRepository>();
            return services;
        }
    }
}
