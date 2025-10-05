using uml_diagram.extensions;
using uml_diagram.interfaces;
using uml_diagram.objects.uml;
using uml_diagram.objects.uml.components;
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
    private IComponent? _selectedComponent;
    private ILink? _currLink;

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
        ClickMenu.AddAction("add relationship", (sender, ev) =>
        {
            Linker.SetTarget(_selectedComponent.TryAs<UMLObject>());
            Form_RelationshipPicker frm = new(_selectedComponent.TryAs<UMLObject>());
            
            if(DialogResult.OK == frm.ShowDialog())
            {
                _currLink = frm.Link;
            }
        });
    }

    public void FinalizeLink(UMLObject secondObject)
    {
        Linker.AddLink(_currLink switch
        {  
             UMLAssociationLink associationLink =>
                 new UMLAssociationLink(associationLink.FirstObject, secondObject.TryAs<IAssociable>())
        });
    }
    
    public void AddObject(UMLObject obj)
    {
        Components.Add(obj);
    }
    
    public void RemoveComponent(IComponent @object) 
    {
        if (@object is not null)
            Components.Remove(@object);
        
        if(@object is ILinkable linkable)
            LinkableObjectDeleted?.Invoke(linkable);
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
        
        RemoveComponent(component);
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

    public void SelectComponent(Point e)
    {
        _selectedComponent = GetHoveredComponent(e);
    }

    public void RemoveSelectedComponent()
    {
        if(_selectedComponent is not null)
            Components.Remove(_selectedComponent);
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
        Linker.Link(@interface.TryAs<UMLObject>());
        Linker.NullifyTarget();
    }

    public void InheritClass(IInheritable inheritable)
    {
        Linker.Link(inheritable.TryAs<UMLObject>());
        Linker.NullifyTarget();
    }

    public void Draw(Graphics g)
    {
        Components.ForEach(o =>
        {
            if (_selectedComponent == o)
            {
                o.DrawSelected(g);
            }
            else
            {
                o.Draw(g);
            }
        });
        Linker.DrawLinks(g);
    }
}