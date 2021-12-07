using System;
using System.Text;
using Newtonsoft.Json;
using RabbitMQ.Client;
using SolutionsService.Models.RequestModel;

namespace SolutionsService.EventBus
{
    public class EventbusSendHowTo
    {
        public void SendHowTo(HowToRequestModel sendHowTo)
        {
            var factory = new ConnectionFactory() { HostName = "src-rabbitmq-service-1" };
            using (var connection = factory.CreateConnection())
            using (var channel = connection.CreateModel())
            {
                channel.QueueDeclare(queue: "translation_queue", durable: true, exclusive: false, autoDelete: false, arguments: null);

                var message = GetMessageCreateHowTo(sendHowTo);
                var body = Encoding.UTF8.GetBytes(message);

                var properties = channel.CreateBasicProperties();
                properties.Persistent = true;

                channel.BasicPublish(exchange: "", routingKey: "translation_queue", basicProperties: properties, body: body);
                Console.WriteLine(" [x] Sent {0}", message);
            }
        }

        private static string GetMessageCreateHowTo(HowToRequestModel howTo)
        {
            var json = JsonConvert.SerializeObject(howTo);
            string message = "Create new HowTo";
            return ((json.Length > 0) ? string.Join(" ", json) : message);
        }
    }
}
