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
        public static string TopicName = "deposit-topic";
        public static string GroupId = "deposit-consumer-group";
        public static string Port = "9092";
    }
}
