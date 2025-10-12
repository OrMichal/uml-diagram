using Microsoft.VisualBasic;
using uml_diagram.core;
using uml_diagram.data_managers;
using uml_diagram.extensions;
using uml_diagram.interfaces;
using uml_diagram.objects.uml;
using uml_diagram.ui;

namespace uml_diagram;

public partial class Form1 : Form
{
    private ClickScrollMenu? _scrollMenu;
    private bool mouseDown = false;
    private List<Namespace> _namespaces = new();
    private ContextMenuStrip ClickMenu = new();
    
    private float _pageScale { get; set; } = 1f;
    private bool dragging = false;
    private PointF dragStart; 
    private PointF pboxOffset = new(0, 0);
    
    private Diagram _diagram
    {
        get => this._namespaces.Find(n => n.Name == _selectedNamespaceName).Diagram;
    }
    private string _selectedNamespaceName = "new_namespace";
    private Namespace _selectedNamespace
    {
        get => _namespaces.Find(x => x.Name == _selectedNamespaceName);
    }
    
    public Form1()
    {
        InitializeComponent();
        InitializeNavbar();
        InitializeContextMenuStrip();

        AddNamespace("new_namespace");
        
        this._scrollMenu = _diagram.ClickMenu;
        this.pbox_Diagram.ContextMenuStrip = ClickMenu;
        this._diagram.ClickMenu.Payload += () => this.pbox_Diagram.Refresh();
        
        this._diagram.ClickMenu._menu.Opened += (sender, args) => 
            this._diagram.ClickMenu.Location = this.pbox_Diagram.PointToClient(this._diagram.ClickMenu._menu.Location);
        
        treeView_Namespaces.SelectedNode = null;
        this.MouseWheel += (s, e) => 
        {
            if(e.Delta > 0 && _pageScale + 0.1f <= 5f)
                _pageScale += 0.1f;
            if(e.Delta < 0 && _pageScale - 0.1f >= 0.1f)
                _pageScale -= 0.1f;
            
            pbox_Diagram.Refresh();
        };
    }

    public void InitializeContextMenuStrip() 
    {
        ToolStripMenuItem newObjectItem = new("new object");
        ToolStripMenuItem removeObjectItem = new("remove object");
        ToolStripMenuItem editObjectItem = new("edit object");
        ToolStripMenuItem addRelationshipItem = new("add relationship");
        
        
        newObjectItem.Click += (sender, ev) =>
        {
            Form_ManageObject frm = new Form_ManageObject(ClickMenu.Location);
            if (DialogResult.OK == frm.ShowDialog())
            {
                var a = frm.UmlObject.ToUMLComponent();
                _diagram.AddObject(a);
            }
        };
        
        
        removeObjectItem.Click +=  (sender, ev) =>
        {
            _diagram.RemoveObjectByLocation(ClickMenu.Location);
        };
        
        editObjectItem.Click += (sender, ev) =>
        {
            _diagram.EditUMLObject(ClickMenu.Location);
        };
        
        addRelationshipItem.Click += (sender, ev) =>
        {
            _diagram.Linker.SetTarget(_diagram._selectedComponent.TryAs<UMLObject>());
            Form_RelationshipPicker frm = new(_diagram._selectedComponent.TryAs<UMLObject>());
            
            if(DialogResult.OK == frm.ShowDialog())
            {
                _diagram._currLink = frm.Link;
            }
        };
        
        ClickMenu.Items.AddRange(new[] { newObjectItem, editObjectItem, removeObjectItem, addRelationshipItem });
    }
    
