using System.ComponentModel;

namespace uml_diagram;

partial class Form_RelationshipPicker
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
        button_Association = new System.Windows.Forms.Button();
        button_DirectAssociation = new System.Windows.Forms.Button();
        button_ReflexiveAssociation = new System.Windows.Forms.Button();
        button_Multiplicity = new System.Windows.Forms.Button();
        button_Realization = new System.Windows.Forms.Button();
        button_Inheritance = new System.Windows.Forms.Button();
        button_Composition = new System.Windows.Forms.Button();
        button_Aggregation = new System.Windows.Forms.Button();
        button_Cancel = new System.Windows.Forms.Button();
        SuspendLayout();
        // 
        // button_Association
        // 
        button_Association.Location = new System.Drawing.Point(12, 12);
        button_Association.Name = "button_Association";
        button_Association.Size = new System.Drawing.Size(137, 161);
        button_Association.TabIndex = 0;
        button_Association.Text = "Association";
        button_Association.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
        button_Association.UseVisualStyleBackColor = true;
        button_Association.Click += button_Association_Click;
        button_Association.Paint += button_Association_Paint;
        // 
        // button_DirectAssociation
        // 
        button_DirectAssociation.Location = new System.Drawing.Point(155, 12);
        button_DirectAssociation.Name = "button_DirectAssociation";
        button_DirectAssociation.Size = new System.Drawing.Size(137, 161);
        button_DirectAssociation.TabIndex = 1;
        button_DirectAssociation.Text = "Direct Association";
        button_DirectAssociation.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
        button_DirectAssociation.UseVisualStyleBackColor = true;
        button_DirectAssociation.Click += button_DirectAssociation_Click;
        button_DirectAssociation.Paint += button_DirectAssociation_Paint;
        // 
        // button_ReflexiveAssociation
        // 
        button_ReflexiveAssociation.Location = new System.Drawing.Point(298, 12);
        button_ReflexiveAssociation.Name = "button_ReflexiveAssociation";
        button_ReflexiveAssociation.Size = new System.Drawing.Size(137, 161);
        button_ReflexiveAssociation.TabIndex = 2;
        button_ReflexiveAssociation.Text = "Reflexive Association";
        button_ReflexiveAssociation.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
        button_ReflexiveAssociation.UseVisualStyleBackColor = true;
        button_ReflexiveAssociation.Click += button_ReflexiveAssociation_Click;
        button_ReflexiveAssociation.Paint += button_ReflexiveAssociation_Paint;
        // 
        // button_Multiplicity
        // 
        button_Multiplicity.Location = new System.Drawing.Point(441, 12);
        button_Multiplicity.Name = "button_Multiplicity";
        button_Multiplicity.Size = new System.Drawing.Size(137, 161);
        button_Multiplicity.TabIndex = 3;
        button_Multiplicity.Text = "Multiplicity";
        button_Multiplicity.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
        button_Multiplicity.UseVisualStyleBackColor = true;
        button_Multiplicity.Click += button_Multiplicity_Click;
        button_Multiplicity.Paint += button_Multiplicity_Paint;
        // 
        // button_Realization
        // 
        button_Realization.Location = new System.Drawing.Point(441, 179);
        button_Realization.Name = "button_Realization";
        button_Realization.Size = new System.Drawing.Size(137, 161);
        button_Realization.TabIndex = 7;
        button_Realization.Text = "Realization";
        button_Realization.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
        button_Realization.UseVisualStyleBackColor = true;
        button_Realization.Click += button_Realization_Click_1;
        button_Realization.Paint += button_Realization_Paint;
        // 
        // button_Inheritance
        // 
        button_Inheritance.Location = new System.Drawing.Point(298, 179);
        button_Inheritance.Name = "button_Inheritance";
        button_Inheritance.Size = new System.Drawing.Size(137, 161);
        button_Inheritance.TabIndex = 6;
        button_Inheritance.Text = "Inheritance";
        button_Inheritance.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
        button_Inheritance.UseVisualStyleBackColor = true;
        button_Inheritance.Click += button_Inheritance_Click;
        button_Inheritance.Paint += button_Inheritance_Paint;
        // 
        // button_Composition
        // 
        button_Composition.Location = new System.Drawing.Point(155, 179);
        button_Composition.Name = "button_Composition";
        button_Composition.Size = new System.Drawing.Size(137, 161);
        button_Composition.TabIndex = 5;
        button_Composition.Text = "Composition";
        button_Composition.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
        button_Composition.UseVisualStyleBackColor = true;
        button_Composition.Click += button_Composition_Click_1;
        button_Composition.Paint += button_Composition_Paint;
        // 
        // button_Aggregation
        // 
        button_Aggregation.Location = new System.Drawing.Point(12, 179);
        button_Aggregation.Name = "button_Aggregation";
        button_Aggregation.Size = new System.Drawing.Size(137, 161);
        button_Aggregation.TabIndex = 4;
        button_Aggregation.Text = "Aggregation";
        button_Aggregation.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
        button_Aggregation.UseVisualStyleBackColor = true;
        button_Aggregation.Click += button_Aggregation_Click;
        button_Aggregation.Paint += button_Aggregation_Paint;
        // 
        // button_Cancel
        // 
        button_Cancel.Location = new System.Drawing.Point(259, 351);
        button_Cancel.Name = "button_Cancel";
        button_Cancel.Size = new System.Drawing.Size(75, 23);
        button_Cancel.TabIndex = 8;
        button_Cancel.Text = "cancel";
        button_Cancel.UseVisualStyleBackColor = true;
        button_Cancel.Click += button_Cancel_Click;
        // 
        // Form_RelationshipPicker
        // 
        AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
        AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        ClientSize = new System.Drawing.Size(593, 386);
        Controls.Add(button_Cancel);
        Controls.Add(button_Realization);
        Controls.Add(button_Inheritance);
        Controls.Add(button_Composition);
        Controls.Add(button_Aggregation);
        Controls.Add(button_Multiplicity);
        Controls.Add(button_ReflexiveAssociation);
        Controls.Add(button_DirectAssociation);
        Controls.Add(button_Association);
        StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
        Text = "Form_RelationshipPicker";
        ResumeLayout(false);
    }

    private System.Windows.Forms.Button button_Association;

    private System.Windows.Forms.Button button_DirectAssociation;
    private System.Windows.Forms.Button button_Realization;
    private System.Windows.Forms.Button button_ReflexiveAssociation;
    private System.Windows.Forms.Button button_Multiplicity;
    private System.Windows.Forms.Button button_Inheritance;
    private System.Windows.Forms.Button button_Composition;
    private System.Windows.Forms.Button button_Aggregation;

    private System.Windows.Forms.Button button_Cancel;

    #endregion
}