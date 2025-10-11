namespace uml_diagram.core;

public class Namespace
{
    public Diagram Diagram { get; set; }
    public string Name { get; set; }

    public Namespace(string name)
    {
        this.Name = name;
        this.Diagram = new();
    }
}