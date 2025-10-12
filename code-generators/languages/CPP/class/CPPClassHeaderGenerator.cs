using System.Text;
using uml_diagram.interfaces;
using uml_diagram.objects.uml.components;
using uml_diagram.objects.uml.linkers;

namespace uml_diagram.code_generators.languages.C__;

public class CPPClassHeaderGenerator
{
    private UMLClass _class;
    private List<ILink> _links;
    
    public CPPClassHeaderGenerator(UMLClass @class, List<ILink> links)
    {
        this._class = @class;
        this._links = links;
    }
    
    public string GenerateHeader()
    {
        return $"class {_class.Name} {GenerateDependencies()} {"{"}\n";
    }

    public string GeneratePublicSection()
    {
        StringBuilder sb = new();

        var publicProps = _class.Properties.Where(p => p.Accessibility == "public");
        var publicMethods = _class.Methods.Where(p => p.Accessibility == "public");
        
        if (!publicProps.Any() && !publicMethods.Any()) return "";

        string ext = _class.Abstract ? "virtual" : "";
        string suffix = _class.Abstract ? " const = 0" : "";
        
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

        var publicProps = _class.Properties.Where(p => p.Accessibility == "private");
        var publicMethods = _class.Methods.Where(p => p.Accessibility == "private");
        
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
        StringBuilder sb = new();
        List<ILink> dependencies = _links
            .Where(l => l is UMLInheritenceLink || l is UMLImplementationLink)
            .OrderByDescending(l => l is UMLInheritenceLink)
            .ToList();
        bool inherited = false;

        if (dependencies.Count <= 0) return "";
        
        return ": public " + dependencies.Select(d =>
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
        }).Aggregate((s1, s2) => $"{s1}, public {s2}");
    }
}