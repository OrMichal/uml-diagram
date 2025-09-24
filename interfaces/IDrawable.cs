namespace uml_diagram.interfaces;

public interface IDrawable
{
    public Point Location { get; set; }
    public Size Size { get; set; }
    public void Draw(Graphics g);
}