using uml_diagram.core;
using uml_diagram.extensions;
using uml_diagram.interfaces;
using uml_diagram.objects.uml;
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
        InitializeNavbar();
        this.pbox_Diagram.Location = new(0, menuStrip1.Size.Height);
        this.pbox_Diagram.Size = this.Size;
        this._scrollMenu = _diagram.ClickMenu;
        this.ContextMenuStrip = _diagram.ClickMenu.GetMenu();
        this._diagram.ClickMenu.Payload += () => this.pbox_Diagram.Refresh();
        
        this._diagram.ClickMenu._menu.Opened += (sender, args) => 
            this._diagram.ClickMenu.Location = this.pbox_Diagram.PointToClient(this._diagram.ClickMenu._menu.Location);
    }

    public void InitializeNavbar()
    {
        ToolStripMenuItem projectItem = new("Project");
        ToolStripMenuItem diagramItem = new("Diagram");
        ToolStripMenuItem windowItem = new("Window");
        
        ToolStripMenuItem diagramAddObjectItem = new("Add Object");
        ToolStripMenuItem diagramImplementInterfaceItem = new("Implement interface");
        ToolStripMenuItem diagramAddAssociationItem = new("Add Association");

        ToolStripMenuItem windowExitItem = new("Quit");
        
        diagramAddObjectItem.Click += (s, e) =>
        {
            OpenAddObjectForm(new(40, 40));
        };

        diagramAddAssociationItem.Click += (s, e) =>
        {
            
        };

        windowExitItem.Click += (s, e) =>
        {

            if (DialogResult.OK == MessageBox.Show("Are you sure you want to quit?", "Quit", MessageBoxButtons.OKCancel))
            {
                Environment.Exit(0);
            }
        };
        
        diagramItem.DropDownItems.AddRange(new[] { diagramAddObjectItem, diagramImplementInterfaceItem });
        windowItem.DropDownItems.AddRange(new[] { windowExitItem });
        
        menuStrip1.Items.AddRange(new[] { projectItem, diagramItem, windowItem });
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
        _diagram.SelectComponent(e.Location);
        pbox_Diagram.Refresh();
        
        IComponent? component = _diagram.GetHoveredComponent(e.Location);
        if(component is null)
        {
            this.Cursor = Cursors.Default;
            return;
        }
        
        this.Cursor = Cursors.Hand;
        if (this.mouseDown)
        {
            component.Location = new(e.X - component.Size.Width / 2, e.Y - component.Size.Height / 2);
            this.pbox_Diagram.Refresh();
        }
    }

    private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
    {
        this.mouseDown = false;
        this.Cursor = Cursors.Default;
    }

    private void pictureBox1_MouseDoubleClick(object sender, MouseEventArgs e)
    {
        if((e.Button & MouseButtons.Left) != 0 && _diagram.GetHoveredComponent(e.Location) is not null)
        {
            _diagram.EditUMLObject(e.Location);
            pbox_Diagram.Refresh();
        }
    }

    private void pbox_Diagram_MouseClick(object sender, MouseEventArgs e)
    {
        if ((e.Button & MouseButtons.Right) != 0)
        {
            _scrollMenu.Show(this.pbox_Diagram, new(e.X, e.Y));
            
            this.pbox_Diagram.Refresh();
            this.Refresh();
        }

        if ((e.Button & MouseButtons.Left) != 0)
        {
            _scrollMenu?._menu.Close();
            _diagram.SelectComponent(e.Location);
            
            pbox_Diagram.Refresh();

            if (!_diagram.Linker.HasTarget()) return;

            if (_diagram.GetHoveredComponent(e.Location) is UMLObject umlObj)
            {
                _diagram.FinalizeLink(umlObj);
                this.pbox_Diagram.Refresh();
                _diagram.implementing = false;
                _diagram.Linker.NullifyTarget();
            }
        }
    }

    private void timer1_Tick(object sender, EventArgs e)
    {
        this.pbox_Diagram.Refresh();
    }

    private void Form1_ResizeEnd(object sender, EventArgs e)
    {
        pbox_Diagram.Size = this.Size;
    }

    private void Form1_KeyDown(object sender, KeyEventArgs e)
    {
        if(e.KeyCode == Keys.Delete)
        {
            if(DialogResult.OK != MessageBox.Show("Are you sure?", "haha", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation))
                return;
            
            _diagram.RemoveSelectedComponent();
        }
        pbox_Diagram.Refresh();
    }

    private void OpenAddObjectForm(Point objLocation)
    {
        Form_ManageObject frm = new(objLocation);
        if (DialogResult.OK == frm.ShowDialog())
        {
            _diagram.AddObject(frm.UmlObject);
        }
    }
}