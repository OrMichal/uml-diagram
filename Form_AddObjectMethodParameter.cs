using uml_diagram.objects.uml;

namespace uml_diagram;

public partial class Form_AddObjectMethodParameter : Form
{
    public UMLObjectMethodParameter Parameter = new();
    public Form_AddObjectMethodParameter()
    {
        InitializeComponent();
    }

    public Form_AddObjectMethodParameter(UMLObjectMethodParameter parameter) : this()
    {
        this.Parameter = parameter;
    }

    private void button_Add_Click(object sender, EventArgs e)
    {
        Parameter.Type = textBox_Type.Text;
        Parameter.Name = textBox_Name.Text;
        
        DialogResult = DialogResult.OK;
        Close();
    }

    private void button_Cancel_Click(object sender, EventArgs e)
    {
        DialogResult = DialogResult.Cancel;
        Close();
    }
}