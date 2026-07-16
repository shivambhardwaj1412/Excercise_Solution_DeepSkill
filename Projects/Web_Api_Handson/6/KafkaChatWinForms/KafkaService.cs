using Confluent.Kafka;

namespace KafkaChatWinForms;

public class KafkaService : IDisposable
{
    private readonly IProducer<Null, string> _producer;
    private IConsumer<Ignore, string>? _consumer;
    private CancellationTokenSource? _cts;

    public const string BootstrapServers = "localhost:9092";
    public const string Topic = "chat-topic";

    public KafkaService()
    {
        var producerConfig = new ProducerConfig { BootstrapServers = BootstrapServers };
        _producer = new ProducerBuilder<Null, string>(producerConfig).Build();
    }

    public async Task SendAsync(string message) =>
        await _producer.ProduceAsync(Topic, new Message<Null, string> { Value = message });

    public void StartConsuming(string groupId, Action<string> onMessage)
    {
        var config = new ConsumerConfig
        {
            BootstrapServers = BootstrapServers,
            GroupId = groupId,
            AutoOffsetReset = AutoOffsetReset.Latest
        };
        _consumer = new ConsumerBuilder<Ignore, string>(config).Build();
        _consumer.Subscribe(Topic);
        _cts = new CancellationTokenSource();

        Task.Run(() =>
        {
            try
            {
                while (!_cts.Token.IsCancellationRequested)
                {
                    var result = _consumer.Consume(_cts.Token);
                    onMessage(result.Message.Value);
                }
            }
            catch (OperationCanceledException) { }
            finally { _consumer.Close(); }
        });
    }

    public void Dispose()
    {
        _cts?.Cancel();
        _producer.Dispose();
    }
}
