using uml_diagram.interfaces;

namespace uml_diagram.objects.uml;

public class UMLObjectMethod : IAbstractable
{
    public string Accessibility { get; set; }
    
    public bool Abstract { get; set; } = false;
    public string Name { get; set; }
    public string Type { get; set; }

    public List<UMLObjectMethodParameter> Parameters { get; set; } = new();

    private string GetAccessibilityAbbr() =>
        this.Accessibility == "public" ? "+" : this.Accessibility == "private" ? "-" : "~";

    public override string ToString() => $"{GetAccessibilityAbbr()} {Name}({string.Join(", ", Parameters.Select(p => $"{p.Name}: {p.Type}"))}): {Type}";
}