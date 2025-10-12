using System.Text;
using uml_diagram.interfaces;
using uml_diagram.objects.uml.components;

namespace uml_diagram.code_generators.languages.C__.Record;

public class CPPRecordGenerator
{
    
    private UMLRecord _record;
    
    public CPPRecordGenerator(UMLRecord record)
    {
        this._record = record;
    }
    
    public string GenerateHeader()
    {
        return $"struct {_record.Name} {"{"}\n";
    }

    public string GeneratePublicSection()
    {
        StringBuilder sb = new();

        var publicProps = _record.Properties.Where(p => p.Accessibility == "public");
        
        if (!publicProps.Any()) return "";

        string ext = _record.Abstract ? "virtual" : "";
        string suffix = _record.Abstract ? " const = 0" : "";
        
        publicProps.ToList().ForEach(p =>
        {
            sb.Append($"\t{p.Type} {p.Name};\n");
        });
        
        return sb.ToString();
    }

    public string GeneratePrivateSection()
    {
        StringBuilder sb = new();

        var publicProps = _record.Properties.Where(p => p.Accessibility == "private");
        
        if (!publicProps.Any()) return "";
        
        publicProps.ToList().ForEach(p =>
        {
            sb.Append($"\t{p.Type} {p.Name};\n");
        });
        sb.Append("\n");
        
        return sb.ToString();
    }}