    public void InitializeNavbar()
    {
        ToolStripMenuItem projectItem = new("Project");
        ToolStripMenuItem diagramItem = new("Diagram");
        ToolStripMenuItem windowItem = new("Window");

        ToolStripMenuItem projectImportDiagramItem = new("import diagram");
        ToolStripMenuItem projectExportDiagramItem = new("export diagram");
        
        ToolStripMenuItem diagramAddObjectItem = new("Add Object");
        ToolStripMenuItem diagramImplementInterfaceItem = new("Implement interface");
        ToolStripMenuItem diagramAddAssociationItem = new("Add Association");
        ToolStripMenuItem diagramAddNamespaceItem = new("new namespace");
        ToolStripMenuItem diagramExportAsJpgItem = new("export as .jpg");
        ToolStripMenuItem diagramGenerateCodeItem = new("generate code");
        
        ToolStripMenuItem windowExitItem = new("Quit");
        ToolStripMenuItem windowRefreshItem = new("Refresh");
        
        projectImportDiagramItem.Click += (s, e) =>
        {
            var dialog = new FolderBrowserDialog();
            if (dialog.ShowDialog() != DialogResult.OK)
            {
                return;
            }
            
            _diagram.ImportData(dialog.SelectedPath);
            _diagram.Components.OfType<UMLObject>().ToList().ForEach(c => OnDiagramObjectAdded(c));
        };

        projectExportDiagramItem.Click += (s, e) =>
        {
            var dialog = new FolderBrowserDialog();
            if(dialog.ShowDialog() != DialogResult.OK)
            {
                return;
            }

            Exporter ex = new();
            ex.ExportJsonNamespace(_selectedNamespace, dialog.SelectedPath);
        };
        
        diagramAddObjectItem.Click += (s, e) =>
        {
            OpenAddObjectForm(new(40, 40));
        };

        diagramAddAssociationItem.Click += (s, e) =>
        {
            
        };

        diagramAddNamespaceItem.Click += (s, e) =>
        {
            string namespaceName = Interaction.InputBox("Enter namespace name:", "New namespace", "namespace" + (_namespaces.Count + 1));
            AddNamespace(namespaceName);
            this.pbox_Diagram.Refresh();
        };

        diagramExportAsJpgItem.Click += (s, e) =>
        {
            SizeF sizeF = _diagram.CalculateCanvasSize();
            Size size = new((int)sizeF.Width, (int)sizeF.Height);
            Bitmap canvas = new Bitmap(size.Width, size.Height);
            
        };
        
        diagramGenerateCodeItem.Click += (s, e) =>
        {
            Form_GenerateCode frm = new(_selectedNamespace);
            frm.ShowDialog();
        };

        windowExitItem.Click += (s, e) =>
        {

            if (DialogResult.OK == MessageBox.Show("Are you sure you want to quit?", "Quit", MessageBoxButtons.OKCancel))
            {
                Environment.Exit(0);
            }
        };

        windowRefreshItem.Click += (s, e) =>
        {
            this.pbox_Diagram.Refresh();
            this.Refresh();
        };
        
        projectItem.DropDownItems.AddRange(new[] { projectImportDiagramItem, projectExportDiagramItem });
        diagramItem.DropDownItems.AddRange(new[] { diagramAddObjectItem, diagramAddNamespaceItem, diagramImplementInterfaceItem, diagramExportAsJpgItem, diagramGenerateCodeItem });
        windowItem.DropDownItems.AddRange(new[] { windowRefreshItem, windowExitItem });
        
        menuStrip1.Items.AddRange(new[] { projectItem, diagramItem, windowItem });
    }
    
    #region TreeNode event reactions
    
        public void OnDiagramObjectUpdated(UMLObject umlObject)
        {
            TreeNode node = this.treeView_Namespaces.Nodes.Find(umlObject.Name, true).FirstOrDefault();
            node.Text = umlObject.Name;
            node.Nodes.Clear();
            new[]
            {
                umlObject.Properties.Select(p => p.ToString()),
                umlObject.Methods.Select(m => m.ToString())
            }.ToList().ForEach(x =>
            {
                TreeNode node = new(x.ToString());
                node.Name = x.ToString();
                node.Nodes.Add(node);
            });
        }

        public void OnDiagramObjectRemoved(UMLObject umlObject)
        {
            this.treeView_Namespaces.Nodes.RemoveByKey(umlObject.Name);
        }

        public void OnDiagramObjectAdded(UMLObject umlObject)
        {
            TreeNode namespaceNode = this.treeView_Namespaces.Nodes.Find(_selectedNamespaceName, false).FirstOrDefault();
            TreeNode node = new(umlObject.Name);
            node.Name = umlObject.Name;
            
            new[]
            {
                umlObject.Properties.Select(p => p.ToString()),
                umlObject.Methods.Select(m => m.ToString())
            }.ToList().ForEach(x => node.Nodes.Add(new TreeNode(x.ToString())));
            namespaceNode?.Nodes.Add(node);
        }
    
    #endregion
    
    public void UpdateCanvas()
    {
        SizeF size = _diagram.CalculateCanvasSize();
        _diagram._canvas = new((int)size.Width + 20, (int)size.Height + 20);
    }
    
