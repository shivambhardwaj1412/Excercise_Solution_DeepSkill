using Confluent.Kafka;

namespace KafkaChatConsole;

public class KafkaConsumer
{
    private readonly IConsumer<Ignore, string> _consumer;

    public KafkaConsumer(string bootstrapServers, string topic, string groupId)
    {
        var config = new ConsumerConfig
        {
            BootstrapServers = bootstrapServers,
            GroupId = groupId,
            AutoOffsetReset = AutoOffsetReset.Latest
        };
        _consumer = new ConsumerBuilder<Ignore, string>(config).Build();
        _consumer.Subscribe(topic);
    }

    public void StartConsuming(CancellationToken ct)
    {
        Console.WriteLine("[Consumer] Listening for messages...\n");
        try
        {
            while (!ct.IsCancellationRequested)
            {
                var result = _consumer.Consume(ct);
                Console.WriteLine($"[Received] {result.Message.Value}");
            }
        }
        catch (OperationCanceledException) { }
        finally { _consumer.Close(); }
    }
}
