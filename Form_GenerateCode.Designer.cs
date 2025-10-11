using System.ComponentModel;

namespace uml_diagram;

partial class Form_GenerateCode
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
        components = new System.ComponentModel.Container();
        System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form_GenerateCode));
        label1 = new System.Windows.Forms.Label();
        label_SelectedFolder = new System.Windows.Forms.Label();
        button_BrowseFolders = new System.Windows.Forms.Button();
        imageList1 = new System.Windows.Forms.ImageList(components);
        button_Csharp = new System.Windows.Forms.Button();
        button_Typescript = new System.Windows.Forms.Button();
        button_Cpp = new System.Windows.Forms.Button();
        SuspendLayout();
        // 
        // label1
        // 
        label1.Location = new System.Drawing.Point(12, 9);
        label1.Name = "label1";
        label1.Size = new System.Drawing.Size(100, 23);
        label1.TabIndex = 0;
        label1.Text = "selected folder:";
        // 
        // label_SelectedFolder
        // 
        label_SelectedFolder.Location = new System.Drawing.Point(118, 9);
        label_SelectedFolder.Name = "label_SelectedFolder";
        label_SelectedFolder.Size = new System.Drawing.Size(670, 23);
        label_SelectedFolder.TabIndex = 1;
        label_SelectedFolder.Text = "none";
        // 
        // button_BrowseFolders
        // 
        button_BrowseFolders.Location = new System.Drawing.Point(12, 35);
        button_BrowseFolders.Name = "button_BrowseFolders";
        button_BrowseFolders.Size = new System.Drawing.Size(100, 23);
        button_BrowseFolders.TabIndex = 2;
        button_BrowseFolders.Text = "browse folders";
        button_BrowseFolders.UseVisualStyleBackColor = true;
        button_BrowseFolders.Click += button_BrowseFolders_Click;
        // 
        // imageList1
        // 
        imageList1.ColorDepth = System.Windows.Forms.ColorDepth.Depth32Bit;
        imageList1.ImageSize = new System.Drawing.Size(16, 16);
        imageList1.TransparentColor = System.Drawing.Color.Transparent;
        // 
        // button_Csharp
        // 
        button_Csharp.Image = ((System.Drawing.Image)resources.GetObject("button_Csharp.Image"));
        button_Csharp.Location = new System.Drawing.Point(12, 101);
        button_Csharp.Name = "button_Csharp";
        button_Csharp.Size = new System.Drawing.Size(100, 120);
        button_Csharp.TabIndex = 3;
        button_Csharp.Text = "C#";
        button_Csharp.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
        button_Csharp.UseVisualStyleBackColor = true;
        button_Csharp.Click += button_Csharp_Click;
        // 
        // button_Typescript
        // 
        button_Typescript.Location = new System.Drawing.Point(352, 101);
        button_Typescript.Name = "button_Typescript";
        button_Typescript.Size = new System.Drawing.Size(100, 120);
        button_Typescript.TabIndex = 4;
        button_Typescript.Text = "Typescript";
        button_Typescript.UseVisualStyleBackColor = true;
        button_Typescript.Click += button_Typescript_Click;
        // 
        // button_Cpp
        // 
        button_Cpp.Image = ((System.Drawing.Image)resources.GetObject("button_Cpp.Image"));
        button_Cpp.Location = new System.Drawing.Point(118, 101);
        button_Cpp.Name = "button_Cpp";
        button_Cpp.Size = new System.Drawing.Size(100, 120);
        button_Cpp.TabIndex = 5;
        button_Cpp.Text = "C++";
        button_Cpp.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
        button_Cpp.UseVisualStyleBackColor = true;
        button_Cpp.Click += button_Cpp_Click;
        // 
        // Form_GenerateCode
        // 
        AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
        AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        ClientSize = new System.Drawing.Size(523, 233);
        Controls.Add(button_Cpp);
        Controls.Add(button_Typescript);
        Controls.Add(button_Csharp);
        Controls.Add(button_BrowseFolders);
        Controls.Add(label_SelectedFolder);
        Controls.Add(label1);
        StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
        Text = "Form_GenerateCode";
        ResumeLayout(false);
    }

    private System.Windows.Forms.Button button_Cpp;

    private System.Windows.Forms.Button button_Typescript;

    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.Label label_SelectedFolder;
    private System.Windows.Forms.Button button_BrowseFolders;
    private System.Windows.Forms.ImageList imageList1;
    private System.Windows.Forms.Button button_Csharp;

    #endregion
}