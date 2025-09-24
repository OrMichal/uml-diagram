namespace uml_diagram.objects.uml;

public class UMLObject
{
    internal class UMLObjectProperty
    {
        public int Accessibility { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }

        public override string ToString()
        {
            return $"";
        }
    }
    
    public string Name { get; set; }
    
}