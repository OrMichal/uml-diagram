using System.Text;
using uml_diagram.code_generators.languages.C_.datatype_generators;
using uml_diagram.interfaces;
using uml_diagram.objects.uml;
using uml_diagram.objects.uml.components;

namespace uml_diagram.code_generators;

public class CSharpObjectGenerator
{
    private List<ILink> _links;

    public CSharpObjectGenerator(List<ILink> links)
    {
        this._links = links;
    }
    
    public string GenerateCsharpObjectCode(UMLObject umlObject)
    {
        StringBuilder sb = new();

        sb.Append(umlObject switch
        {
            UMLClass umlClass => GenerateCSharpClassCode(umlClass),
            UMLInterface umlInter => GenerateCSharpInterfaceCode(umlInter),
            UMLStruct umlStruct => GenerateCSharpStructCode(umlStruct),
            UMLRecord umlRecord => GenerateCSharpRecordCode(umlRecord),
            UMLEnum umlEnum => GenerateCSharpEnumCode(umlEnum)
        });
        
        return sb.ToString();
    }
    
    private string GenerateCSharpClassCode(UMLClass umlClass)
    {
        StringBuilder sb = new();
        CSharpClassGenerator _gen = new(umlClass, _links);

        sb.Append($"{_gen.GenerateHeader()}\n");
        sb.Append("{\n");

        sb.Append($"{_gen.GenerateProperties()}\n");
        sb.Append($"{_gen.GenerateMethods()}\n");
        
        sb.Append("}\n");
        
        return sb.ToString();
    }
    
    private string GenerateCSharpInterfaceCode(UMLInterface umlInterface)
    {
        StringBuilder sb = new();
        CSharpInterfaceGenerator _gen = new(umlInterface, _links);

        sb.Append($"{_gen.GenerateHeader()}\n");
        sb.Append("{\n");

        sb.Append($"{_gen.GenerateProperties()}\n");
        sb.Append($"{_gen.GenerateMethods()}\n");
        
        sb.Append("}\n");
        
        return sb.ToString();
    }
    
    private string GenerateCSharpStructCode(UMLStruct umlStruct)
    {
        StringBuilder sb = new();
        CSharpStructGenerator _gen = new(umlStruct);

        sb.Append($"{_gen.GenerateHeader()}\n");
        sb.Append("{\n");

        sb.Append($"{_gen.GenerateProperties()}\n");
        sb.Append($"{_gen.GenerateMethods()}\n");
        
        sb.Append("}\n");
        
        return sb.ToString();
    }
    
    private string GenerateCSharpRecordCode(UMLRecord umlRecord)
    {
        StringBuilder sb = new();
        CSharpRecordGenerator _gen = new(umlRecord);

        sb.Append($"{_gen.GenerateHeader()}\n");
        sb.Append("{\n");

        sb.Append($"{_gen.GenerateProperties()}\n");
        sb.Append($"{_gen.GenerateMethods()}\n");
        
        sb.Append("}\n");
        
        return sb.ToString();
    }
    
    private string GenerateCSharpEnumCode(UMLEnum umlEnum)
    {
        StringBuilder sb = new();
        CSharpEnumGenerator _gen = new(umlEnum);

        sb.Append($"{_gen.GenerateHeader()}\n");
        sb.Append("{\n");

        sb.Append($"{_gen.GenerateProperties()}\n");
        
        sb.Append("}\n");
        
        return sb.ToString();
    }
}