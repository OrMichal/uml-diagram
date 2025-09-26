using System.ComponentModel;

namespace uml_diagram;

partial class Form_AddObjectMethodParameter
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
        label1 = new System.Windows.Forms.Label();
        textBox_Type = new System.Windows.Forms.TextBox();
        label2 = new System.Windows.Forms.Label();
        textBox_Name = new System.Windows.Forms.TextBox();
        button_Add = new System.Windows.Forms.Button();
        button_Cancel = new System.Windows.Forms.Button();
        SuspendLayout();
        // 
        // label1
        // 
        label1.Location = new System.Drawing.Point(12, 9);
        label1.Name = "label1";
        label1.Size = new System.Drawing.Size(100, 23);
        label1.TabIndex = 0;
        label1.Text = "Type";
        // 
        // textBox_Type
        // 
        textBox_Type.Location = new System.Drawing.Point(12, 35);
        textBox_Type.Name = "textBox_Type";
        textBox_Type.Size = new System.Drawing.Size(100, 23);
        textBox_Type.TabIndex = 1;
        // 
        // label2
        // 
        label2.Location = new System.Drawing.Point(143, 9);
        label2.Name = "label2";
        label2.Size = new System.Drawing.Size(100, 23);
        label2.TabIndex = 2;
        label2.Text = "Name";
        // 
        // textBox_Name
        // 
        textBox_Name.Location = new System.Drawing.Point(143, 35);
        textBox_Name.Name = "textBox_Name";
        textBox_Name.Size = new System.Drawing.Size(113, 23);
        textBox_Name.TabIndex = 3;
        // 
        // button_Add
        // 
        button_Add.Location = new System.Drawing.Point(159, 101);
        button_Add.Name = "button_Add";
        button_Add.Size = new System.Drawing.Size(97, 23);
        button_Add.TabIndex = 4;
        button_Add.Text = "add parameter";
        button_Add.UseVisualStyleBackColor = true;
        button_Add.Click += button_Add_Click;
        // 
        // button_Cancel
        // 
        button_Cancel.Location = new System.Drawing.Point(12, 101);
        button_Cancel.Name = "button_Cancel";
        button_Cancel.Size = new System.Drawing.Size(75, 23);
        button_Cancel.TabIndex = 5;
        button_Cancel.Text = "cancel";
        button_Cancel.UseVisualStyleBackColor = true;
        button_Cancel.Click += button_Cancel_Click;
        // 
        // Form_AddObjectMethodParameter
        // 
        AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
        AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        ClientSize = new System.Drawing.Size(268, 136);
        Controls.Add(button_Cancel);
        Controls.Add(button_Add);
        Controls.Add(textBox_Name);
        Controls.Add(label2);
        Controls.Add(textBox_Type);
        Controls.Add(label1);
        StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
        Text = "Form_AddObjectMethodParameter";
        ResumeLayout(false);
        PerformLayout();
    }

    private System.Windows.Forms.Button button_Add;
    private System.Windows.Forms.Button button_Cancel;

    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.TextBox textBox_Type;
    private System.Windows.Forms.Label label2;
    private System.Windows.Forms.TextBox textBox_Name;

    #endregion
}