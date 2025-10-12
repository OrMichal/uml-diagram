using System.Text;
using uml_diagram.code_generators.languages.C__.Enum;
using uml_diagram.code_generators.languages.C__.Record;
using uml_diagram.code_generators.languages.C__.Struct;
using uml_diagram.code_generators.languages.CPP.Interface;
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
            UMLClass umlClass => GenerateCPPClassCode(umlClass),
            UMLInterface umlInterface => $"#include '{umlInterface.Name}.h'",
            UMLStruct umlStruct => $"#include '{umlStruct.Name}.h'",
            UMLRecord umlRecord => $"#include '{umlRecord.Name}.h'",
            UMLEnum umlEnum => $"#include '{umlEnum.Name}.h'"
        };
    }

    public string GenerateCPPObjectHeaderCode(UMLObject umlObject)
    {
        return umlObject switch
        {
            UMLClass umlClass => GenerateCPPClassHeaderCode(umlClass),
            UMLInterface umlInterface => GenerateCPPInterfaceCode(umlInterface),
            UMLStruct umlStruct => GenerateCPPStructCode(umlStruct),
            UMLRecord umlRecord => GenerateCPPRecordCode(umlRecord),
            UMLEnum umlEnum => GenerateCPPEnumCode(umlEnum)
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
        
        sb.Append("};\n");
        return sb.ToString();
    }

    private string GenerateCPPInterfaceCode(UMLInterface umlInterface)
    {
        StringBuilder sb = new();
        CPPInterfaceGenerator _gen = new(umlInterface, _links);

        sb.Append(_gen.GenerateHeader());
        sb.Append(_gen.GeneratePublicSection());
        sb.Append(_gen.GeneratePrivateSection());
        
        sb.Append("};\n");
        return sb.ToString();
    }

    private string GenerateCPPStructCode(UMLStruct umlStruct)
    {
        StringBuilder sb = new();
        CPPStructGenerator _gen = new(umlStruct, _links);

        sb.Append(_gen.GenerateHeader());
        sb.Append(_gen.GeneratePublicSection());
        sb.Append(_gen.GeneratePrivateSection());
        
        sb.Append("};\n");
        return sb.ToString();
    }

    private string GenerateCPPRecordCode(UMLRecord umlRecord)
    {
        StringBuilder sb = new();
        CPPRecordGenerator _gen = new(umlRecord);

        sb.Append(_gen.GenerateHeader());
        sb.Append(_gen.GeneratePublicSection());
        sb.Append(_gen.GeneratePrivateSection());
        sb.Append($"\n\tauto operator<=>(const {umlRecord.Name}&) const = default;\n");
        
        sb.Append("};\n");
        return sb.ToString();
    }
    
    private string GenerateCPPEnumCode(UMLEnum umlEnum) 
    {
        StringBuilder sb = new();
        CPPEnumGenerator _gen = new(umlEnum);

        sb.Append(_gen.GenerateHeader());
        sb.Append(_gen.GeneratePublicSection());
        sb.Append(_gen.GeneratePrivateSection());
        
        sb.Append("};\n");
        return sb.ToString();
    }
}