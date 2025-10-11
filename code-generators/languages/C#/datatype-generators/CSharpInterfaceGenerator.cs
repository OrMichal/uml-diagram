using System.Text;
using uml_diagram.interfaces;
using uml_diagram.objects.uml.components;
using uml_diagram.objects.uml.linkers;

namespace uml_diagram.code_generators.languages.C_.datatype_generators;

public class CSharpInterfaceGenerator : IObjectGenerator, IGeneratesDependencies, IGeneratesProperties, IGeneratesMethods
{
    private UMLInterface _interface;
    private List<ILink> _links;

    public CSharpInterfaceGenerator(UMLInterface @interface, List<ILink>  links)
    {
        this._interface = @interface;
        this._links = links;
    }
    
    public string GenerateHeader()
    {
        string ext = _interface.Abstract 
            ? "abstract " 
            : _interface.Static 
                ? "static " 
                : "";
        
        return $"{_interface.Accessibility} {ext} interface {_interface.Name} {GenerateDependencies()}";
    }

    public string GenerateProperties()
    {
        StringBuilder sb = new();
        
        _interface.Properties.ToList().ForEach(p =>
        {
            string ext = p.Abstract ? "abstract" : "";
            
            sb.Append($" {p.Accessibility} {ext} {p.Type} {p.Name} {"{"} get; set; {"}"}\n");
        });
        return sb.ToString();
    }

    public string GenerateMethods()
    {
        StringBuilder sb = new();

        _interface.Methods.ToList().ForEach(m =>
        {
            string ext = m.Abstract ? "abstract" : " ";
            string @params = m.Parameters.Count > 0 ? m.Parameters
                .Select(p => $"{p.Type} {p.Name}")
                .Aggregate((m1, m2) => $"{m1}, {m2}") 
                
                : "";

            sb.Append($" {m.Accessibility} {ext} {m.Type} {m.Name}({@params});\n");
        });
        
        return sb.ToString();
    }

    public string GenerateDependencies()
    {
        StringBuilder sb = new();
        List<UMLImplementationLink> dependencies = _links
            .OfType<UMLImplementationLink>()
            .ToList();

        if (dependencies.Count <= 0)
            return "";

        var item = _links
            .OfType<UMLImplementationLink>()
            .Select(l => l.Implementations.FindChild(_interface))
            .FirstOrDefault();

        var children = item.Children.Select(c => c.Value.Name);

        foreach (var child in item.Children)
        {
            item.Value.Properties.UnionWith(child.Value.Properties);
            item.Value.Methods.UnionWith(child.Value.Methods);
        }
        
        if (children.Count() <= 0) return "";
        
        return ": " + children.Aggregate((s1, s2) => $"{s1}, {s2}");
    }
}