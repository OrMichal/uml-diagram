namespace uml_diagram;

public partial class ErrorMessage : Form
{
    public ErrorMessage()
    {
        InitializeComponent();
        label_Message.BringToFront();
    }

    public ErrorMessage(string message): this()
    {
        this.label_Message.Text = message;
    }

    public void ShowMessage(int milis = 3000)
    {
        Show();
        Task.Delay(milis);
        Close();
    }
}