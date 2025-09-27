using uml_diagram.core;
using uml_diagram.interfaces;
using uml_diagram.objects.uml.components;

namespace uml_diagram.objects.uml.linkers;

public class UMLImplementationLink : IComponent, IInteractable, ILink
{
    public PointF Location { get; set; }
    public SizeF Size { get; set; }
    public IImplementationTarget Target { get; set; }
    public IImplementable Interface { get; set; }

    public UMLImplementationLink()
    {
        
    }

    public UMLImplementationLink(IImplementationTarget target, IImplementable @interface)
    {
        this.Target = target;
        this.Interface = @interface;

        if (this.Target is UMLClass umlClass && this.Interface is UMLInterface umlInterface)
        {
            umlClass.Properties = umlClass.Properties.Union(umlInterface.Properties).ToList();
            umlClass.Methods = umlClass.Methods.Union(umlInterface.Methods).ToList();
        }

        else if (this.Target is UMLInterface umlTargetInterface && this.Interface is UMLInterface umlSrcInterface)
        {
            umlTargetInterface.Properties = umlTargetInterface.Properties.Union(umlSrcInterface.Properties).ToList();
            umlTargetInterface.Methods = umlTargetInterface.Methods.Union(umlSrcInterface.Methods).ToList();
        }
    }
    
    public void Draw(Graphics g) 
    {
        if (this.Target is UMLClass umlClass && this.Interface is UMLInterface umlInterface)
        {
            g.DrawLine(DiagramSettings.LightPen, umlClass.Location, umlInterface.Location);
        }
        else if (this.Target is UMLInterface umlTargetInterface && this.Interface is UMLInterface umlSrcInterface)
        {
            g.DrawLine(DiagramSettings.LightPen, umlTargetInterface.Location, umlSrcInterface.Location);
        }
    }

    public bool IsCursorHovering(Point e)
    {
        return false;
    }

    public void OnDoubleClick(Point e)
    {
        
    }
}