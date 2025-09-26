using uml_diagram.core;
using uml_diagram.ui;

namespace uml_diagram;

public partial class Form1 : Form
{
    private Diagram _diagram = new();
    private ClickScrollMenu? _scrollMenu;
    public Form1()
    {
        InitializeComponent();
    }

    private void button1_Click(object sender, EventArgs e)
    {
        
    }

    private void pictureBox1_Paint(object sender, PaintEventArgs e)
    {
        _diagram.Draw(e.Graphics);
    }

    private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
    {
    }

    private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
    {
    }

    private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
    {
    }

    private void pictureBox1_MouseDoubleClick(object sender, MouseEventArgs e)
    {
    }

    private void pbox_Diagram_MouseClick(object sender, MouseEventArgs e)
    {
        if ((e.Button & MouseButtons.Right) != 0)
        {
            _scrollMenu = new(this.Controls, new Point(e.X + 14 , e.Y + 14));
            _scrollMenu.AddAction("new object", () =>
            {
                Form_AddObject frm  = new Form_AddObject(new(e.X + 14, e.Y + 14));
                if (DialogResult.OK == frm.ShowDialog())
                {
                    _diagram.AddObject(frm.UmlObject);
                }
                pbox_Diagram.Refresh();        
            });
            
            _scrollMenu.Show();
            this.Refresh();
        }

        if ((e.Button & MouseButtons.Left) != 0)
        {
            _scrollMenu.Hide();
        }
    }
}