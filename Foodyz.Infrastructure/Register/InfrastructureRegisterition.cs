using Foodyz.Infrastructure.Data;
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
            return services;
        }
    }
}
