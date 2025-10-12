using System.Text;
using uml_diagram.interfaces;
using uml_diagram.objects.uml.components;
using uml_diagram.objects.uml.linkers;

namespace uml_diagram.code_generators.languages.CPP.Interface;

public class CPPInterfaceGenerator
{
    private UMLInterface _interface;
    private List<ILink> _links;
    
    public CPPInterfaceGenerator(UMLInterface @interface, List<ILink> links)
    {
        this._interface = @interface;
        this._links = links;
    }
    
    public string GenerateHeader()
    {
        return $"class {_interface.Name} {GenerateDependencies()} {"{"}\n";
    }

    public string GeneratePublicSection()
    {
        StringBuilder sb = new();

        var publicProps = _interface.Properties.Where(p => p.Accessibility == "public");
        var publicMethods = _interface.Methods.Where(p => p.Accessibility == "public");
        
        if (!publicProps.Any() && !publicMethods.Any()) return "";

        string ext = _interface.Abstract ? "virtual" : "";
        string suffix = _interface.Abstract ? " const = 0" : "";
        
        sb.Append("\tpublic:\n");
        publicProps.ToList().ForEach(p =>
        {
            sb.Append($"\t\t{p.Type} {p.Name};\n");
        });
        
        publicMethods.ToList().ForEach(m =>
        {
            string paramss = m.Parameters.Any() ?  m.Parameters
                    .Select(mp => $"{mp.Type} {mp.Name}")
                    .Aggregate((m1, m2) => $"{m1}, {m2}") 
                : "";
            
            sb.Append($"\t\t{ext} {m.Type} {m.Name}({paramss}){suffix};\n");
        });
        
        return sb.ToString();
    }

    public string GeneratePrivateSection()
    {
        StringBuilder sb = new();

        var publicProps = _interface.Properties.Where(p => p.Accessibility == "private");
        var publicMethods = _interface.Methods.Where(p => p.Accessibility == "private");
        
        if (!publicProps.Any() && !publicMethods.Any()) return "";
        
        sb.Append("\tprivate:\n");
        publicProps.ToList().ForEach(p =>
        {
            sb.Append($"\t\t{p.Type} {p.Name};\n");
        });
        sb.Append("\n");
        
        publicMethods.ToList().ForEach(m =>
        {
            string paramss = m.Parameters.Any() ?  m.Parameters
                    .Select(mp => $"{mp.Type} {mp.Name}")
                    .Aggregate((m1, m2) => $"{m1}, {m2}") 
                : "";
            
            sb.Append($"\t\t{m.Type} {m.Name}({paramss});\n");
        });
        sb.Append("\n");
        
        return sb.ToString();
    }

    public string GenerateDependencies()
    {
        var dependencies = _links
            .OfType<UMLImplementationLink>()
            .SelectMany(l =>
            {
                if (l is UMLImplementationLink impl)
                {
                    foreach (var child in impl.Implementations.Children)
                    {
                        _interface.Properties.UnionWith(child.Value.Properties);
                        _interface.Methods.UnionWith(child.Value.Methods);
                    }

                    return impl.Implementations.Children
                        .Select(c => c.Value.Name);
                }

                return Enumerable.Empty<string>();
            })
            .Where(name => !string.IsNullOrWhiteSpace(name))
            .ToList();

        return dependencies.Count == 0 
            ? string.Empty 
            : $": public {string.Join(", public ", dependencies)}";
    }

}