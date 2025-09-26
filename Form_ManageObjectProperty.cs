using uml_diagram.enums;
using uml_diagram.objects.uml;

namespace uml_diagram;

public partial class Form_ManageObjectProperty : Form
{
    public UMLObjectProperty Property = new();
    public Form_ManageObjectProperty()
    {
        InitializeComponent();
        foreach (var item in UMLObjectAccessibilityExtensions.GetAllAccessibilities())
        {
            comboBox_Accessibility.Items.Add(item);
        }

        comboBox_Accessibility.SelectedItem = "public";
        comboBox_Accessibility.Refresh();
    }

    public Form_ManageObjectProperty(UMLObjectProperty property): this()
    {
        this.Property = property;
        
        this.textBox_Name.Text = property.Name;
        this.textBox_Type.Text = property.Type;
        this.comboBox_Accessibility.Text = property.Accessibility;

        this.button_Add.Text = "change property";
    }

    // add button
    private void button1_Click(object sender, EventArgs e)
    {
        Property.Name = (string)textBox_Name.Text;
        Property.Type = (string)textBox_Type.Text;
        Property.Accessibility = comboBox_Accessibility.SelectedItem.ToString();
        
        DialogResult = DialogResult.OK;
        Close();
    }

    // cancel button
    private void button2_Click(object sender, EventArgs e)
    {
        DialogResult = DialogResult.Cancel;
        Close();
    }

    private void checkBox_Abstract_CheckedChanged(object sender, EventArgs e)
    {
        Property.Abstract = this.checkBox_Abstract.Checked;
    }
}