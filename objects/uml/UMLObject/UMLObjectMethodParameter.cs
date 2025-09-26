namespace uml_diagram.objects.uml;

public class UMLObjectMethodParameter
{
    public string Name { get; set; }
    public string Type { get; set; }

    public override string ToString() => $"{Name}: {Type}";
}