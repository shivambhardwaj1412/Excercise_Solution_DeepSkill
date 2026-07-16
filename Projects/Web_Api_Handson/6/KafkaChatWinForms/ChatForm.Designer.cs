namespace KafkaChatWinForms;

partial class ChatForm
{
    private System.ComponentModel.IContainer components = null;
    private ListBox lstMessages;
    private TextBox txtMessage;
    private Button btnSend;
    private Label lblMessages;
    private Label lblInput;

    protected override void Dispose(bool disposing)
    {
        if (disposing && (components != null)) components.Dispose();
        base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
        lblMessages = new Label();
        lstMessages = new ListBox();
        lblInput    = new Label();
        txtMessage  = new TextBox();
        btnSend     = new Button();
        SuspendLayout();

        // lblMessages
        lblMessages.Text     = "Chat Messages:";
        lblMessages.Location = new Point(12, 9);
        lblMessages.Size     = new Size(100, 15);

        // lstMessages
        lstMessages.Location  = new Point(12, 27);
        lstMessages.Size      = new Size(560, 320);
        lstMessages.ScrollAlwaysVisible = true;

        // lblInput
        lblInput.Text     = "Message:";
        lblInput.Location = new Point(12, 360);
        lblInput.Size     = new Size(60, 15);

        // txtMessage
        txtMessage.Location = new Point(75, 357);
        txtMessage.Size     = new Size(410, 23);
        txtMessage.KeyDown += txtMessage_KeyDown;

        // btnSend
        btnSend.Text     = "Send";
        btnSend.Location = new Point(495, 355);
        btnSend.Size     = new Size(77, 27);
        btnSend.Click   += btnSend_Click;

        // ChatForm
        ClientSize  = new Size(584, 400);
        MinimumSize = new Size(600, 440);
        Text        = "Kafka Chat";
        Controls.AddRange(new Control[] { lblMessages, lstMessages, lblInput, txtMessage, btnSend });
        ResumeLayout(false);
        PerformLayout();
    }
}
