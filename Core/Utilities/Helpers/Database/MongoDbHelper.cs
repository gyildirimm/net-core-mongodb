using Core.Utilities.Settings;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Helpers.Database
{
    public static class MongoDbHelper
    {
        public static IMongoCollection<T> GetCollection<T>(MongoDbSetting setting)
        {
            var client = new MongoClient(setting.ConnectionString);
            var db = client.GetDatabase(setting.Database);

            return db.GetCollection<T>(typeof(T).Name.ToLowerInvariant());
        }
    }
}
