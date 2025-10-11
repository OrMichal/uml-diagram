namespace uml_diagram;

partial class Form1
{
    /// <summary>
    ///  Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    ///  Clean up any resources being used.
    /// </summary>
    /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
    protected override void Dispose(bool disposing)
    {
        if (disposing && (components != null))
        {
            components.Dispose();
        }

        base.Dispose(disposing);
    }

    #region Windows Form Designer generated code

    /// <summary>
    /// Required method for Designer support - do not modify
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
        components = new System.ComponentModel.Container();
        pbox_Diagram = new System.Windows.Forms.PictureBox();
        timer1 = new System.Windows.Forms.Timer(components);
        menuStrip1 = new System.Windows.Forms.MenuStrip();
        treeView_Namespaces = new System.Windows.Forms.TreeView();
        label_CurrentNamespace = new System.Windows.Forms.Label();
        ((System.ComponentModel.ISupportInitialize)pbox_Diagram).BeginInit();
        SuspendLayout();
        // 
        // pbox_Diagram
        // 
        pbox_Diagram.BackColor = System.Drawing.SystemColors.Control;
        pbox_Diagram.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
        pbox_Diagram.Location = new System.Drawing.Point(0, 49);
        pbox_Diagram.Name = "pbox_Diagram";
        pbox_Diagram.Size = new System.Drawing.Size(775, 389);
        pbox_Diagram.TabIndex = 0;
        pbox_Diagram.TabStop = false;
        pbox_Diagram.Paint += pictureBox1_Paint;
        pbox_Diagram.MouseClick += pbox_Diagram_MouseClick;
        pbox_Diagram.MouseDoubleClick += pictureBox1_MouseDoubleClick;
        pbox_Diagram.MouseDown += pictureBox1_MouseDown;
        pbox_Diagram.MouseMove += pictureBox1_MouseMove;
        pbox_Diagram.MouseUp += pictureBox1_MouseUp;
        // 
        // timer1
        // 
        timer1.Tick += timer1_Tick;
        // 
        // menuStrip1
        // 
        menuStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Visible;
        menuStrip1.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.HorizontalStackWithOverflow;
        menuStrip1.Location = new System.Drawing.Point(0, 0);
        menuStrip1.Name = "menuStrip1";
        menuStrip1.Size = new System.Drawing.Size(920, 24);
        menuStrip1.TabIndex = 1;
        menuStrip1.Text = "navbar";
        // 
        // treeView_Namespaces
        // 
        treeView_Namespaces.Location = new System.Drawing.Point(781, 27);
        treeView_Namespaces.Name = "treeView_Namespaces";
        treeView_Namespaces.Size = new System.Drawing.Size(139, 411);
        treeView_Namespaces.TabIndex = 2;
        treeView_Namespaces.AfterSelect += treeView_Namespaces_AfterSelect;
        // 
        // label_CurrentNamespace
        // 
        label_CurrentNamespace.Location = new System.Drawing.Point(12, 27);
        label_CurrentNamespace.Name = "label_CurrentNamespace";
        label_CurrentNamespace.Size = new System.Drawing.Size(100, 20);
        label_CurrentNamespace.TabIndex = 3;
        label_CurrentNamespace.Text = "label1";
        // 
        // Form1
        // 
        AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
        AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        BackColor = System.Drawing.Color.White;
        ClientSize = new System.Drawing.Size(920, 450);
        Controls.Add(label_CurrentNamespace);
        Controls.Add(treeView_Namespaces);
        Controls.Add(pbox_Diagram);
        Controls.Add(menuStrip1);
        MainMenuStrip = menuStrip1;
        StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
        Text = "Form1";
        ResizeEnd += Form1_ResizeEnd;
        KeyDown += Form1_KeyDown;
        KeyUp += Form1_KeyUp;
        ((System.ComponentModel.ISupportInitialize)pbox_Diagram).EndInit();
        ResumeLayout(false);
        PerformLayout();
    }

    private System.Windows.Forms.Label label_CurrentNamespace;

    private System.Windows.Forms.TreeView treeView_Namespaces;

    private System.Windows.Forms.MenuStrip menuStrip1;

    private System.Windows.Forms.Timer timer1;

    private System.Windows.Forms.PictureBox pbox_Diagram;

    #endregion
}