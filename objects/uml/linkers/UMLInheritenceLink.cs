using uml_diagram.interfaces;
using uml_diagram.ui;

namespace uml_diagram.objects.uml.linkers;

public class UMLInheritenceLink : ILink, IComponent, IInteractable
{
    public PointF Location { get; set; }
    public SizeF Size { get; set; }
    public IInheritable FirstObject { get; set; }
    public IInheritable SecondObject { get; set; }

    public UMLInheritenceLink(IInheritable firstObject, IInheritable secondObject)
    {
        this.SecondObject = secondObject;
        this.FirstObject = secondObject;
    }
    public void Draw(Graphics g)
    {
        if (FirstObject is IConnectableComponent firstObject && SecondObject is IConnectableComponent secondObject)
        {
            RelationshipGuidanceCouncil.DrawInheritence(g, firstObject, secondObject, new SizeF(16, 16));
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