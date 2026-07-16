using KafkaChatWinForms;

ApplicationConfiguration.Initialize();

string userName = Microsoft.VisualBasic.Interaction.InputBox(
    "Enter your chat name:", "Kafka Chat", "User");

if (string.IsNullOrWhiteSpace(userName))
    userName = "Anonymous";

Application.Run(new ChatForm(userName));
