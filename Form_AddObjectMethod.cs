using uml_diagram.enums;
using uml_diagram.objects.uml;

namespace uml_diagram;

public partial class Form_AddObjectMethod : Form
{
    public UMLObjectMethod Method = new();
    public Form_AddObjectMethod()
    {
        InitializeComponent();

        var fileds = UMLObjectAccessibilityExtensions.GetAllAccessibilities();
        foreach (var acc in fileds)
        {
            comboBox_Accessibility.Items.Add(acc.ToString().ToLower());
        }
        comboBox_Accessibility.Refresh();
        comboBox_Accessibility.SelectedItem = "public";
    }

    private void button_Add_Click(object sender, EventArgs e)
    {
        Method.Accessibility = comboBox_Accessibility.SelectedItem.ToString();
        Method.Name = (string)textBox_Name.Text;
        Method.Type = (string)textBox_Type.Text;

        DialogResult = DialogResult.OK;
        Close();
    }

    private void button_Cancel_Click(object sender, EventArgs e)
    {
        DialogResult = DialogResult.Cancel;
        Close();
    }

    private void listBox_Parameters_SelectedIndexChanged(object sender, EventArgs e)
    {
        
    }

    private void button_AddParam_Click(object sender, EventArgs e)
    {
        Form_AddObjectMethodParameter frm = new();
        if (DialogResult.OK == frm.ShowDialog())
        {
            Method.Parameters.Add(frm.Parameter);
            listBox_Parameters.Items.Add(frm.Parameter.ToString());
            listBox_Parameters.Refresh();
        }
    }
}