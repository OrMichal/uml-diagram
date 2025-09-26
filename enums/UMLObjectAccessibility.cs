using System.Runtime.CompilerServices;

namespace uml_diagram.enums;

public enum UMLObjectAccessibility
{
    Public,
    Private,
    Protected,
    Internal,
    Partial
}

public static class UMLObjectAccessibilityExtensions
{
    public static IEnumerable<string> GetAllAccessibilities()
    {
        foreach (var item in Enum.GetValues(typeof(UMLObjectAccessibility)))
        {
            yield return item.ToString().ToLower();
        }
    }
}