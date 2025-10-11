using System.Text;
using uml_diagram.interfaces;
using uml_diagram.objects.uml.components;

namespace uml_diagram.code_generators.languages.C_.datatype_generators;

public class CSharpStructGenerator : IObjectGenerator, IGeneratesMethods, IGeneratesProperties
{
    private UMLStruct _struct;

    public CSharpStructGenerator(UMLStruct @struct)
    {
        this._struct = @struct;
    }

    public string GenerateHeader()
    {
        return $"{_struct.Accessibility} struct {_struct.Name}";
    }

    public string GenerateProperties()
    {
        StringBuilder sb = new();

        _struct.Properties.ToList().ForEach(p =>
        {
            sb.Append($" {p.Accessibility} {p.Type} {p.Name} {"{"} get; set; {"}"}\n");
        });
        return sb.ToString();
    }

    public string GenerateMethods()
    {
        StringBuilder sb = new();

        _struct.Methods.ToList().ForEach(m =>
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
    }
}
    