    public void AddNamespace(string name)
    {
        Namespace ns = new(name);
        
        ns.Diagram.UMLObjectAdded += OnDiagramObjectAdded;
        ns.Diagram.UMLObjectChanged += OnDiagramObjectUpdated;
        ns.Diagram.UMLObjectDeleted += OnDiagramObjectRemoved;
        var ress = this.treeView_Namespaces.Nodes.Find(name, true);
        if (ress.Length > 0)
        {
            MessageBox.Show("There is already a namespace with the same name");
            return;
        }

        TreeNode namespaceNode = new(name);
        namespaceNode.Name = name;
        
        this._namespaces.Add(ns);
        treeView_Namespaces.Nodes.Add(namespaceNode);
    }

    private void button1_Click(object sender, EventArgs e)
    {
        
    }

    private void pictureBox1_Paint(object sender, PaintEventArgs e)
    {
        e.Graphics.ScaleTransform(_pageScale, _pageScale);
        e.Graphics.TranslateTransform(pboxOffset.X, pboxOffset.Y);
        _diagram.Draw(e.Graphics);
    }

    private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
    {
        if (e.Button == MouseButtons.Left)
        {
            this.mouseDown = true;
        }

        if(e.Button == MouseButtons.Middle) 
        {
            this.dragging = true;
            dragStart = e.Location;
        }
    }

    private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
    {
        PointF diagramPos = new(
            (e.X / _pageScale) - pboxOffset.X,
            (e.Y / _pageScale) - pboxOffset.Y
        );
        Point locat = Point.Round(diagramPos);
        
        if(dragging)
        {
            float dx = (e.X - dragStart.X) / _pageScale;
            float dy = (e.Y - dragStart.Y) / _pageScale;
            
            pboxOffset.X += dx;
            pboxOffset.Y += dy;
            
            dragStart = e.Location;
            pbox_Diagram.Refresh();
        }
        
        _diagram.SelectComponent(locat);
        pbox_Diagram.Refresh();
        
        IComponent? component = _diagram.GetHoveredComponent(locat);
        if(component is null)
        {
            this.Cursor = Cursors.Default;
            return;
        }
        
        this.Cursor = Cursors.Hand;
        if (this.mouseDown)
        {
            component.Location = new(locat.X - component.Size.Width / 2, locat.Y - component.Size.Height / 2);
            this.pbox_Diagram.Refresh();
        }
    }

    private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
    {
        this.mouseDown = false;
        dragging = false;
        this.Cursor = Cursors.Default;
    }

    private void pictureBox1_MouseDoubleClick(object sender, MouseEventArgs e)
    {
        PointF diagramPos = new(
            (e.X / _pageScale) - pboxOffset.X,
            (e.Y / _pageScale) - pboxOffset.Y
        );
        Point locat = Point.Round(diagramPos);
        
        if((e.Button & MouseButtons.Left) != 0 && _diagram.GetHoveredComponent(locat) is not null)
        {
            _diagram.EditUMLObject(locat);
            pbox_Diagram.Refresh();
        }
    }

    private void pbox_Diagram_MouseClick(object sender, MouseEventArgs e)
    {
        PointF diagramPos = new(
            (e.X / _pageScale) - pboxOffset.X,
            (e.Y / _pageScale) - pboxOffset.Y
        );
        Point locat = Point.Round(diagramPos);
        
        if ((e.Button & MouseButtons.Right) != 0)
        {
            _scrollMenu.Show(this.pbox_Diagram, new(e.X, e.Y));
            
            this.pbox_Diagram.Refresh();
            this.Refresh();
        }

        if ((e.Button & MouseButtons.Left) != 0)
        {
            _scrollMenu?._menu.Close();
            _diagram.SelectComponent(locat);
            
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

        if (e.KeyCode == Keys.Control)
        {
            dragging = true;
        }
        
        pbox_Diagram.Refresh();
    }

    private void OpenAddObjectForm(Point objLocation)
    {
        Form_ManageObject frm = new(objLocation);
        if (DialogResult.OK == frm.ShowDialog())
        {
            _diagram.AddObject(frm.UmlObject.ToUMLComponent());
        }
    }

    private void treeView_Namespaces_AfterSelect(object sender, TreeViewEventArgs e)
    {
        if (e.Node.Parent is not null)
        {
            MessageBox.Show("select a namespace plz^^");
            return;
        }
        
        _selectedNamespaceName = e.Node.Text;
        label_CurrentNamespace.Text = _selectedNamespaceName;
        pbox_Diagram.Refresh();
    }

    private void Form1_KeyUp(object sender, KeyEventArgs e)
    {
        dragging = false;
    }
}