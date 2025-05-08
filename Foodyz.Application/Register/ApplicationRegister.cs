using Foodyz.Application.Mapper;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Foodyz.Application.Register
{
    public static class ApplicationRegister
    {
        public static IServiceCollection ApplicationRegisterition (this IServiceCollection services) 
        {
            services.AddAutoMapper(typeof(AutoMapping));
            services.AddMediatR(m=> m.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));
            return services;
        }
    }
}
