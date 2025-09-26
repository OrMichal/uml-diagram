using uml_diagram.interfaces;

namespace uml_diagram.ui;

public static class UIGraphics
{
    public static void DrawLineHorizontal(Graphics g, Pen p, PointF location, float length)
    {
        g.DrawLine(p, location.X, location.Y, location.X + length, location.Y);
    }

    public static void DrawLineVertical(Graphics g, Pen p, PointF location, float length)
    {
        g.DrawLine(p, location.X, location.Y, location.X, location.Y + length);
    }

    public static void DrawPropsFlexbox(Graphics g, Font font, Brush brush, PointF location, IEnumerable<IAbstractable> items, float gap = 2)
    {
        foreach (var item in items)
        {
            Font f = new(font, item.Abstract ? FontStyle.Italic : FontStyle.Regular);   
            g.DrawString(item.ToString(), f, brush, location);
            location.Y += gap + g.MeasureString(item.ToString(), f).Height;
        }

        location.Y -= gap;
    }
}