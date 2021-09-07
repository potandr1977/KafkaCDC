using System;

namespace KafkaCDC.Settings
{
    public static class PostgreSettings
    {
        public const string ConnectionString = "Host=pgserver;Port=5432;Database=depositdb;User Id=adm;Password=adm;Pooling=true;";
        
        public const string DbName = "depositdb";
        
        public const string TableName = "deposits";
    }
}
