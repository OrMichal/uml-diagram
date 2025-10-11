using Newtonsoft.Json;

namespace uml_diagram.data_managers;

public static class JSONSettings
{
    public static JsonSerializerSettings Settings = new JsonSerializerSettings()
    {
        TypeNameHandling = TypeNameHandling.All,
        Formatting = Formatting.Indented
    };
}