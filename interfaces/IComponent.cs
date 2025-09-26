namespace uml_diagram.interfaces;

public interface IComponent
{
    public PointF Location { get; set; }
    public SizeF Size { get; set; }
    public void Draw(Graphics g);
}