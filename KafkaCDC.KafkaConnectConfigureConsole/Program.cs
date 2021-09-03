using KafkaCDC.KafkaConnectConfigureConsole;
using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace KafkaCDC.KafkaConnectConfitureConsole
{
    class Program
    {
        private const string KafkaConnectUrl = "http://www.example.com/recepticle.aspx";
        private static readonly HttpClient client = new HttpClient();

        static async Task Main(string[] args)
        {
            var json = KafkaConnectSettings.ConnectorSettings;
            await SendConfigurationToKafkaConnect(json);
        }

        private static async Task SendConfigurationToKafkaConnect(string json)
        {
            using var content = new StringContent(JsonConvert.SerializeObject(json), System.Text.Encoding.UTF8, "application/json");
            var result = await client.PostAsync(KafkaConnectUrl, content);

            if (result.StatusCode == System.Net.HttpStatusCode.Created)
            {
                Console.WriteLine("Configuration successfully uploaded to KafkaConnect"); ;
            }

            var returnValue = await result.Content.ReadAsStringAsync();
            Console.WriteLine($"Failed to POST data: ({result.StatusCode}): {returnValue}");
        }
    }
}
