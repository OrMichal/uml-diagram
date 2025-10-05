using uml_diagram.core;
using uml_diagram.interfaces;
using uml_diagram.math.geometries;
using uml_diagram.ui;

namespace uml_diagram.objects.uml.linkers;

public class UMLReflexiveAssociationLink : ILink, IComponent, IInteractable
{
    public SizeF Size {get; set;}
    public PointF Location {get; set;}
    public IAssociable FirstObject { get; set; }

    public UMLReflexiveAssociationLink(IAssociable firstObject)
    {
        this.FirstObject = firstObject;
    }
    
    public void Draw(Graphics g)
    {
        if(FirstObject is IConnectableComponent firstObject) 
        {
            RelationshipGuidanceCouncil.DrawReflexiveAssociation(g, firstObject);
        }
    }
    
    public void DrawSelected(Graphics g)
    {
        if(FirstObject is IConnectableComponent firstObject) 
        {
            RelationshipGuidanceCouncil.DrawReflexiveAssociation(g, firstObject);
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