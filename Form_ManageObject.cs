using uml_diagram.core;
using uml_diagram.enums;
using uml_diagram.extensions;
using uml_diagram.objects.uml;

namespace uml_diagram;

public partial class Form_ManageObject : Form
{
    public UMLObject UmlObject = new();
    public Form_ManageObject()
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

    public Form_ManageObject(UMLObject umlObject): this()
    {
        this.button_AddObject.Text = "change object";
        
        this.UmlObject = umlObject;
        this.textbox_Name.Text = this.UmlObject.Name;
        this.comboBox_Accessibility.Text = this.UmlObject.Accessibility;
        
        comboBox_Stereotype.Hide();
        this.Controls.Add(new Label(){ Location = comboBox_Stereotype.Location, Text = umlObject.Stereotype});
        this.comboBox_Stereotype.Text = this.UmlObject.Stereotype;
        this.checkBox_Abstract.Checked = umlObject.Abstract;
        this.checkBox_Static.Checked = umlObject.Static;
        
        this.UmlObject.Methods.ForEach(m => this.listbox_Methods.Items.Add(m.ToString()));
        this.UmlObject.Properties.ForEach(p => this.listbox_Properties.Items.Add(p.ToString()));
        this.Refresh();
    }
    
    public Form_ManageObject(Point location): this()
    {
        this.UmlObject.Location = location;
    }

    private void button_AddProperty_Click(object sender, EventArgs e)
    {
        Form_ManageObjectProperty frm = new();
        if (DialogResult.OK == frm.ShowDialog())
        {
            UmlObject.Properties.Add(frm.Property);

            listbox_Properties.Items.Add(frm.Property.ToString());
            listbox_Properties.Refresh();
        }
    }

    private void button_AddMethod_Click(object sender, EventArgs e)
    {
        Form_ManageObjectMethod frm = new();
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
        if (this.listbox_Properties.Items.Count == 0 && Result.Run(() => this.listbox_Properties.SelectedIndex.ToString()) is not null) return;
        
        UMLObjectProperty property = UmlObject.Properties[this.listbox_Properties.SelectedIndex];
        Form_ManageObjectProperty frm = new(property);
        if (DialogResult.OK == frm.ShowDialog())
        {
            property = frm.Property;
            this.listbox_Properties.Items[this.listbox_Properties.SelectedIndex] = property.ToString();
        }
    }

    private void Form_AddObject_Load(object sender, EventArgs e)
    {
        
    }

    private void listbox_Methods_DoubleClick(object sender, EventArgs e)
    {
        if (this.listbox_Methods.Items.Count == 0) return;
        
        UMLObjectMethod method = UmlObject.Methods[this.listbox_Methods.SelectedIndex];
        Form_ManageObjectMethod frm = new(method);
        if (DialogResult.OK == frm.ShowDialog())
        {
            method = frm.Method;
            this.listbox_Methods.Items[this.listbox_Methods.SelectedIndex] = method.ToString();
        }
    }

    private void checkBox_Abstract_CheckedChanged(object sender, EventArgs e)
    {
        if (this.checkBox_Abstract.Checked)
        {
            this.checkBox_Static.Checked = false;
            UmlObject.Static = false;
            UmlObject.Abstract = true;
        }
    }

    private void checkBox_Unsafe_CheckedChanged(object sender, EventArgs e)
    {
        
    }

    private void listbox_Properties_KeyDown(object sender, KeyEventArgs e)
    {
        if (e.KeyCode == Keys.Delete)
        {
            UmlObject.Properties.RemoveAt(listbox_Properties.SelectedIndex);
            listbox_Properties.RemoveSelectedItem();
        }
    }

    private void listbox_Methods_KeyDown(object sender, KeyEventArgs e)
    {
        if (e.KeyCode == Keys.Delete)
        {
            UmlObject.Methods.RemoveAt(listbox_Methods.SelectedIndex);
            listbox_Methods.RemoveSelectedItem();
            
        }
    }

    private void checkBox_Static_CheckedChanged(object sender, EventArgs e)
    {
        if (this.checkBox_Static.Checked)
        {
            this.checkBox_Abstract.Checked = false;
            UmlObject.Abstract = false;
            UmlObject.Static = true;
        }
    }
}