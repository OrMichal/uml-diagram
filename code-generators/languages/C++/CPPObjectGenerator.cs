using System.Text;
using uml_diagram.interfaces;
using uml_diagram.objects.uml;
using uml_diagram.objects.uml.components;

namespace uml_diagram.code_generators.languages.C__;

public class CPPObjectGenerator
{
    private List<ILink> _links;

    public CPPObjectGenerator(List<ILink> links)
    {
        this._links = links;
    }
    
    public string GenerateCPPObjectCode(UMLObject umlObject)
    {
        return umlObject switch
        {
            UMLClass umlClass => GenerateCPPClassCode(umlClass)
        };
    }

    public string GenerateCPPObjectHeaderCode(UMLObject umlObject)
    {
        return umlObject switch
        {
            UMLClass umlClass => GenerateCPPClassHeaderCode(umlClass)
        };
    }

    private string GenerateCPPClassCode(UMLClass umlClass)
    {
        StringBuilder sb = new();
        CPPClassGenerator _gen = new(umlClass, _links);

        sb.Append(_gen.GenerateHeader());
        sb.Append(_gen.GeneratePublicSection());
        sb.Append(_gen.GeneratePrivateSection());
        
        return sb.ToString();
    }

    public string GenerateCPPClassHeaderCode(UMLClass umlClass)
    {
        StringBuilder sb = new();
        CPPClassHeaderGenerator _gen = new(umlClass, _links);

        sb.Append(_gen.GenerateHeader());
        sb.Append(_gen.GeneratePublicSection());
        sb.Append(_gen.GeneratePrivateSection());
        
        sb.Append("}\n");
        return sb.ToString();
    }
}