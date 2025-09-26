namespace uml_diagram.enums;

public enum UMLObjectStereotype
{
    Class,
    Interface,
    Struct,
    Enum,
    Record,
    Abstract
}

public static class UMLObjectStereotypeExtensions
{
    public static IEnumerable<string> GetAllStereotypes()
    {
        foreach (var item in Enum.GetValues(typeof(UMLObjectStereotype)))
        {
            yield return item.ToString().ToLower();
        }
    }
}