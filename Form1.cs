using uml_diagram.core;
using uml_diagram.interfaces;
using uml_diagram.ui;

namespace uml_diagram;

public partial class Form1 : Form
{
    private Diagram _diagram = new();
    private ClickScrollMenu? _scrollMenu;
    private bool mouseDown = false;
    public Form1()
    {
        InitializeComponent();
        this.pbox_Diagram.Location = new(0, 0);
        this.pbox_Diagram.Size = this.Size;
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
        this.mouseDown = true;
    }

    private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
    {
        if (!this.mouseDown) return;

        IComponent? component = _diagram.GetHoveredComponent(e);
        if(component is not null)
        {
            component.Location = new(e.X - component.Size.Width / 2, e.Y - component.Size.Height / 2);
            this.pbox_Diagram.Refresh();
        }
    }

    private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
    {
        this.mouseDown = false;
    }

    private void pictureBox1_MouseDoubleClick(object sender, MouseEventArgs e)
    {
        if((e.Button & MouseButtons.Left) != 0 && _diagram.GetHoveredComponent(e) is not null)
        {
            _diagram.EditUMLObject(e);
            pbox_Diagram.Refresh();
        }
    }

    private void pbox_Diagram_MouseClick(object sender, MouseEventArgs e)
    {
        if ((e.Button & MouseButtons.Right) != 0)
        {
            _scrollMenu = new(this.Controls, new Point(e.X, e.Y));
            _scrollMenu.AddAction("new object", () =>
            {
                Form_ManageObject frm = new Form_ManageObject(new Point(e.X, e.Y));
                if (DialogResult.OK == frm.ShowDialog())
                {
                    _diagram.AddObject(frm.UmlObject);
                }

                pbox_Diagram.Refresh();
            });
            _scrollMenu.AddAction("remove object", () =>
            {
                _diagram.RemoveObjectByLocation(e);
                pbox_Diagram.Refresh();
            });
            _scrollMenu.AddAction("edit object", () =>
            {
                _diagram.EditUMLObject(e);
                pbox_Diagram.Refresh();
            });
            _scrollMenu.AddAction("implement interface", () =>
            {
                
            });
            _scrollMenu.AddAction("inherit from class", () =>
            {
                
            });
                
            _scrollMenu.Show();
            this.Refresh();
        }

        if ((e.Button & MouseButtons.Left) != 0)
        {
            _scrollMenu?.Hide();
        }
    }
}