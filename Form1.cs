namespace uml_diagram;

public partial class Form1 : Form
{
    public Form1()
    {
        InitializeComponent();
    }

    private void button1_Click(object sender, EventArgs e)
    {
        Form_AddObject frm  = new Form_AddObject();
        if (DialogResult.OK == frm.ShowDialog())
        {
            
        }
    }

    private void pictureBox1_Paint(object sender, PaintEventArgs e)
    {
        throw new System.NotImplementedException();
    }

    private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
    {
        throw new System.NotImplementedException();
    }

    private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
    {
        throw new System.NotImplementedException();
    }

    private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
    {
        throw new System.NotImplementedException();
    }

    private void pictureBox1_MouseDoubleClick(object sender, MouseEventArgs e)
    {
        throw new System.NotImplementedException();
    }
}