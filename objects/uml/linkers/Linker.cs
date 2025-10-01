using uml_diagram.extensions;
using uml_diagram.interfaces;
using uml_diagram.objects.uml.components;
using uml_diagram.types;

namespace uml_diagram.objects.uml.linkers;

public class Linker
{
    private UMLObject? _target { get; set; } = null;
    private List<ILink> _links = new();

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
                    interNode.NodeAdded += OnNodeCreated;
                    interNode.NodeChanged += OnNodeChanged;
                    interNode.NodeRemoved += OnNodeDeleted;
                    
                    targetNode.AddChild(interNode);
                }
            }
        });
        
        UMLImplementationLink link = new UMLImplementationLink(_target);
        link.Implementations.NodeAdded += OnNodeCreated;
        link.Implementations.NodeChanged += OnNodeChanged;
        link.Implementations.NodeRemoved += OnNodeDeleted;
        _links.Add(link);
        link.Implementations.AddChild(@interface);
    }

    public void DrawLinks(Graphics g)
    {
        _links.ForEach(l => l.Draw(g));
    }
    
    public void SetTarget(UMLObject target) => this._target = target;
    public bool HasTarget() => _target is not null;
    public void NullifyTarget() => _target = null;
    public void OnNodeCreated(ObservableTreeNode<UMLObject> node)
    {
        var items = node.GetReverseEnumerator().ToList();
        foreach(var item in items)
        {
            item.Value.Properties.UnionWith(node.Value.Properties);
            item.Value.Methods.UnionWith(node.Value.Methods);

        }
        int c = 0;
    }

    public void OnNodeDeleted(ObservableTreeNode<UMLObject> node)
    {
        List<ObservableTreeNode<UMLObject>> items = node.GetReverseEnumerator().ToList();
        for(int i = 0; i < items.Count; i++)
        {
            items[i].Value.Properties.Except(node.Value.Properties).ToList();
            items[i].Value.Methods.Except(node.Value.Methods).ToList();
        }
    }
    
    public void OnNodeChanged(ObservableTreeNode<UMLObject> node)
    {
        OnNodeDeleted(node);
        OnNodeCreated(node);
    }
}