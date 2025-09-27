using uml_diagram.extensions;
using uml_diagram.interfaces;
using uml_diagram.objects.uml.components;

namespace uml_diagram.objects.uml.linkers;

public class Linker
{
    private IImplementationTarget? _target { get; set; } = null;
    private List<ILink> _links = new();
    public event Action<ILinkable> LinkBroken;

    public Linker()
    {
        LinkBroken += OnLinkableObjectDeleted;
    }
    
    public void Link(IImplementable @interface)
    {
        if (!HasTarget()) return;
        
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
        ILink link = _links.Find(l =>
        {
            if (l is UMLImplementationLink umlImplLink)
            {
                if (umlImplLink.Interface.Guid == linkable.Guid || umlImplLink.Target.Guid == linkable.Guid)
                {
                    return true;
                }
            }

            return false;;
        });

        _links.Remove(link);

        var srcInterface = link.TryAs<UMLImplementationLink>().Interface.TryAs<UMLInterface>();
        var target = link.TryAs<UMLImplementationLink>().Target;

        if (target is UMLClass targetClass)
        {
            srcInterface?.Properties.ForEach(p => targetClass.Properties.Remove(p));
            srcInterface?.Methods.ForEach(m => targetClass.Methods.Remove(m));
        } 
        else if (target is UMLInterface targetInterface)
        {
            srcInterface?.Properties.ForEach(p => targetInterface.Properties.Remove(p));
            srcInterface?.Methods.ForEach(m => targetInterface.Methods.Remove(m));
        }
    }
    
    public void SetTarget(IImplementationTarget target) => this._target = target;
    public bool HasTarget() => _target is not null;
    public void NullifyTarget() => _target = null;
}