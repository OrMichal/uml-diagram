using uml_diagram.enums;
using uml_diagram.objects.uml;

namespace uml_diagram;

public partial class Form_AddObjectProperty : Form
{
    public UMLObjectProperty Property = new();
    public Form_AddObjectProperty()
    {
        InitializeComponent();
        foreach (var item in UMLObjectAccessibilityExtensions.GetAllAccessibilities())
        {
            comboBox_Accessibility.Items.Add(item);
        }

        comboBox_Accessibility.SelectedItem = "public";
        comboBox_Accessibility.Refresh();
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
}