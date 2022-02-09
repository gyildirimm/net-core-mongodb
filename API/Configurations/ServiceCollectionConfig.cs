using Core.Utilities.Settings;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace API.Configurations
{
    public static class ServiceCollectionConfig
    {
        public static IServiceCollection AddMongoDbSettings(this IServiceCollection services,
           IConfiguration configuration)
        {
            return services.Configure<MongoDbSetting>(options =>
            {
                options.ConnectionString = configuration
                    .GetSection(nameof(MongoDbSetting) + ":" + MongoDbSetting.ConnectionStringValue).Value;
                options.Database = configuration
                    .GetSection(nameof(MongoDbSetting) + ":" + MongoDbSetting.DatabaseValue).Value;
            });
        }
    }
}
