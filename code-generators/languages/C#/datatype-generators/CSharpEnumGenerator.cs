using System.Text;
using uml_diagram.interfaces;
using uml_diagram.objects.uml.components;

namespace uml_diagram.code_generators.languages.C_.datatype_generators;

public class CSharpEnumGenerator : IGeneratesProperties, IObjectGenerator
{
        
    private UMLEnum _enum;

    public CSharpEnumGenerator(UMLEnum @enum)
    {
        this._enum = @enum;
    }

    public string GenerateHeader()
    {
        return $"{_enum.Accessibility} enum {_enum.Name}";
    }

    public string GenerateProperties()
    {
        StringBuilder sb = new();

        _enum.Properties.ToList().ForEach(p =>
        {
            sb.Append($"{p.Name},\n");
        });
        return sb.ToString();
    }
}