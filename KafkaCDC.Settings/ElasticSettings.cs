using System;
using System.Collections.Generic;
using System.Text;

namespace KafkaCDC.Settings
{
    public static class ElasticSettings
    {
        public const string Url = "http://kafkacdc_elastic:9200";
        
        public const string DefaultIndexName = "accounts";
    }
}
