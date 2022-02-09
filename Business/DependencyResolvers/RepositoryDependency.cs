using DAL.Interfaces;
using DAL.Repositories;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.DependencyResolvers
{
    public static class RepositoryDependency
    {
        public static void SetRepositories(this IServiceCollection services)
        {
            services.AddSingleton<IBasketRepository, BasketRepository>();
        }
    }
}
