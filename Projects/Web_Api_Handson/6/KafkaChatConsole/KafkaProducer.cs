using Confluent.Kafka;

namespace KafkaChatConsole;

public class KafkaProducer : IDisposable
{
    private readonly IProducer<Null, string> _producer;
    private readonly string _topic;

    public KafkaProducer(string bootstrapServers, string topic)
    {
        _topic = topic;
        var config = new ProducerConfig { BootstrapServers = bootstrapServers };
        _producer = new ProducerBuilder<Null, string>(config).Build();
    }

    public async Task SendMessageAsync(string message)
    {
        await _producer.ProduceAsync(_topic, new Message<Null, string> { Value = message });
        Console.WriteLine($"[Sent] {message}");
    }

    public void Dispose() => _producer.Dispose();
}
