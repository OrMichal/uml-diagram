using System.ComponentModel;

namespace uml_diagram;

partial class Form_AddObject
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
        textBox1 = new System.Windows.Forms.TextBox();
        button_AddObject = new System.Windows.Forms.Button();
        label1 = new System.Windows.Forms.Label();
        comboBox1 = new System.Windows.Forms.ComboBox();
        label2 = new System.Windows.Forms.Label();
        comboBox2 = new System.Windows.Forms.ComboBox();
        label3 = new System.Windows.Forms.Label();
        button_Cancel = new System.Windows.Forms.Button();
        button_AddProperty = new System.Windows.Forms.Button();
        button_AddMethod = new System.Windows.Forms.Button();
        SuspendLayout();
        // 
        // textBox1
        // 
        textBox1.Location = new System.Drawing.Point(92, 9);
        textBox1.Name = "textBox1";
        textBox1.Size = new System.Drawing.Size(184, 23);
        textBox1.TabIndex = 0;
        // 
        // button_AddObject
        // 
        button_AddObject.Location = new System.Drawing.Point(201, 434);
        button_AddObject.Name = "button_AddObject";
        button_AddObject.Size = new System.Drawing.Size(75, 23);
        button_AddObject.TabIndex = 1;
        button_AddObject.Text = "add object";
        button_AddObject.UseVisualStyleBackColor = true;
        // 
        // label1
        // 
        label1.Location = new System.Drawing.Point(12, 12);
        label1.Name = "label1";
        label1.Size = new System.Drawing.Size(46, 23);
        label1.TabIndex = 2;
        label1.Text = "Name:";
        // 
        // comboBox1
        // 
        comboBox1.FormattingEnabled = true;
        comboBox1.Location = new System.Drawing.Point(92, 38);
        comboBox1.Name = "comboBox1";
        comboBox1.Size = new System.Drawing.Size(184, 23);
        comboBox1.TabIndex = 3;
        // 
        // label2
        // 
        label2.Location = new System.Drawing.Point(12, 41);
        label2.Name = "label2";
        label2.Size = new System.Drawing.Size(74, 23);
        label2.TabIndex = 4;
        label2.Text = "accessibility";
        // 
        // comboBox2
        // 
        comboBox2.FormattingEnabled = true;
        comboBox2.Location = new System.Drawing.Point(92, 67);
        comboBox2.Name = "comboBox2";
        comboBox2.Size = new System.Drawing.Size(184, 23);
        comboBox2.TabIndex = 5;
        // 
        // label3
        // 
        label3.Location = new System.Drawing.Point(12, 70);
        label3.Name = "label3";
        label3.Size = new System.Drawing.Size(74, 23);
        label3.TabIndex = 6;
        label3.Text = "Type:";
        // 
        // button_Cancel
        // 
        button_Cancel.Location = new System.Drawing.Point(12, 434);
        button_Cancel.Name = "button_Cancel";
        button_Cancel.Size = new System.Drawing.Size(75, 23);
        button_Cancel.TabIndex = 7;
        button_Cancel.Text = "cancel";
        button_Cancel.UseVisualStyleBackColor = true;
        // 
        // button_AddProperty
        // 
        button_AddProperty.Location = new System.Drawing.Point(183, 130);
        button_AddProperty.Name = "button_AddProperty";
        button_AddProperty.Size = new System.Drawing.Size(93, 23);
        button_AddProperty.TabIndex = 8;
        button_AddProperty.Text = "add property";
        button_AddProperty.UseVisualStyleBackColor = true;
        // 
        // button_AddMethod
        // 
        button_AddMethod.Location = new System.Drawing.Point(183, 268);
        button_AddMethod.Name = "button_AddMethod";
        button_AddMethod.Size = new System.Drawing.Size(93, 23);
        button_AddMethod.TabIndex = 9;
        button_AddMethod.Text = "add method";
        button_AddMethod.UseVisualStyleBackColor = true;
        // 
        // Form_AddObject
        // 
        AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
        AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        ClientSize = new System.Drawing.Size(288, 469);
        Controls.Add(button_AddMethod);
        Controls.Add(button_AddProperty);
        Controls.Add(button_Cancel);
        Controls.Add(label3);
        Controls.Add(comboBox2);
        Controls.Add(label2);
        Controls.Add(comboBox1);
        Controls.Add(label1);
        Controls.Add(button_AddObject);
        Controls.Add(textBox1);
        Text = "Form_AddObject";
        ResumeLayout(false);
        PerformLayout();
    }

    private System.Windows.Forms.Button button_AddObject;
    private System.Windows.Forms.ComboBox comboBox2;
    private System.Windows.Forms.Label label3;
    private System.Windows.Forms.Button button_Cancel;
    private System.Windows.Forms.Button button_AddProperty;

    private System.Windows.Forms.TextBox textBox1;
    private System.Windows.Forms.Button button_AddMethod;
    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.ComboBox comboBox1;
    private System.Windows.Forms.Label label2;

    #endregion
}