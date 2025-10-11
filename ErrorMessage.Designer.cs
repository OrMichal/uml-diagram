using System.ComponentModel;

namespace uml_diagram;

partial class ErrorMessage
{
    /// <summary>
    /// Required designer variable.
    /// </summary>
    private IContainer components = null;

    /// <summary>
    /// Clean up any resources being used.
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
        System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ErrorMessage));
        label_Message = new System.Windows.Forms.Label();
        SuspendLayout();
        // 
        // label_Message
        // 
        label_Message.Location = new System.Drawing.Point(12, 11);
        label_Message.Name = "label_Message";
        label_Message.Size = new System.Drawing.Size(522, 20);
        label_Message.TabIndex = 0;
        label_Message.Text = "message text";
        // 
        // ErrorMessage
        // 
        AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
        AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        ClientSize = new System.Drawing.Size(546, 68);
        ControlBox = false;
        Controls.Add(label_Message);
        Icon = ((System.Drawing.Icon)resources.GetObject("$this.Icon"));
        MaximizeBox = false;
        MinimizeBox = false;
        Opacity = 0.95D;
        StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
        Text = "Error message";
        TopMost = true;
        ResumeLayout(false);
    }

    private System.Windows.Forms.Label label_Message;

    #endregion
}