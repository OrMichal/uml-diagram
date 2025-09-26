using uml_diagram.objects.uml;

namespace uml_diagram;

public partial class Form_ManageObjectMethodParameter : Form
{
    public UMLObjectMethodParameter Parameter = new();
    public Form_ManageObjectMethodParameter()
    {
        InitializeComponent();
    }

    public Form_ManageObjectMethodParameter(UMLObjectMethodParameter parameter) : this()
    {
        this.Parameter = parameter;

        this.textBox_Name.Text = Parameter.Name;
        this.textBox_Type.Text = Parameter.Type;
        
        this.button_Add.Text = "change parameter";
        this.Refresh();
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