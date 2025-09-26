using System.ComponentModel;

namespace uml_diagram;

partial class Form_ManageObject
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
        textbox_Name = new System.Windows.Forms.TextBox();
        button_AddObject = new System.Windows.Forms.Button();
        label1 = new System.Windows.Forms.Label();
        comboBox_Accessibility = new System.Windows.Forms.ComboBox();
        label2 = new System.Windows.Forms.Label();
        button_Cancel = new System.Windows.Forms.Button();
        button_AddProperty = new System.Windows.Forms.Button();
        button_AddMethod = new System.Windows.Forms.Button();
        listbox_Methods = new System.Windows.Forms.ListBox();
        listbox_Properties = new System.Windows.Forms.ListBox();
        comboBox_Stereotype = new System.Windows.Forms.ComboBox();
        lb = new System.Windows.Forms.Label();
        checkBox_Abstract = new System.Windows.Forms.CheckBox();
        SuspendLayout();
        // 
        // textbox_Name
        // 
        textbox_Name.Location = new System.Drawing.Point(92, 9);
        textbox_Name.Name = "textbox_Name";
        textbox_Name.Size = new System.Drawing.Size(184, 23);
        textbox_Name.TabIndex = 0;
        // 
        // button_AddObject
        // 
        button_AddObject.Location = new System.Drawing.Point(524, 313);
        button_AddObject.Name = "button_AddObject";
        button_AddObject.Size = new System.Drawing.Size(75, 23);
        button_AddObject.TabIndex = 1;
        button_AddObject.Text = "add object";
        button_AddObject.UseVisualStyleBackColor = true;
        button_AddObject.Click += button_AddObject_Click;
        // 
        // label1
        // 
        label1.Location = new System.Drawing.Point(12, 12);
        label1.Name = "label1";
        label1.Size = new System.Drawing.Size(46, 23);
        label1.TabIndex = 2;
        label1.Text = "Name:";
        // 
        // comboBox_Accessibility
        // 
        comboBox_Accessibility.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
        comboBox_Accessibility.FormattingEnabled = true;
        comboBox_Accessibility.Location = new System.Drawing.Point(92, 38);
        comboBox_Accessibility.Name = "comboBox_Accessibility";
        comboBox_Accessibility.Size = new System.Drawing.Size(184, 23);
        comboBox_Accessibility.TabIndex = 3;
        // 
        // label2
        // 
        label2.Location = new System.Drawing.Point(12, 41);
        label2.Name = "label2";
        label2.Size = new System.Drawing.Size(74, 23);
        label2.TabIndex = 4;
        label2.Text = "accessibility";
        // 
        // button_Cancel
        // 
        button_Cancel.Location = new System.Drawing.Point(11, 313);
        button_Cancel.Name = "button_Cancel";
        button_Cancel.Size = new System.Drawing.Size(75, 23);
        button_Cancel.TabIndex = 7;
        button_Cancel.Text = "cancel";
        button_Cancel.UseVisualStyleBackColor = true;
        button_Cancel.Click += button_Cancel_Click;
        // 
        // button_AddProperty
        // 
        button_AddProperty.Location = new System.Drawing.Point(506, 12);
        button_AddProperty.Name = "button_AddProperty";
        button_AddProperty.Size = new System.Drawing.Size(93, 23);
        button_AddProperty.TabIndex = 8;
        button_AddProperty.Text = "add property";
        button_AddProperty.UseVisualStyleBackColor = true;
        button_AddProperty.Click += button_AddProperty_Click;
        // 
        // button_AddMethod
        // 
        button_AddMethod.Location = new System.Drawing.Point(506, 149);
        button_AddMethod.Name = "button_AddMethod";
        button_AddMethod.Size = new System.Drawing.Size(93, 23);
        button_AddMethod.TabIndex = 9;
        button_AddMethod.Text = "add method";
        button_AddMethod.UseVisualStyleBackColor = true;
        button_AddMethod.Click += button_AddMethod_Click;
        // 
        // listbox_Methods
        // 
        listbox_Methods.FormattingEnabled = true;
        listbox_Methods.Location = new System.Drawing.Point(335, 178);
        listbox_Methods.Name = "listbox_Methods";
        listbox_Methods.Size = new System.Drawing.Size(264, 109);
        listbox_Methods.TabIndex = 11;
        listbox_Methods.SelectedIndexChanged += listbox_Methods_SelectedIndexChanged;
        listbox_Methods.DoubleClick += listbox_Methods_DoubleClick;
        // 
        // listbox_Properties
        // 
        listbox_Properties.FormattingEnabled = true;
        listbox_Properties.Location = new System.Drawing.Point(335, 41);
        listbox_Properties.Name = "listbox_Properties";
        listbox_Properties.Size = new System.Drawing.Size(264, 79);
        listbox_Properties.TabIndex = 10;
        listbox_Properties.SelectedIndexChanged += listbox_Properties_SelectedIndexChanged;
        listbox_Properties.DoubleClick += listbox_Properties_DoubleClick;
        // 
        // comboBox_Stereotype
        // 
        comboBox_Stereotype.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
        comboBox_Stereotype.FormattingEnabled = true;
        comboBox_Stereotype.Location = new System.Drawing.Point(92, 67);
        comboBox_Stereotype.Name = "comboBox_Stereotype";
        comboBox_Stereotype.Size = new System.Drawing.Size(184, 23);
        comboBox_Stereotype.TabIndex = 12;
        // 
        // lb
        // 
        lb.Location = new System.Drawing.Point(12, 67);
        lb.Name = "lb";
        lb.Size = new System.Drawing.Size(74, 23);
        lb.TabIndex = 13;
        lb.Text = "Stereotype:";
        // 
        // checkBox_Abstract
        // 
        checkBox_Abstract.Location = new System.Drawing.Point(12, 96);
        checkBox_Abstract.Name = "checkBox_Abstract";
        checkBox_Abstract.Size = new System.Drawing.Size(104, 24);
        checkBox_Abstract.TabIndex = 15;
        checkBox_Abstract.Text = "abstract";
        checkBox_Abstract.UseVisualStyleBackColor = true;
        checkBox_Abstract.CheckedChanged += checkBox_Abstract_CheckedChanged;
        // 
        // Form_ManageObject
        // 
        AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
        AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        ClientSize = new System.Drawing.Size(612, 345);
        Controls.Add(checkBox_Abstract);
        Controls.Add(lb);
        Controls.Add(comboBox_Stereotype);
        Controls.Add(listbox_Methods);
        Controls.Add(listbox_Properties);
        Controls.Add(button_AddMethod);
        Controls.Add(button_AddProperty);
        Controls.Add(button_Cancel);
        Controls.Add(label2);
        Controls.Add(comboBox_Accessibility);
        Controls.Add(label1);
        Controls.Add(button_AddObject);
        Controls.Add(textbox_Name);
        StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
        Text = "Form_AddObject";
        Load += Form_AddObject_Load;
        ResumeLayout(false);
        PerformLayout();
    }

    private System.Windows.Forms.CheckBox checkBox_Abstract;

    private System.Windows.Forms.ComboBox comboBox_Stereotype;
    private System.Windows.Forms.Label lb;

    private System.Windows.Forms.ListBox listbox_Methods;
    private System.Windows.Forms.ListBox listbox_Properties;

    private System.Windows.Forms.Button button_AddObject;
    private System.Windows.Forms.Button button_Cancel;
    private System.Windows.Forms.Button button_AddProperty;

    private System.Windows.Forms.TextBox textbox_Name;
    private System.Windows.Forms.Button button_AddMethod;
    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.ComboBox comboBox_Accessibility;
    private System.Windows.Forms.Label label2;

    #endregion
}