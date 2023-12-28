namespace LocalLibrary.MessageBus
{
    public interface IMessageBus<T> where T : class
    {
        Task PublicMessage(T message, string queueName);
    }
}
