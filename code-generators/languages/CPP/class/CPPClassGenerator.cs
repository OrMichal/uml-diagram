using System.Text;
using uml_diagram.interfaces;
using uml_diagram.objects.uml.components;
using uml_diagram.objects.uml.linkers;

namespace uml_diagram.code_generators.languages.C__;

public class CPPClassGenerator : IObjectGenerator
{
    private UMLClass _class;
    private List<ILink> _links;
    
    public CPPClassGenerator(UMLClass @class, List<ILink> links)
    {
        this._class = @class;
        this._links = links;
    }
    
    public string GenerateHeader()
    {
        return $"#include '{_class.Name}.h'\n";
    }

    public string GeneratePublicSection()
    {
        StringBuilder sb = new();

        var publicMethods = _class.Methods.Where(p => p.Accessibility == "public");
        
        if (!publicMethods.Any()) return "";
        
        publicMethods.ToList().ForEach(m =>
        {
            string paramss = m.Parameters.Any() ?  m.Parameters
                    .Select(mp => $"{mp.Type} {mp.Name}")
                    .Aggregate((m1, m2) => $"{m1}, {m2}") 
                : "";
            
            sb.Append($"{m.Type} {_class.Name}::{m.Name}({paramss}) {"{"}\n");
            sb.Append($"\tthrow std::logic_error('Not implemented yet');\n");
            sb.Append("}\n");
        });
        
        return sb.ToString();
    }

    public string GeneratePrivateSection()
    {
        StringBuilder sb = new();

        var publicProps = _class.Properties.Where(p => p.Accessibility == "private");
        var publicMethods = _class.Methods.Where(p => p.Accessibility == "private");
        
        if (!publicMethods.Any()) return "";
        
        publicMethods.ToList().ForEach(m =>
        {
            string paramss = m.Parameters.Any() ?  m.Parameters
                    .Select(mp => $"{mp.Type} {mp.Name}")
                    .Aggregate((m1, m2) => $"{m1}, {m2}") 
                : "";
            
            sb.Append($"{m.Type} {_class.Name}::{m.Name}({paramss}) {"{"}\n");
            sb.Append($"\tthrow std::logic_error('Not implemented yet');\n");
            sb.Append("}\n");
        });
        
        return sb.ToString();
    }
}