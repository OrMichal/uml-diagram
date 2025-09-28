using uml_diagram.enums;
using uml_diagram.extensions;
using uml_diagram.objects.uml;

namespace uml_diagram;

public partial class Form_ManageObjectMethod : Form
{
    public UMLObjectMethod Method = new();
    public Form_ManageObjectMethod()
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

    public Form_ManageObjectMethod(UMLObjectMethod method): this()
    {
        this.Method = method;

        this.comboBox_Accessibility.Text = this.Method.Accessibility;
        this.textBox_Name.Text = this.Method.Name;
        this.textBox_Type.Text = this.Method.Type;

        this.Method.Parameters.ForEach(p => this.listBox_Parameters.Items.Add(p.ToString()));

        this.button_Add.Text = "change method";
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
        Form_ManageObjectMethodParameter frm = new();
        if (DialogResult.OK == frm.ShowDialog())
        {
            Method.Parameters.Add(frm.Parameter);
            listBox_Parameters.Items.Add(frm.Parameter.ToString());
            listBox_Parameters.Refresh();
        }
    }

    private void listBox_Parameters_DoubleClick(object sender, EventArgs e)
    {
        if(this.listBox_Parameters.Items.Count == 0) return;
        
        UMLObjectMethodParameter param = Method.Parameters[this.listBox_Parameters.SelectedIndex];
        Form_ManageObjectMethodParameter frm = new(param);
        if(DialogResult.OK == frm.ShowDialog())
        {
            param = frm.Parameter;
            this.listBox_Parameters.Items[this.listBox_Parameters.SelectedIndex] = param.ToString();
        }
    }

    private void checkBox_Abstract_CheckedChanged(object sender, EventArgs e)
    {
        Method.Abstract = this.checkBox_Abstract.Checked;
    }

    private void listBox_Parameters_KeyDown(object sender, KeyEventArgs e)
    {
        if(e.KeyCode == Keys.Delete) 
        {
            Method.Parameters.RemoveAt(listBox_Parameters.SelectedIndex);
            listBox_Parameters.RemoveSelectedItem();
        }
    }
}