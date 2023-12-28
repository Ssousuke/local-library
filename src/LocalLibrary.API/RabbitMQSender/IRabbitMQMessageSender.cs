namespace LocalLibrary.API.RabbitMQSender
{
    public interface IRabbitMQMessageSender<T> where T : class
    {
        void SendMessage(T message, string queueName);
        void SendMessage(IEnumerable<T> message, string queueName);
    }
}
