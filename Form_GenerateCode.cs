using uml_diagram.code_generators;
using uml_diagram.core;
using uml_diagram.interfaces;

namespace uml_diagram;

public partial class Form_GenerateCode : Form
{
    private Namespace _ns;
    private string selectedFolder;
    public Form_GenerateCode()
    {
        InitializeComponent();
        CenterToParent();
    }

    public Form_GenerateCode(Namespace ns) : this()
    {
        this._ns = ns;
    }

    private void button_Csharp_Click(object sender, EventArgs e)
    {
        try
        {
            DialogResult = DialogResult.OK;

            CodeGenerator cg = new(_ns);
            cg.GenerateCsharpCode(selectedFolder);

            Close();
        }
        catch (Exception ex)
        {
            ErrorHandler.CatchError(ex);
        }
    }

    private void button_Typescript_Click(object sender, EventArgs e)
    {
        
    }

    private void button_BrowseFolders_Click(object sender, EventArgs e)
    {
        var dialog = new FolderBrowserDialog();

        if (dialog.ShowDialog() == DialogResult.OK)
        {
            selectedFolder = dialog.SelectedPath;
        }
        
        label_SelectedFolder.Text = selectedFolder;
    }

    private void button_Cpp_Click(object sender, EventArgs e)
    {
        try
        {
            DialogResult = DialogResult.OK;

            CodeGenerator cg = new(_ns);
            cg.GenerateCPPCode(selectedFolder);

            Close();
        }
        catch (Exception ex)
        {
            ErrorHandler.CatchError(ex);
        }
    }
}