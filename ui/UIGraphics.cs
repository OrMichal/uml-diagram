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

    public static void DrawFlexbox(Graphics g, Font font, Brush brush, PointF location, IEnumerable<string> items, float gap = 2)
    {
        foreach (var item in items)
        {
            g.DrawString(item, font, brush, location);
            location.Y += gap + g.MeasureString(item, font).Height;
        }

        location.Y -= gap;
    }
}