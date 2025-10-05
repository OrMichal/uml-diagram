using uml_diagram.interfaces;
using uml_diagram.ui;

namespace uml_diagram.objects.uml.linkers;

public class UMLAggregationLink : ILink, IComponent, IInteractable
{
    public PointF Location { get; set; }
    public SizeF Size { get; set; }
    public IAggregatable  FirstObject { get; set; }
    public IAggregatable  SecondObject { get; set; }
    
    public UMLAggregationLink(IAggregatable firstObject, IAggregatable secondObject)
    {
        this.FirstObject = firstObject;
        this.SecondObject = secondObject;
    }
    public void Draw(Graphics g)
    {
        if (FirstObject is IConnectableComponent firstObject && SecondObject is IConnectableComponent secondObject)
        {
            RelationshipGuidanceCouncil.DrawAggregation(g, firstObject, secondObject, new SizeF(16, 16));
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