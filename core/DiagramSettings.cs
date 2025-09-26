namespace uml_diagram.core;

public static class DiagramSettings
{
    public static Font Font = new("Arial", 12);
    
    public static Pen LightPen = new(Color.Black, 1);
    public static Pen MediumPen = new(Color.Black, 2);
    public static Pen ThickPen = new(Color.Black, 3);

    public static Brush LightBrush = new SolidBrush(Color.Black);
}