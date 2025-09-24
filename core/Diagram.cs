using uml_diagram.objects.uml;

namespace uml_diagram.core;

public class Diagram
{
    public List<UMLObject> UmlObjects = new();
    
    public void AddObject(UMLObject obj)
    {
        UmlObjects.Add(obj);
    }

    public void Draw(Graphics g)
    {
        UmlObjects.ForEach(o => o.Draw(g));
    }
}