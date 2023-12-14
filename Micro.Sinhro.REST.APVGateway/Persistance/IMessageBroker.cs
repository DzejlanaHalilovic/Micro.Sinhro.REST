using Microsoft.AspNetCore.Connections;
using Newtonsoft.Json;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;

namespace Micro.Sinhro.REST.APIGateway.Persistance
{
    public interface IMessageBroker
    {
        string Consume();   

    }
    public class  MessageBroker : IMessageBroker
    {
        
        public string Consume()
        {
            var Factory = new ConnectionFactory() { HostName = "localhost", Port = 5672, UserName = "guest", Password = "guest" };
            var connection = Factory.CreateConnection();
            using var channel = connection.CreateModel();
            channel.QueueDeclare(queue: "grades", durable: false, exclusive: false, autoDelete: false, arguments: null);

            var consumer = new EventingBasicConsumer(channel);
            var result = "";

            consumer.Received += (sender, args) =>
            {
                var body = args.Body.ToArray();
                 result = System.Text.Encoding.UTF8.GetString(body);
               
            };
           channel.BasicConsume(queue: "grades", autoAck: true, consumer: consumer);
            return result;

        }
    }
}
