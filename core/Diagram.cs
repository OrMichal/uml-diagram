using uml_diagram.data_managers;
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
    public IComponent? _selectedComponent;
    
    public ILink? _currLink;
    public float _zoom = 1f;
    
    public event Action<ILinkable> LinkableObjectDeleted;
    public event Action<UMLObject> UMLObjectAdded;
    public event Action<UMLObject> UMLObjectDeleted;
    public event Action<UMLObject> UMLObjectChanged;

    
    public event Action<object, MouseEventArgs> pBoxClicked;
    
    public Diagram() 
    {
        
    }

    public void FinalizeLink(UMLObject secondObject)
    {
        if (_currLink is UMLImplementationLink implLink)
        { 
            Linker.Link(secondObject);
            return;
        }

        Linker.AddLink(_currLink switch
        {  
             UMLAssociationLink associationLink => associationLink.DirectAssociation 
                 ? new UMLAssociationLink(associationLink.FirstObject, secondObject.TryAs<IAssociable>(), true) 
                 : new UMLAssociationLink(associationLink.FirstObject, secondObject.TryAs<IAssociable>()),
             UMLAggregationLink aggregationLink => new UMLAggregationLink(aggregationLink.FirstObject, secondObject.TryAs<IAggregatable>()),
             UMLCompositionLink compositionLink => new UMLCompositionLink(compositionLink.FirstObject, secondObject.TryAs<IComposable>()),
             UMLInheritenceLink inheritenceLink => new UMLInheritenceLink(inheritenceLink.FirstObject, secondObject.TryAs<IInheritable>()),
             UMLMultiplicityLink multiplicityLink => new UMLMultiplicityLink(multiplicityLink.FirstObject, secondObject.TryAs<IMultiplicable>()),
             UMLReflexiveAssociationLink reflexiveAssociationLink => new UMLReflexiveAssociationLink(reflexiveAssociationLink.TryAs<IAssociable>())
        });
        
        DiscardCurrLink();
    }
    
    public void DiscardCurrLink() => this._currLink = null;

    public SizeF CalculateCanvasSize()
    {
        var farestXComponent = Components.MaxBy(x => x.Location.X + x.Size.Width);
        var farestYComponent = Components.MaxBy(x => x.Location.Y);

        return new SizeF(farestXComponent.Location.X + farestXComponent.Size.Width + 20,
            farestYComponent.Location.Y + farestYComponent.Size.Height);
    }
    
    public void ImportData(string folderPath)
    {
        Importer imp = new();
        if (!File.Exists(Path.Combine(folderPath, "links.json")) ||
            !File.Exists(Path.Combine(folderPath, "components.json")))
        {
            return;
        }
        
        Components = imp.GetComponentsFromJson(Path.Combine(folderPath, "components.json"));
        Linker._links = imp.GetLinksFromJson(Path.Combine(folderPath, "links.json"));
    }
    
    public void AddObject(UMLObject obj)
    {
        UMLObjectAdded?.Invoke(obj);
        Components.Add(obj);
    }
    
    public void RemoveComponent(IComponent @object) 
    {
        if (@object is not null)
        {
            UMLObjectDeleted?.Invoke(@object as UMLObject);
            Components.Remove(@object);
        }
        
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
        
        UMLObjectChanged?.Invoke(umlObject);
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