using Newtonsoft.Json;
using uml_diagram.interfaces;

namespace uml_diagram.data_managers;

public class Importer
{
    public List<IComponent> GetComponentsFromJson(string filepath)
    {
        string json = File.ReadAllText(filepath);
        return JsonConvert.DeserializeObject<List<IComponent>>(json, JSONSettings.Settings);
    }

    public List<ILink> GetLinksFromJson(string filepath)
    {
        string json = File.ReadAllText(filepath);
        return JsonConvert.DeserializeObject<List<ILink>>(json, JSONSettings.Settings);
    }
}