using Newtonsoft.Json;
using uml_diagram.core;
using uml_diagram.interfaces;

namespace uml_diagram.data_managers;

public class Exporter
{
    public void ExportJsonNamespace(Namespace @namespace, string folderpath)
    {
        string filepath = Path.Combine(folderpath, $"{@namespace.Name}");

        if (Directory.Exists(filepath))
        {
            Directory.Delete(filepath, true);
        }

        Directory.CreateDirectory(filepath);
        
        string componentsJson = JsonConvert.SerializeObject(@namespace.Diagram.Components, JSONSettings.Settings);
        string linksJson = JsonConvert.SerializeObject(@namespace.Diagram.Linker._links);
        
        using (StreamWriter sr = new(Path.Combine(filepath, "components.json")))
        {
            sr.Write(componentsJson);
        }

        using (StreamWriter sw = new(Path.Combine(filepath, "links.json")))
        {
            sw.Write(linksJson);
        }
    }
}