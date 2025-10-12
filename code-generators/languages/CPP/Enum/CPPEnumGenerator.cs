using System.Text;
using uml_diagram.objects.uml.components;

namespace uml_diagram.code_generators.languages.C__.Enum;

public class CPPEnumGenerator
{
    
    private UMLEnum _enum;
    
    public CPPEnumGenerator(UMLEnum @enum)
    {
        this._enum = @enum;
    }
    
    public string GenerateHeader()
    {
        return $"enum {_enum.Name} {"{"}\n";
    }

    public string GeneratePublicSection()
    {
        StringBuilder sb = new();

        var publicProps = _enum.Properties.Where(p => p.Accessibility == "public");
        
        if (!publicProps.Any()) return "";
        
        publicProps.ToList().ForEach(p =>
        {
            sb.Append($"\t{p.Name},\n");
        });
        
        return sb.ToString();
    }

    public string GeneratePrivateSection()
    {
        StringBuilder sb = new();

        var publicProps = _enum.Properties.Where(p => p.Accessibility == "private");
        
        if (!publicProps.Any()) return "";
        
        publicProps.ToList().ForEach(p =>
        {
            sb.Append($"\t{p.Name},\n");
        });
        sb.Append("\n");
        
        return sb.ToString();
    }
}