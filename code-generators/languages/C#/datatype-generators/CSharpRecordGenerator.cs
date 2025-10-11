using System.Text;
using uml_diagram.interfaces;
using uml_diagram.objects.uml.components;

namespace uml_diagram.code_generators.languages.C_.datatype_generators;

public class CSharpRecordGenerator : IGeneratesMethods, IGeneratesProperties
{
    
    private UMLRecord _record;

    public CSharpRecordGenerator(UMLRecord record)
    {
        this._record = record;
    }

    public string GenerateHeader()
    {
        return $"{_record.Accessibility} record {_record.Name}";
    }

    public string GenerateProperties()
    {
        StringBuilder sb = new();

        _record.Properties.ToList().ForEach(p =>
        {
            sb.Append($" {p.Accessibility} {p.Type} {p.Name} {"{"} get; set; {"}"}\n");
        });
        return sb.ToString();
    }

    public string GenerateMethods()
    {
        StringBuilder sb = new();

        _record.Methods.ToList().ForEach(m =>
        {
            string @params = m.Parameters.Count > 0
                ? m.Parameters
                    .Select(p => $"{p.Type} {p.Name}")
                    .Aggregate((m1, m2) => $"{m1}, {m2}")

                : " ";

            sb.Append($" {m.Accessibility} {m.Type} {m.Name}({@params})\n");
            sb.Append(" {\n");
            sb.Append("   throw new NotImplementedException();\n");
            sb.Append(" }\n\n");
        });

        return sb.ToString();
    }}