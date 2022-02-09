using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Settings
{
    public class MongoDbSetting
    {
        public string ConnectionString;
        public string Database;


        public const string ConnectionStringValue = nameof(ConnectionString);
        public const string DatabaseValue = nameof(Database);
    }
}
