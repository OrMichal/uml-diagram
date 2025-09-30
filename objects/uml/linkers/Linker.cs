using uml_diagram.extensions;
using uml_diagram.interfaces;
using uml_diagram.objects.uml.components;
using uml_diagram.types;

namespace uml_diagram.objects.uml.linkers;

public class Linker
{
    private UMLObject? _target { get; set; } = null;
    private List<ILink> _links = new();
    public event Action<ILinkable> LinkBroken;

    public Linker()
    {
        LinkBroken += OnLinkableObjectDeleted;
    }
    
    public void Link(UMLObject @interface)
    {
        if (!HasTarget()) return;
        
        _links.ForEach(l =>
        {
            if (l is UMLImplementationLink implLink)
            {
                var targetNode = implLink.Implementations.FindChild(_target);
                if (targetNode is not null)
                {
                    var interNode = new ObservableTreeNode<UMLObject>(@interface);
                    targetNode.AddChild(interNode);
                }
            }
        });
        
        ILink link = new UMLImplementationLink(_target, @interface);
        _links.Add(link);
    }

    public void DrawLinks(Graphics g)
    {
        _links.ForEach(l =>
        {
            if(l is UMLImplementationLink umlImplLink) umlImplLink.Draw(g);
        });
    }

    public void OnLinkableObjectDeleted(ILinkable linkable)
    {
        var linkedInterface = linkable.TryAs<UMLInterface>();
        _links.ForEach(l =>
        {
            if (l is UMLImplementationLink implLink)
            {
                var linkedNode = implLink.Implementations.FindChild(linkedInterface);
                foreach (var item in linkedNode.GetReverseEnumerator())
                {
                    linkedInterface.Properties.ForEach(p => linkedNode.Value.Properties.Remove(p));
                    linkedInterface.Methods.ForEach(m => linkedNode.Value.Methods.Remove(m));
                }
            }
        });
    }
    
    public void SetTarget(UMLObject target) => this._target = target;
    public bool HasTarget() => _target is not null;
    public void NullifyTarget() => _target = null;
    public void OnNodeCreated(ObservableTreeNode<UMLObject> node)
    {
        foreach (var item in node.GetReverseEnumerator())
        {
            item.Value.Properties = item.Value.Properties.Union(node.Value.Properties).ToList();
            item.Value.Methods = item.Value.Methods.Union(node.Value.Methods).ToList();
        }
    }

    public void OnNodeDeleted(ObservableTreeNode<UMLObject> node)
    {
        foreach (var item in node.GetReverseEnumerator())
        {
            node.Value.Properties.ForEach(p => item.Value.Properties.Remove(p));
            node.Value.Methods.ForEach(m => item.Value.Methods.Remove(m));
        }
    }
}