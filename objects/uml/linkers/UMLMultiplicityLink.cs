using uml_diagram.interfaces;
using uml_diagram.ui;

namespace uml_diagram.objects.uml.linkers;

public class UMLMultiplicityLink : ILink, IComponent, IInteractable
{
    public PointF Location { get; set; }
    public SizeF Size { get; set; }
    public IMultiplicable FirstObject { get; set; }
    public IMultiplicable SecondObject { get; set; }

    public UMLMultiplicityLink(IMultiplicable firstObject, IMultiplicable secondObject)
    {
        this.FirstObject = firstObject;
        this.SecondObject = secondObject;
    }
    
    public void Draw(Graphics g)
    {
        if (FirstObject is IConnectableComponent firstObject && SecondObject is IConnectableComponent secondObject)
        {
            RelationshipGuidanceCouncil.DrawMultiplicity(g, firstObject, secondObject);
        }
    }

    public void DrawSelected(Graphics g)
    {
        
    }

    public bool IsCursorHovering(Point e)
    {
        return false;
    }

    public void OnDoubleClick(Point e)
    {
        
    }
}