using KafkaChatConsole;

const string BootstrapServers = "localhost:9092";
const string Topic = "chat-topic";

Console.WriteLine("=== Kafka Console Chat ===");
Console.Write("Enter your name: ");
string name = Console.ReadLine() ?? "Anonymous";

Console.WriteLine("\nSelect mode:");
Console.WriteLine("  1 - Producer (send messages)");
Console.WriteLine("  2 - Consumer (receive messages)");
Console.Write("Choice: ");
string choice = Console.ReadLine() ?? "1";

if (choice == "1")
{
    using var producer = new KafkaProducer(BootstrapServers, Topic);
    Console.WriteLine("\nType a message and press Enter to send. Type 'exit' to quit.\n");

    while (true)
    {
        string? input = Console.ReadLine();
        if (string.IsNullOrWhiteSpace(input) || input.Equals("exit", StringComparison.OrdinalIgnoreCase))
            break;

        await producer.SendMessageAsync($"{name}: {input}");
    }
}
else
{
    var cts = new CancellationTokenSource();
    Console.CancelKeyPress += (_, e) => { e.Cancel = true; cts.Cancel(); };

    var consumer = new KafkaConsumer(BootstrapServers, Topic, $"chat-group-{name}");
    consumer.StartConsuming(cts.Token);
}

Console.WriteLine("\nGoodbye!");
