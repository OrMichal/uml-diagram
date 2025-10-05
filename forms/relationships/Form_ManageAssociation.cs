namespace uml_diagram.forms.relationships;

public partial class Form_ManageAssociation : Form
{
    public bool DirectionToFirst = true;
    public bool Default = true;
    
    public Form_ManageAssociation()
    {
        InitializeComponent();
    }

    private void Form_ManageAssociation_Paint(object sender, PaintEventArgs e)
    {
        
    }

    private void button_Add_Click(object sender, EventArgs e)
    {
        
    }

    private void button_Cancel_Click(object sender, EventArgs e)
    {
        DialogResult = DialogResult.Cancel;
    }

    private void checkBox_Switch_CheckedChanged(object sender, EventArgs e)
    {
        DirectionToFirst = checkBox_Switch.Checked;
    }

    private void radioButton_Default_CheckedChanged(object sender, EventArgs e)
    {
        Default = true;
    }

    private void radioButton_Directed_CheckedChanged(object sender, EventArgs e)
    {
        Default = false;
    }
}