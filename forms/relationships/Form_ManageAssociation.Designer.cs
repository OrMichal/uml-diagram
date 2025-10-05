using System.ComponentModel;

namespace uml_diagram.forms.relationships;

partial class Form_ManageAssociation
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
        radioButton_Default = new System.Windows.Forms.RadioButton();
        label1 = new System.Windows.Forms.Label();
        radioButton_Directed = new System.Windows.Forms.RadioButton();
        label2 = new System.Windows.Forms.Label();
        printDialog1 = new System.Windows.Forms.PrintDialog();
        richTextBox_FirstObject = new System.Windows.Forms.RichTextBox();
        richTextBox_SecondObject = new System.Windows.Forms.RichTextBox();
        checkBox_Switch = new System.Windows.Forms.CheckBox();
        button_Cancel = new System.Windows.Forms.Button();
        button_Add = new System.Windows.Forms.Button();
        SuspendLayout();
        // 
        // radioButton_Default
        // 
        radioButton_Default.Location = new System.Drawing.Point(29, 36);
        radioButton_Default.Name = "radioButton_Default";
        radioButton_Default.Size = new System.Drawing.Size(104, 24);
        radioButton_Default.TabIndex = 0;
        radioButton_Default.TabStop = true;
        radioButton_Default.Text = "default";
        radioButton_Default.UseVisualStyleBackColor = true;
        radioButton_Default.CheckedChanged += radioButton_Default_CheckedChanged;
        // 
        // label1
        // 
        label1.Location = new System.Drawing.Point(12, 10);
        label1.Name = "label1";
        label1.Size = new System.Drawing.Size(112, 23);
        label1.TabIndex = 1;
        label1.Text = "Association type:";
        // 
        // radioButton_Directed
        // 
        radioButton_Directed.Location = new System.Drawing.Point(139, 36);
        radioButton_Directed.Name = "radioButton_Directed";
        radioButton_Directed.Size = new System.Drawing.Size(104, 24);
        radioButton_Directed.TabIndex = 1;
        radioButton_Directed.TabStop = true;
        radioButton_Directed.Text = "directed";
        radioButton_Directed.UseVisualStyleBackColor = true;
        radioButton_Directed.CheckedChanged += radioButton_Directed_CheckedChanged;
        // 
        // label2
        // 
        label2.Location = new System.Drawing.Point(12, 84);
        label2.Name = "label2";
        label2.Size = new System.Drawing.Size(100, 23);
        label2.TabIndex = 3;
        label2.Text = "Objects:";
        // 
        // printDialog1
        // 
        printDialog1.UseEXDialog = true;
        // 
        // richTextBox_FirstObject
        // 
        richTextBox_FirstObject.Enabled = false;
        richTextBox_FirstObject.Location = new System.Drawing.Point(29, 110);
        richTextBox_FirstObject.Name = "richTextBox_FirstObject";
        richTextBox_FirstObject.Size = new System.Drawing.Size(172, 127);
        richTextBox_FirstObject.TabIndex = 4;
        richTextBox_FirstObject.Text = "";
        // 
        // richTextBox_SecondObject
        // 
        richTextBox_SecondObject.Enabled = false;
        richTextBox_SecondObject.Location = new System.Drawing.Point(376, 110);
        richTextBox_SecondObject.Name = "richTextBox_SecondObject";
        richTextBox_SecondObject.Size = new System.Drawing.Size(172, 127);
        richTextBox_SecondObject.TabIndex = 5;
        richTextBox_SecondObject.Text = "";
        // 
        // checkBox_Switch
        // 
        checkBox_Switch.Location = new System.Drawing.Point(237, 110);
        checkBox_Switch.Name = "checkBox_Switch";
        checkBox_Switch.Size = new System.Drawing.Size(104, 24);
        checkBox_Switch.TabIndex = 6;
        checkBox_Switch.Text = "checkBox1";
        checkBox_Switch.UseVisualStyleBackColor = true;
        checkBox_Switch.CheckedChanged += checkBox_Switch_CheckedChanged;
        // 
        // button_Cancel
        // 
        button_Cancel.Location = new System.Drawing.Point(12, 257);
        button_Cancel.Name = "button_Cancel";
        button_Cancel.Size = new System.Drawing.Size(75, 23);
        button_Cancel.TabIndex = 7;
        button_Cancel.Text = "cancel";
        button_Cancel.UseVisualStyleBackColor = true;
        button_Cancel.Click += button_Cancel_Click;
        // 
        // button_Add
        // 
        button_Add.Location = new System.Drawing.Point(488, 257);
        button_Add.Name = "button_Add";
        button_Add.Size = new System.Drawing.Size(75, 23);
        button_Add.TabIndex = 8;
        button_Add.Text = "add";
        button_Add.UseVisualStyleBackColor = true;
        button_Add.Click += button_Add_Click;
        // 
        // Form_ManageAssociation
        // 
        AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
        AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        ClientSize = new System.Drawing.Size(575, 292);
        Controls.Add(button_Add);
        Controls.Add(button_Cancel);
        Controls.Add(checkBox_Switch);
        Controls.Add(richTextBox_SecondObject);
        Controls.Add(richTextBox_FirstObject);
        Controls.Add(label2);
        Controls.Add(radioButton_Directed);
        Controls.Add(label1);
        Controls.Add(radioButton_Default);
        Text = "Form_ManageAssociation";
        Paint += Form_ManageAssociation_Paint;
        ResumeLayout(false);
    }

    private System.Windows.Forms.Button button_Cancel;
    private System.Windows.Forms.Button button_Add;

    private System.Windows.Forms.RichTextBox richTextBox_FirstObject;
    private System.Windows.Forms.CheckBox checkBox_Switch;

    private System.Windows.Forms.Label label2;
    private System.Windows.Forms.PrintDialog printDialog1;
    private System.Windows.Forms.RichTextBox richTextBox_SecondObject;

    private System.Windows.Forms.RadioButton radioButton_Default;
    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.RadioButton radioButton_Directed;

    #endregion
}