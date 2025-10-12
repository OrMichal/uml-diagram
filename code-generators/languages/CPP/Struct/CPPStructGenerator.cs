using System.Text;
using uml_diagram.interfaces;
using uml_diagram.objects.uml.components;
using uml_diagram.objects.uml.linkers;

namespace uml_diagram.code_generators.languages.C__.Struct;

public class CPPStructGenerator
{
    private UMLStruct _struct;
    private List<ILink> _links;
    
    public CPPStructGenerator(UMLStruct @struct, List<ILink> links)
    {
        this._struct = @struct;
        this._links = links;
    }
    
    public string GenerateHeader()
    {
        return $"struct {_struct.Name} {"{"}\n";
    }

    public string GeneratePublicSection()
    {
        StringBuilder sb = new();

        var publicProps = _struct.Properties.Where(p => p.Accessibility == "public");
        
        if (!publicProps.Any()) return "";

        string ext = _struct.Abstract ? "virtual" : "";
        string suffix = _struct.Abstract ? " const = 0" : "";
        
        publicProps.ToList().ForEach(p =>
        {
            sb.Append($"\t{p.Type} {p.Name};\n");
        });
        
        return sb.ToString();
    }

    public string GeneratePrivateSection()
    {
        StringBuilder sb = new();

        var publicProps = _struct.Properties.Where(p => p.Accessibility == "private");
        
        if (!publicProps.Any()) return "";
        
        publicProps.ToList().ForEach(p =>
        {
            sb.Append($"\t{p.Type} {p.Name};\n");
        });
        sb.Append("\n");
        
        return sb.ToString();
    }
}