using uml_diagram.interfaces;
using uml_diagram.objects.uml;
using uml_diagram.objects.uml.linkers;
using uml_diagram.ui;

namespace uml_diagram.core;

public class Diagram
{
    public List<IComponent> Components = new();
    public ClickScrollMenu ClickMenu = new ClickScrollMenu();
    private IComponent? _lastActive = null;
    public bool implementing = false;
    public Linker Linker = new();

    public event Action<ILinkable> LinkableObjectDeleted;
    
    public event Action<object, MouseEventArgs> pBoxClicked;
    
    public Diagram() 
    {
        ClickMenu.AddAction("new object", (sender, ev) =>
        {
            Form_ManageObject frm = new Form_ManageObject(ClickMenu.Location);
            if (DialogResult.OK == frm.ShowDialog())
            {
                var a = frm.UmlObject.ToUMLComponent();
                AddObject(a);
            }
        });
        ClickMenu.AddAction("remove object", (sender, ev) =>
        {
            RemoveObjectByLocation(ClickMenu.Location);
        });
        ClickMenu.AddAction("edit object", (sender, ev) =>
        {
            EditUMLObject(ClickMenu.Location);
        });
        ClickMenu.AddAction("implement interface", (sender, ev) =>
        {
            if(GetHoveredComponent(ClickMenu.Location) is IImplementationTarget target) Linker.SetTarget(target);
        });

        LinkableObjectDeleted += Linker.OnLinkableObjectDeleted;
    }
    
    public void AddObject(UMLObject obj)
    {
        Components.Add(obj);
    }

    public void RemoveObjectByLocation(Point e)
    {
        IComponent? component = Components.Find(c => 
        {
            if (c is UMLObject umlObject)
            {
                return umlObject.IsCursorHovering(e);
            }

            return false;
        });
        
        if (component is not null)
            Components.Remove(component);

        if (component is ILinkable linkable)
        {
            LinkableObjectDeleted?.Invoke(linkable);
        }
    }

    public IComponent? GetHoveredComponent(Point e)
    {
        var res = Components.Find(c =>
        {
            if (c is IInteractable interactable)
            {
                return interactable.IsCursorHovering(e);
            }
            
            return false;
        });
        
        this._lastActive = res;
        return res;
    }

    public void EditUMLObject(Point e)
    {
        UMLObject? umlObject = GetHoveredComponent(e) as UMLObject;

        if (umlObject is null) return;
        
        Form_ManageObject frm = new(umlObject);
        if (DialogResult.OK != frm.ShowDialog())
        {
            umlObject = frm.UmlObject;
        }
    }

    public void ImplementInterface(IImplementable @interface)
    {
        Linker.Link(@interface);
        Linker.NullifyTarget();
    }

    public void Draw(Graphics g)
    {
        Components.ForEach(o => o.Draw(g));
        Linker.DrawLinks(g);
    }
}