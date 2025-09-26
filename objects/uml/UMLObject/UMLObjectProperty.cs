using uml_diagram.interfaces;

namespace uml_diagram.objects.uml;

public class UMLObjectProperty : IAbstractable
{
    public string Accessibility { get; set; }
    public bool Abstract { get; set; }
    public string Name { get; set; }
    public string Type { get; set; }

    private string GetAccessibilityAbbr() =>
        this.Accessibility == "public" ? "+" : this.Accessibility == "private" ? "-" : "~";

    public override string ToString() => $"{GetAccessibilityAbbr()} {Name}: {Type}";
}