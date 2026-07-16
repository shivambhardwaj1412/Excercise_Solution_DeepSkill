namespace KafkaChatWinForms;

public partial class ChatForm : Form
{
    private readonly KafkaService _kafka;
    private readonly string _userName;

    public ChatForm(string userName)
    {
        InitializeComponent();
        _userName = userName;
        Text = $"Kafka Chat — {userName}";

        _kafka = new KafkaService();
        _kafka.StartConsuming($"winforms-{userName}-{Guid.NewGuid():N}", AppendMessage);
    }

    private void AppendMessage(string message)
    {
        if (lstMessages.InvokeRequired)
            lstMessages.Invoke(() => lstMessages.Items.Add(message));
        else
            lstMessages.Items.Add(message);
    }

    private async void btnSend_Click(object sender, EventArgs e)
    {
        string text = txtMessage.Text.Trim();
        if (string.IsNullOrEmpty(text)) return;

        await _kafka.SendAsync($"{_userName}: {text}");
        txtMessage.Clear();
        txtMessage.Focus();
    }

    private void txtMessage_KeyDown(object sender, KeyEventArgs e)
    {
        if (e.KeyCode == Keys.Enter)
            btnSend_Click(sender, e);
    }

    protected override void OnFormClosed(FormClosedEventArgs e)
    {
        _kafka.Dispose();
        base.OnFormClosed(e);
    }
}
