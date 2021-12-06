using System;
using System.Text;
using Newtonsoft.Json;
using RabbitMQ.Client;
using SolutionsService.Models;

namespace Auth_Service.Web.Logic
{
    public class EventbusSendArticle
    {
        public void SendArticle (Article sendArticle)
        {
            var factory = new ConnectionFactory() { HostName = "localhost" };
            using (var connection = factory.CreateConnection())
            using (var channel = connection.CreateModel())
            {
                channel.ExchangeDeclare(exchange: "howTo_article_logs", ExchangeType.Direct);

                var message = GetMessageCreateUser(sendArticle);
                var body = Encoding.UTF8.GetBytes(message);

                var properties = channel.CreateBasicProperties();
                properties.Persistent = true;
                properties.CorrelationId = Guid.NewGuid().ToString();

                channel.BasicPublish(exchange: "solution_logs", routingKey: "", basicProperties: properties, body: body);
                Console.WriteLine(" [x] Sent {0}", message);
            }
        }

        private static string GetMessageCreateUser(Article article)
        {
            var json = JsonConvert.SerializeObject(article);
            string message = "Create new Article";
            return ((json.Length > 0) ? string.Join(" ", json) : message);
        }
    }
}
