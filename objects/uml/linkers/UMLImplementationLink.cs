using System.Drawing.Drawing2D;
using uml_diagram.core;
using uml_diagram.interfaces;
using uml_diagram.math.geometries;
using uml_diagram.objects.uml.components;
using uml_diagram.types;

namespace uml_diagram.objects.uml.linkers;

public class UMLImplementationLink : IComponent, IInteractable, ILink
{
    public PointF Location { get; set; }
    public SizeF Size { get; set; }
    public ObservableTreeNode<UMLObject> Implementations { get; set; }
    public UMLObject Target
    {
        get => Implementations.Value;
    }

    public UMLImplementationLink()
    {
        
    }

    public UMLImplementationLink(UMLObject target, UMLObject @interface)
    {
        ObservableTreeNode<UMLObject> root = new(target);
        Implementations = root;
        Implementations.Value = target;
        Implementations.AddChild(@interface);
    }
    
    public void Draw(Graphics g) 
    {
        Pen p = DiagramSettings.LightPen;
        p.DashStyle = DashStyle.Dash;
        if (this.Target is UMLClass umlClass && Target is UMLInterface umlInterface)
        {
            g.DrawLines(p, PositionGeometry.CalcRelationShipPath(umlClass, umlInterface));
        }
        else if (this.Target is UMLInterface umlTargetInterface && Target is UMLInterface umlSrcInterface)
        {
            g.DrawLines(p, PositionGeometry.CalcRelationShipPath(umlTargetInterface, umlSrcInterface));
        }
    }
    
    public void DrawSelected(Graphics g) 
    {
        Pen p = DiagramSettings.LightPen;
        p.DashStyle = DashStyle.Dash;
        if (this.Target is UMLClass umlClass && Target is UMLInterface umlInterface)
        {
            g.DrawLines(p, PositionGeometry.CalcRelationShipPath(umlClass, umlInterface));
        }
        else if (this.Target is UMLInterface umlTargetInterface && Target is UMLInterface umlSrcInterface)
        {
            g.DrawLines(p, PositionGeometry.CalcRelationShipPath(umlTargetInterface, umlSrcInterface));
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