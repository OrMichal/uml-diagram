using uml_diagram.core;
using uml_diagram.interfaces;
using uml_diagram.math.enums;
using uml_diagram.math.geometries;
using uml_diagram.ui;

namespace uml_diagram.objects.uml.linkers;

public class UMLAssociationLink : ILink, IInteractable, IComponent
{
    public SizeF Size {get; set;}
    public PointF Location {get; set;}
    public IAssociable FirstObject { get; set; }
    public IAssociable SecondObject { get; set; }
    public bool DirectAssociation { get; set; }

    public UMLAssociationLink(IAssociable firstObject, IAssociable secondObject, bool direct = false)
    {
        this.FirstObject = firstObject;
        this.SecondObject = secondObject;
        this.DirectAssociation = direct;
    }
    
    public void Draw(Graphics g)
    {
        if(FirstObject is IConnectableComponent firstObject && SecondObject is IConnectableComponent secondObject)
        {
            if (DirectAssociation)
            {
                RelationshipGuidanceCouncil.DrawDirectAssociation(g, firstObject, secondObject, new SizeF(16, 16));
            }
            else {
                RelationshipGuidanceCouncil.DrawAssociation(g, firstObject, secondObject);
            }
        }
    }
    
    public void DrawSelected(Graphics g)
    {
        Pen p = DiagramSettings.LightPen;
        p.Color = Color.Yellow;
        if(FirstObject is IConnectableComponent firstObject && SecondObject is IConnectableComponent secondObject)
            g.DrawLines(DiagramSettings.LightPen, PositionGeometry.CalcRelationShipPath(firstObject, secondObject));
    }

    public bool IsCursorHovering(Point e)
    {
        return false;
    }

    public void OnDoubleClick(Point e)
    {
        
    }
}