using uml_diagram.interfaces;
using uml_diagram.objects.uml;
using uml_diagram.ui;

namespace uml_diagram.core;

public class Diagram
{
    public List<IComponent> Components = new();
    
    public event Action<object, MouseEventArgs> pBoxClicked;
    
    public void AddObject(UMLObject obj)
    {
        Components.Add(obj);
    }

    public void RemoveObjectByLocation(MouseEventArgs e)
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
    }

    public IComponent? GetHoveredComponent(MouseEventArgs e)
    {
        return Components.Find(c =>
        {
            if (c is IInteractable interactable)
            {
                return interactable.IsCursorHovering(e);
            }
            
            return false;
        });
    }

    public void EditUMLObject(MouseEventArgs e)
    {
        UMLObject? umlObject = GetHoveredComponent(e) as UMLObject;

        if (umlObject is null) return;
        
        Form_ManageObject frm = new(umlObject);
        if (DialogResult.OK != frm.ShowDialog())
        {
            umlObject = frm.UmlObject;
        }
    }

    public void Draw(Graphics g)
    {
        Components.ForEach(o => o.Draw(g));
    }
}