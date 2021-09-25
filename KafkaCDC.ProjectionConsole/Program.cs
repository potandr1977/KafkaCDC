using Confluent.Kafka;
using KafkaCDC.Settings;
using System;

namespace KafkaCDC.Domain.FillData
{
    class Program
    {
        static void Main(string[] args)
        {
            var config = new ConsumerConfig
            {
                BootstrapServers = $"{KafkaSettings.Host}:{KafkaSettings.Port}",
                GroupId = KafkaSettings.GroupId,
                AutoOffsetReset = AutoOffsetReset.Earliest
            };

            using (var consumer = new ConsumerBuilder<Ignore, string>(config)
                .SetErrorHandler((producer, error) =>
                {
                    Console.WriteLine("Kafka consumer Error: " + error.Reason);
                })
                .SetStatisticsHandler((_, json) =>
                    Console.WriteLine("Consumer Statistics: " + json))
                .Build())
            {
                consumer.Subscribe(KafkaSettings.TopicName);
                try
                {
                    /*
                    var watermark = consumer.QueryWatermarkOffsets(new TopicPartition("products.cache", new Partition(0)), TimeSpan.FromMilliseconds(10000));

                    if (watermark.High.Value == 0)
                        return;
                    */
                    while (true)
                    {
                        try
                        {
                            ConsumeResult<Ignore, string> cr = consumer.Consume();

                            if (cr.Message?.Value != null)
                            {
                                //var item = JsonConvert.DeserializeObject<ProductCacheItem>(cr.Value);
                                var message = cr.Message.Value;
                            }

                            /*
                            if (watermark.High.Value - 1 == cr.Offset.Value)
                                return;
                            */
                        }
                        catch (Exception e)
                        {
                            throw;
                        }
                    }
                }
                catch (Exception ex)
                {
                    throw;
                }
            }
        }
    }
}
