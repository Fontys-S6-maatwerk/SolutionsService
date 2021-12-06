using System;
using System.Text;
using Newtonsoft.Json;
using RabbitMQ.Client;
using SolutionsService.Models;

namespace Auth_Service.Web.Logic
{
    public class EventbusSendHowTo
    {
        public void SendHowTo(HowTo sendHowTo)
        {
            var factory = new ConnectionFactory() { HostName = "localhost" };
            using (var connection = factory.CreateConnection())
            using (var channel = connection.CreateModel())
            {
                channel.ExchangeDeclare(exchange: "howTo_article_logs", ExchangeType.Direct);

                var message = GetMessageCreateUser(sendHowTo);
                var body = Encoding.UTF8.GetBytes(message);

                var properties = channel.CreateBasicProperties();
                properties.Persistent = true;
                properties.CorrelationId = Guid.NewGuid().ToString();

                channel.BasicPublish(exchange: "solution_logs", routingKey: "", basicProperties: properties, body: body);
                Console.WriteLine(" [x] Sent {0}", message);
            }
        }

        private static string GetMessageCreateUser(HowTo howTo)
        {
            var json = JsonConvert.SerializeObject(howTo);
            string message = "Create new HowTo";
            return ((json.Length > 0) ? string.Join(" ", json) : message);
        }
    }
}
