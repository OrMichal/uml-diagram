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
        ((System.ComponentModel.ISupportInitialize)pbox_Diagram).BeginInit();
        SuspendLayout();
        // 
        // pbox_Diagram
        // 
        pbox_Diagram.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
        pbox_Diagram.Location = new System.Drawing.Point(12, 12);
        pbox_Diagram.Name = "pbox_Diagram";
        pbox_Diagram.Size = new System.Drawing.Size(776, 426);
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
        // Form1
        // 
        AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
        AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        ClientSize = new System.Drawing.Size(800, 450);
        Controls.Add(pbox_Diagram);
        StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
        Text = "Form1";
        ResizeEnd += Form1_ResizeEnd;
        KeyDown += Form1_KeyDown;
        ((System.ComponentModel.ISupportInitialize)pbox_Diagram).EndInit();
        ResumeLayout(false);
    }

    private System.Windows.Forms.Timer timer1;

    private System.Windows.Forms.PictureBox pbox_Diagram;

    #endregion
}