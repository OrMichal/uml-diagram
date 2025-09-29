namespace uml_diagram.interfaces;

public interface IConnectable
{
    public PointF TopCenter { get; }
    public PointF RightCenter { get; }
    public PointF BottomCenter { get; }
    public PointF LeftCenter { get; }
}