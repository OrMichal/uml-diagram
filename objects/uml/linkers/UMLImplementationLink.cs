using System.Drawing.Drawing2D;
using uml_diagram.core;
using uml_diagram.extensions;
using uml_diagram.interfaces;
using uml_diagram.math.geometries;
using uml_diagram.objects.uml.components;
using uml_diagram.types;
using uml_diagram.ui;

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

    public UMLImplementationLink(UMLObject target)
    {
        ObservableTreeNode<UMLObject> root = new(target);
        Implementations = root;
    }

    public void Draw(Graphics g)
    {
        Draw(g, null);
    }
    
    public void Draw(Graphics g, ObservableTreeNode<UMLObject>? implnode = null)
    {
        if (implnode is null)
            implnode = Implementations;

        Pen p = DiagramSettings.LightPen;
        p.DashStyle = DashStyle.Dash;

        foreach (var node in implnode.Children)
        {
            if (implnode.Value is UMLClass umlClass)
            {
                RelationshipGuidanceCouncil.DrawRealization(g, umlClass, node.Value as UMLInterface, new SizeF(16, 16));
                Draw(g, node);
            }
            else if(implnode.Value is UMLInterface umlInterface){
                RelationshipGuidanceCouncil.DrawRealization(g, umlInterface, node.Value as UMLInterface, new SizeF(16, 16));
                Draw(g, node);
            }
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