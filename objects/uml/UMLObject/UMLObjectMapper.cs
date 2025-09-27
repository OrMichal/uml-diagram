using System.Runtime.CompilerServices;
using uml_diagram.enums;
using uml_diagram.extensions;
using uml_diagram.objects.uml.components;

namespace uml_diagram.objects.uml;

public static class UMLObjectMapper
{
    public static UMLObject ToUMLComponent(this UMLObject umlObject) =>
        umlObject.Stereotype switch
        {
            "class" => new UMLClass().NewFrom(umlObject) as UMLClass,
            "interface" => new UMLInterface().NewFrom(umlObject) as UMLInterface,
            "struct" => new UMLStruct().NewFrom(umlObject) as UMLStruct,
            "record" => new UMLRecord().NewFrom(umlObject) as UMLRecord,
            "enum" => new UMLEnum().NewFrom(umlObject) as UMLEnum,
            _ => umlObject
        };
}