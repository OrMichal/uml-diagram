using uml_diagram.interfaces;

namespace uml_diagram.objects.uml;

public sealed class UMLObject : IDrawable, IInteractable
{
    public int Stereotype { get; set; }
    public string Name { get; set; }
    public List<UMLObjectProperty> Properties { get; set; }
    public List<UMLObjectMethod> Methods { get; set; }
    
    public Point Location { get; set; }
    public Size Size { get; set; }

    public bool IsCursorHovering(MouseEventArgs e)
    {
        return true;
    }

    public void OnDoubleClick(MouseEventArgs e)
    {
        
    }

    public void Draw(Graphics g)
    {
        
    }
}