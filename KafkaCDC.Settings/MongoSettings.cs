using System;

namespace KafkaCDC.Settings
{
    public static class MongoSettings
    {
        public const string ConnectionString = "mongodb://kafkacdc_mongodb:27017/madb/";
        
        public const string DbName = "depositdb";
        
        public const string CollectionName = "deposits";
    }
}
