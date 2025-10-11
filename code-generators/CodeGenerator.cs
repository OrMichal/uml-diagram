using uml_diagram.code_generators.languages.C__;
using uml_diagram.core;
using uml_diagram.objects.uml;
using uml_diagram.objects.uml.components;

namespace uml_diagram.code_generators;

public class CodeGenerator
{
    private Namespace _ns;
    
    public CodeGenerator(Namespace ns)
    {
        this._ns = ns;
    }  
    
    public void GenerateCsharpCode(string folderpath) 
    {
        string dirPath = Path.Combine(folderpath, _ns.Name);
        
        if(Directory.Exists(dirPath)) 
        {
            Directory.Delete(dirPath, true);
        }

        Directory.CreateDirectory(dirPath);
        
        List<UMLObject> _objects = _ns.Diagram.Components
            .OfType<UMLObject>()
            .ToList();

        CSharpObjectGenerator objGenerator = new(_ns.Diagram.Linker._links);
        
        _objects.ForEach(o =>
        {
            string filePath = Path.Combine(dirPath, $"{o.Name}.cs");
            File.Create(filePath).Close(); 
            
            using (StreamWriter sr = new(filePath)) 
            {
                sr.WriteLine($"namespace {_ns.Name};");
                sr.Write("\n");
                
                sr.Write(objGenerator.GenerateCsharpObjectCode(o));
            }
        });
    }
    
    public void GenerateCPPCode(string folderpath)
    {
        string dirPath = Path.Combine(folderpath, _ns.Name);
        
        if(Directory.Exists(dirPath)) 
        {
            Directory.Delete(dirPath, true);
        }

        Directory.CreateDirectory(dirPath);
        
        List<UMLObject> _objects = _ns.Diagram.Components
            .OfType<UMLObject>()
            .ToList();

        CPPObjectGenerator objGenerator = new(_ns.Diagram.Linker._links);
        
        _objects.ForEach(o =>
        {
            string dirrPath = Path.Combine(dirPath, o.Name);
            Directory.CreateDirectory(dirrPath);
            
            string filePath = Path.Combine(dirrPath, $"{o.Name}.h");
            
            using (StreamWriter sr = new(filePath)) 
            {
                sr.WriteLine("#pragma once");
                sr.Write(objGenerator.GenerateCPPObjectHeaderCode(o));
            }
            
            filePath = Path.Combine(dirrPath, $"{o.Name}.cpp");

            using (StreamWriter sw = new(filePath))
            {
                sw.Write(objGenerator.GenerateCPPObjectCode(o));
            }
        });
    }
}