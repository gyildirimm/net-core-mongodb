using Core.Utilities.Settings;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Extensions.Database
{
    public static class MongoDbExtensions
    {
        public static IMongoCollection<T> GetCollection<T>(this MongoDbSetting setting)
        {
            var client = new MongoClient(setting.ConnectionString);
            var db = client.GetDatabase(setting.Database);

            return db.GetCollection<T>(typeof(T).Name.ToLowerInvariant());
        }
    }
}
