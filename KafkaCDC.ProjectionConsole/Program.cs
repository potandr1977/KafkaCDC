using Confluent.Kafka;
using KafkaCDC.ProjectionConsole.Serialization;
using KafkaCDC.Settings;
using System;
using System.Text.Json;
using System.Threading;

namespace KafkaCDC.Domain.Mongo
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

            using (var consumer = new ConsumerBuilder<Ignore, Deposit>(config)
                .SetValueDeserializer(new KafkaMessageSerDe<Deposit>(new JsonSerializerOptions
                {
                    PropertyNamingPolicy = JsonNamingPolicy.CamelCase
                }))
                .SetErrorHandler((producer, error) =>
                {
                    Console.WriteLine("Kafka consumer Error: " + error.Reason);
                })
                .SetStatisticsHandler((_, json) =>
                    Console.WriteLine("Consumer Statistics: " + json))
                .Build())
            {
                consumer.Subscribe(KafkaSettings.TopicName);
                var cts = new CancellationTokenSource();

                Console.CancelKeyPress += (_, e) => {
                    e.Cancel = true; // prevent the process from terminating.
                    cts.Cancel();
                };
                try
                {
                    var consumeResult = consumer.Consume(cts.Token);
                    // handle consumed message.
                    var m = consumeResult.Message;
                }
                catch (ConsumeException ex)
                {
                    Console.Write(ex.Message);
                }
                consumer.Close();
            }
            Console.WriteLine("Consumer finished");
        }
    }
}
