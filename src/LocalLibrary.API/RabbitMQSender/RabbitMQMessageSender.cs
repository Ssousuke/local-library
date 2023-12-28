using RabbitMQ.Client;
using System.Text;
using System.Text.Json;

namespace LocalLibrary.API.RabbitMQSender
{
    public class RabbitMQMessageSender<T> : IRabbitMQMessageSender<T> where T : class

    {
        private readonly string _hostName;
        private readonly string _passWord;
        private readonly string _userName;
        private IConnection _connection;

        public RabbitMQMessageSender()
        {
            _hostName = "localhost";
            _passWord = "guest";
            _userName = "guest";
        }

        public void SendMessage(T message, string queueName)
        {
            var factory = new ConnectionFactory()
            {
                HostName = _hostName,
                UserName = _userName,
                Password = _passWord
            };
            _connection = factory.CreateConnection();

            using var channel = _connection.CreateModel();

            channel.QueueDeclare(queue: queueName, false, false, false, arguments: null);
            byte[] body = GetMessageAsByteArray(message);
            channel.BasicPublish(exchange: "", routingKey: queueName, basicProperties: null, body: body);
        }

        public void SendMessage(IEnumerable<T> message, string queueName)
        {
            var factory = new ConnectionFactory()
            {
                HostName = _hostName,
                UserName = _userName,
                Password = _passWord
            };
            _connection = factory.CreateConnection();

            using var channel = _connection.CreateModel();

            channel.QueueDeclare(queue: queueName, false, false, false, arguments: null);
            byte[] body = GetMessageAsByteArray(message);
            channel.BasicPublish(exchange: "", routingKey: queueName, basicProperties: null, body: body);
        }

        private byte[] GetMessageAsByteArray<T>(T message)
        {
            var options = new JsonSerializerOptions()
            {
                WriteIndented = true,
            };
            var json = JsonSerializer.Serialize<T>((T)message, options);
            return Encoding.UTF8.GetBytes(json);
        }
    }
}
