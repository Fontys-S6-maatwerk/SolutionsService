using System;
using System.Text;
using Newtonsoft.Json;
using RabbitMQ.Client;
using SolutionsService.Models.RequestModel;

namespace Auth_Service.Web.Logic
{
    public class EventbusSend
    {
        public void SendUser(SolutionRequestModel sendSolution)
        {
            var factory = new ConnectionFactory() { HostName = "localhost" };
            using (var connection = factory.CreateConnection())
            using (var channel = connection.CreateModel())
            {
                channel.ExchangeDeclare(exchange: "topic_logs", ExchangeType.Fanout);

                var message = GetMessageCreateUser(sendSolution);
                var body = Encoding.UTF8.GetBytes(message);

                var properties = channel.CreateBasicProperties();
                properties.Persistent = true;
                properties.CorrelationId = Guid.NewGuid().ToString();

                channel.BasicPublish(exchange: "topic_logs", routingKey: "", basicProperties: properties, body: body);
                Console.WriteLine(" [x] Sent {0}", message);
            }
        }

        private static string GetMessageCreateUser(SolutionRequestModel solution)
        {
            var json = JsonConvert.SerializeObject(solution);
            string message = "Create new User";
            return ((json.Length > 0) ? string.Join(" ", json) : message);
        }
    }
}
