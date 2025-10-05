using uml_diagram.core;
using uml_diagram.interfaces;
using uml_diagram.math.geometries;
using uml_diagram.objects.uml;
using uml_diagram.ui;
using uml_diagram.ui.elements;

namespace uml_diagram;

public partial class Form_RelationshipPicker : Form
{
    private UMLObject _target { get; set; }
    public ILink Link;
    public Form_RelationshipPicker()
    {
        InitializeComponent();
    }

    public Form_RelationshipPicker(UMLObject target) : this()
    {
        this._target = target;
    }

    private void button_Cancel_Click(object sender, EventArgs e)
    {
        DialogResult = DialogResult.Cancel;
        Close();
    }

    private void button_Association_Click(object sender, EventArgs e)
    {
        
    }

    private void button_DirectAssociation_Click(object sender, EventArgs e)
    {
        
    }

    private void button_ReflexiveAssociation_Click(object sender, EventArgs e)
    {
        
    }

    private void button_Multiplicity_Click(object sender, EventArgs e)
    {
        
    }

    private void button_Aggregation_Click(object sender, EventArgs e)
    {
        
    }

    private void button_Composition_Click_1(object sender, EventArgs e)
    {
        
    }

    private void button_Composition_Click(object sender, EventArgs e)
    {
        
    }

    private void button_Inheritance_Click(object sender, EventArgs e)
    {
        
    }

    private void button_Realization_Click_1(object sender, EventArgs e)
    {
        
    }

    private void button_Realization_Click(object sender, EventArgs e)
    {
        
    }

    private void button_Association_Paint(object sender, PaintEventArgs e)
    {
        UILabel mainLabel = new(new PointF(button_Association.Location.X + 10, button_Association.Location.Y + 10), "Passangers");
        UILabel secondaryLabel = new(new PointF(button_Association.Location.X + 10, button_Association.Location.Y + 70), "Airplane");
        
        mainLabel.Draw(e.Graphics);
        secondaryLabel.Draw(e.Graphics);
        RelationshipGuidanceCouncil.DrawAssociation(e.Graphics, mainLabel, secondaryLabel);
    }

    private void button_DirectAssociation_Paint(object sender, PaintEventArgs e)
    {
        UILabel mainLabel = new(new PointF(button_Association.Location.X + 20, button_Association.Location.Y + 10), "Passangers");
        UILabel secondaryLabel = new(new PointF(button_Association.Location.X + 10, button_Association.Location.Y + 70), "Airplane");
        
        mainLabel.Draw(e.Graphics);
        secondaryLabel.Draw(e.Graphics);
        RelationshipGuidanceCouncil.DrawDirectAssociation(e.Graphics, mainLabel, secondaryLabel, new SizeF(8, 8));
    }

    private void button_ReflexiveAssociation_Paint(object sender, PaintEventArgs e)
    {
        UILabel mainLabel = new(new PointF(button_Association.Location.X + 10, button_Association.Location.Y + 30), "Airplane staff");
        mainLabel.Draw(e.Graphics);
        RelationshipGuidanceCouncil.DrawReflexiveAssociation(e.Graphics, mainLabel);
    }

    private void button_Multiplicity_Paint(object sender, PaintEventArgs e)
    {
        UILabel mainLabel = new(new PointF(button_Association.Location.X + 20, button_Association.Location.Y + 10), "Passangers");
        UILabel secondaryLabel = new(new PointF(button_Association.Location.X + 10, button_Association.Location.Y + 70), "Airplane");
        
        mainLabel.Draw(e.Graphics);
        secondaryLabel.Draw(e.Graphics);
        RelationshipGuidanceCouncil.DrawMultiplicity(e.Graphics, mainLabel, secondaryLabel);
    }

    private void button_Aggregation_Paint(object sender, PaintEventArgs e)
    {
        UILabel mainLabel = new(new PointF(button_Association.Location.X + 30, button_Association.Location.Y + 10), "Library");
        UILabel secondaryLabel = new(new PointF(button_Association.Location.X + 10, button_Association.Location.Y + 70), "Books");
        
        mainLabel.Draw(e.Graphics);
        secondaryLabel.Draw(e.Graphics);
        RelationshipGuidanceCouncil.DrawAggregation(e.Graphics, mainLabel, secondaryLabel, new SizeF(8, 8));
    }

    private void button_Composition_Paint(object sender, PaintEventArgs e)
    {
        UILabel mainLabel = new(new PointF(button_Association.Location.X + 30, button_Association.Location.Y + 10), "Library");
        UILabel secondaryLabel = new(new PointF(button_Association.Location.X + 10, button_Association.Location.Y + 70), "Books");
        
        mainLabel.Draw(e.Graphics);
        secondaryLabel.Draw(e.Graphics);
        RelationshipGuidanceCouncil.DrawComposition(e.Graphics, mainLabel, secondaryLabel, new SizeF(8, 8));
    }

    private void button_Inheritance_Paint(object sender, PaintEventArgs e)
    {
        UILabel mainLabel = new(new PointF(button_Association.Location.X + 30, button_Association.Location.Y + 10), "Library");
        UILabel secondaryLabel = new(new PointF(button_Association.Location.X + 10, button_Association.Location.Y + 70), "Books");
        
        mainLabel.Draw(e.Graphics);
        secondaryLabel.Draw(e.Graphics);
        RelationshipGuidanceCouncil.DrawInheritence(e.Graphics, mainLabel, secondaryLabel, new SizeF(8, 8));
    }

    private void button_Realization_Paint(object sender, PaintEventArgs e)
    {
        UILabel mainLabel = new(new PointF(button_Association.Location.X + 30, button_Association.Location.Y + 10), "Library");
        UILabel secondaryLabel = new(new PointF(button_Association.Location.X + 10, button_Association.Location.Y + 70), "Books");
        
        mainLabel.Draw(e.Graphics);
        secondaryLabel.Draw(e.Graphics);
        RelationshipGuidanceCouncil.DrawRealization(e.Graphics, mainLabel, secondaryLabel, new SizeF(8, 8));
    }
}