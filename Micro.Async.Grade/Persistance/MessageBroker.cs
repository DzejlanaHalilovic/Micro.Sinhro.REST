using Newtonsoft.Json;
using RabbitMQ.Client;

namespace Micro.Async.Grade.Persistance
{
    public class MessageBroker : IMessageBroker
    {
        public void Publish<T>(T message)
        {
           var Factory = new ConnectionFactory() {
               HostName = "localhost", 
               Port=5672,
               UserName="guest",
               Password="guest" };
            var connection = Factory.CreateConnection();
            using var channel = connection.CreateModel();
            channel.QueueDeclare(queue: "grades",durable: false, exclusive: false, autoDelete: false, arguments: null);
            var body = System.Text.Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(message));
            channel.BasicPublish("", "grades", body: body);




        }
    }
}
