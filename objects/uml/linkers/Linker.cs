using uml_diagram.extensions;
using uml_diagram.interfaces;
using uml_diagram.objects.uml.components;
using uml_diagram.types;

namespace uml_diagram.objects.uml.linkers;

public class Linker
{
    private UMLObject? _target { get; set; } = null;
    public List<ILink> _links = new();

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

    public void AddLink(ILink link)
    {
        _links.Add(link);
    }

    public void RemoveLink(ILink link)
    {
        _links.Remove(link);
    }

    public void DrawLinks(Graphics g)
    {
        _links.ForEach(l => l.Draw(g));
    }
    
    public void SetTarget(UMLObject target) => this._target = target;
    public bool HasTarget() => _target is not null;
    public void NullifyTarget() => _target = null;

    public void OnLinkableDeleted(ILinkable linkable)
    {
        if (linkable is UMLObject @object)
        {



            _links.RemoveAll(l =>
            {
                switch (l)
                {
                    case UMLAssociationLink link:
                        if (link.FirstObject is UMLObject firstObject && link.SecondObject is UMLObject secondObject)
                            return firstObject.Equals(@object) || secondObject.Equals(@object);
                        break;
                    case UMLAggregationLink link:
                        if (link.FirstObject is UMLObject firstObjectAgg &&
                            link.SecondObject is UMLObject secondObjectAgg)
                            return firstObjectAgg.Equals(@object) || secondObjectAgg.Equals(@object);
                        break;
                    case UMLCompositionLink link:
                        if (link.FirstObject is UMLObject firstObjectCompos &&
                            link.SecondObject is UMLObject secondObjectCompos)
                            return firstObjectCompos.Equals(@object) || secondObjectCompos.Equals(@object);
                        break;
                    case UMLImplementationLink link:
                        if (link.Implementations.Value.Equals(@object) ||
                            link.Implementations.FindChild(@object).Equals(@object))
                            return true;
                        break;
                    case UMLInheritenceLink link:
                        if (link.FirstObject is UMLObject firstObjInher &&
                            link.SecondObject is UMLObject secondObjInner)
                            return firstObjInher.Equals(@object) || secondObjInner.Equals(@object);
                        break;

                    case UMLMultiplicityLink link:
                        if (link.FirstObject is UMLObject firstObjMulti &&
                            link.SecondObject is UMLObject secondObjMulti)
                            return firstObjMulti.Equals(@object) || secondObjMulti.Equals(@object);
                        break;

                    case UMLReflexiveAssociationLink link:
                        if (link.FirstObject is UMLObject firstObjReflexive)
                            return firstObjReflexive.Equals(@object);
                        break;
                }

                return false;
            });
        }
    }
    
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