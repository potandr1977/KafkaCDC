using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KafkaCDC.Settings
{
    public static class KafkaSettings
    {
        public static string Host = "kafka";
        public static string TopicName = "pgserver.public.Deposits";
        public static string GroupId = "1";
        public static string Port = "9092";
    }
}
