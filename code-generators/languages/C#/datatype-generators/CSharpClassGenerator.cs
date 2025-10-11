using System.Text;
using uml_diagram.interfaces;
using uml_diagram.objects.uml.components;
using uml_diagram.objects.uml.linkers;

namespace uml_diagram.code_generators.languages.C_.datatype_generators;

public class CSharpClassGenerator : IObjectGenerator, IGeneratesDependencies, IGeneratesProperties, IGeneratesMethods
{
    private UMLClass _class;
    private List<ILink> _links;

    public CSharpClassGenerator(UMLClass @class, List<ILink>  links)
    {
        this._class = @class;
        this._links = links;
    }
    
    public string GenerateHeader()
    {
        string ext = _class.Abstract 
            ? "abstract " 
            : _class.Static 
                ? "static " 
                : "";
        
        return $"{_class.Accessibility} {ext} class {_class.Name} {GenerateDependencies()}";
    }

    public string GenerateProperties()
    {
        StringBuilder sb = new();
        
        _class.Properties.ToList().ForEach(p =>
        {
            string ext = p.Abstract ? "abstract" : "";
            
            sb.Append($" {p.Accessibility} {ext} {p.Type} {p.Name} {"{"} get; set; {"}"}\n");
        });
        return sb.ToString();
    }

    public string GenerateMethods()
    {
        StringBuilder sb = new();

        _class.Methods.ToList().ForEach(m =>
        {
            string ext = m.Abstract ? "abstract" : " ";
            string @params = m.Parameters.Count > 0 ? m.Parameters
                .Select(p => $"{p.Type} {p.Name}")
                .Aggregate((m1, m2) => $"{m1}, {m2}") 
                
                : " ";

            sb.Append($" {m.Accessibility} {ext} {m.Type} {m.Name}({@params})\n");
            sb.Append(" {\n");
            sb.Append("   throw new NotImplementedException();\n");
            sb.Append(" }\n\n");
        });
        
        return sb.ToString();
    }

    public string GenerateDependencies()
    {
        StringBuilder sb = new();
        List<ILink> dependencies = _links
            .Where(l => l is UMLInheritenceLink || l is UMLImplementationLink)
            .OrderByDescending(l => l is UMLInheritenceLink)
            .ToList();
        bool inherited = false;

        if (dependencies.Count <= 0) return "";
        
        return ": " + dependencies.Select(d =>
        {
            if(d is UMLInheritenceLink inheritenceLink && !inherited && inheritenceLink.SecondObject is UMLClass inheritedClass) 
            {
                inherited = true;
                return inheritedClass.Name;
            }
            else if(d is UMLImplementationLink implLink)
            {
                foreach (var child in implLink.Implementations.Children)
                {
                    _class.Properties.UnionWith(child.Value.Properties);
                    _class.Methods.UnionWith(child.Value.Methods);
                }
                
                return implLink.Implementations.Children
                    .Select(c => c.Value.Name)
                    .Aggregate((i1, i2) => $"{i1}, {i2}");
            }

            return "";
        }).Aggregate((s1, s2) => $"{s1}, {s2}");
    }
}