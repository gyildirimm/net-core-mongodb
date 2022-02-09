using Business.Conditions;
using Business.Interfaces;
using Business.Services;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.DependencyResolvers
{
    public static class ServicesDependency
    {
        public static void SetServices(this IServiceCollection services)
        {
            services.AddSingleton<IBasketService, BasketService>();

            services.AddSingleton<IBasketCondition, BasketCondition>();
        }
    }
}
