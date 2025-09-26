using System.ComponentModel;

namespace uml_diagram;

partial class Form_ManageObjectProperty
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
        comboBox_Accessibility = new System.Windows.Forms.ComboBox();
        label2 = new System.Windows.Forms.Label();
        textBox_Type = new System.Windows.Forms.TextBox();
        label3 = new System.Windows.Forms.Label();
        textBox_Name = new System.Windows.Forms.TextBox();
        button_Add = new System.Windows.Forms.Button();
        button_Cancel = new System.Windows.Forms.Button();
        checkBox_Abstract = new System.Windows.Forms.CheckBox();
        SuspendLayout();
        // 
        // label1
        // 
        label1.Location = new System.Drawing.Point(12, 9);
        label1.Name = "label1";
        label1.Size = new System.Drawing.Size(100, 23);
        label1.TabIndex = 0;
        label1.Text = "Accessibility";
        // 
        // comboBox_Accessibility
        // 
        comboBox_Accessibility.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
        comboBox_Accessibility.FormattingEnabled = true;
        comboBox_Accessibility.Location = new System.Drawing.Point(12, 35);
        comboBox_Accessibility.Name = "comboBox_Accessibility";
        comboBox_Accessibility.Size = new System.Drawing.Size(111, 23);
        comboBox_Accessibility.TabIndex = 1;
        // 
        // label2
        // 
        label2.Location = new System.Drawing.Point(152, 9);
        label2.Name = "label2";
        label2.Size = new System.Drawing.Size(100, 23);
        label2.TabIndex = 2;
        label2.Text = "Type";
        // 
        // textBox_Type
        // 
        textBox_Type.Location = new System.Drawing.Point(152, 35);
        textBox_Type.Name = "textBox_Type";
        textBox_Type.Size = new System.Drawing.Size(100, 23);
        textBox_Type.TabIndex = 3;
        // 
        // label3
        // 
        label3.Location = new System.Drawing.Point(283, 9);
        label3.Name = "label3";
        label3.Size = new System.Drawing.Size(100, 23);
        label3.TabIndex = 4;
        label3.Text = "Name";
        // 
        // textBox_Name
        // 
        textBox_Name.Location = new System.Drawing.Point(283, 35);
        textBox_Name.Name = "textBox_Name";
        textBox_Name.Size = new System.Drawing.Size(197, 23);
        textBox_Name.TabIndex = 5;
        // 
        // button_Add
        // 
        button_Add.Location = new System.Drawing.Point(394, 97);
        button_Add.Name = "button_Add";
        button_Add.Size = new System.Drawing.Size(86, 23);
        button_Add.TabIndex = 8;
        button_Add.Text = "add property";
        button_Add.UseVisualStyleBackColor = true;
        button_Add.Click += button1_Click;
        // 
        // button_Cancel
        // 
        button_Cancel.Location = new System.Drawing.Point(308, 97);
        button_Cancel.Name = "button_Cancel";
        button_Cancel.Size = new System.Drawing.Size(75, 23);
        button_Cancel.TabIndex = 9;
        button_Cancel.Text = "cancel";
        button_Cancel.UseVisualStyleBackColor = true;
        button_Cancel.Click += button2_Click;
        // 
        // checkBox_Abstract
        // 
        checkBox_Abstract.Location = new System.Drawing.Point(12, 73);
        checkBox_Abstract.Name = "checkBox_Abstract";
        checkBox_Abstract.Size = new System.Drawing.Size(104, 24);
        checkBox_Abstract.TabIndex = 10;
        checkBox_Abstract.Text = "abstract";
        checkBox_Abstract.UseVisualStyleBackColor = true;
        checkBox_Abstract.CheckedChanged += checkBox_Abstract_CheckedChanged;
        // 
        // Form_ManageObjectProperty
        // 
        AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
        AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        ClientSize = new System.Drawing.Size(492, 129);
        Controls.Add(checkBox_Abstract);
        Controls.Add(button_Cancel);
        Controls.Add(button_Add);
        Controls.Add(textBox_Name);
        Controls.Add(label3);
        Controls.Add(textBox_Type);
        Controls.Add(label2);
        Controls.Add(comboBox_Accessibility);
        Controls.Add(label1);
        StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
        Text = "Form_AddObjectProperty";
        ResumeLayout(false);
        PerformLayout();
    }

    private System.Windows.Forms.CheckBox checkBox_Abstract;

    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.ComboBox comboBox_Accessibility;
    private System.Windows.Forms.Label label2;
    private System.Windows.Forms.TextBox textBox_Type;
    private System.Windows.Forms.Label label3;
    private System.Windows.Forms.TextBox textBox_Name;
    private System.Windows.Forms.Button button_Add;
    private System.Windows.Forms.Button button_Cancel;

    #endregion
}