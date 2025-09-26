using uml_diagram.enums;
using uml_diagram.objects.uml;

namespace uml_diagram;

public partial class Form_AddObject : Form
{
    public UMLObject UmlObject = new();
    public Form_AddObject()
    {
        InitializeComponent();

        foreach (var item in UMLObjectAccessibilityExtensions.GetAllAccessibilities())
        {
            comboBox_Accessibility.Items.Add(item);
        }

        comboBox_Accessibility.SelectedItem = "public";
        comboBox_Accessibility.Refresh();

        foreach (var item in UMLObjectStereotypeExtensions.GetAllStereotypes())
        {
            comboBox_Stereotype.Items.Add(item);
        }

        comboBox_Stereotype.SelectedItem = "class";
        comboBox_Stereotype.Refresh();
    }

    public Form_AddObject(Point location): this()
    {
        this.UmlObject.Location = location;
    }

    private void button_AddProperty_Click(object sender, EventArgs e)
    {
        Form_AddObjectProperty frm = new();
        if (DialogResult.OK == frm.ShowDialog())
        {
            UmlObject.Properties.Add(frm.Property);

            listbox_Properties.Items.Add(frm.Property.ToString());
            listbox_Properties.Refresh();
        }
    }

    private void button_AddMethod_Click(object sender, EventArgs e)
    {
        Form_AddObjectMethod frm = new();
        if (DialogResult.OK == frm.ShowDialog())
        {
            UmlObject.Methods.Add(frm.Method);
            listbox_Methods.Items.Add(frm.Method.ToString());
            listbox_Methods.Refresh();
        }
    }

    private void listbox_Properties_SelectedIndexChanged(object sender, EventArgs e)
    {
    }

    private void listbox_Methods_SelectedIndexChanged(object sender, EventArgs e)
    {
    }

    private void button_Cancel_Click(object sender, EventArgs e)
    {
        DialogResult = DialogResult.Cancel;
        Close();
    }

    private void button_AddObject_Click(object sender, EventArgs e)
    {
        UmlObject.Name = (string)textbox_Name.Text;
        UmlObject.Stereotype = comboBox_Stereotype.SelectedItem.ToString();
        UmlObject.Accessibility = comboBox_Accessibility.SelectedItem.ToString();
        
        DialogResult = DialogResult.OK;
        Close();
    }

    private void listbox_Properties_DoubleClick(object sender, EventArgs e)
    {
        
    }

    private void Form_AddObject_Load(object sender, EventArgs e)
    {
        
    }
}