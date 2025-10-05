using uml_diagram.core;
using uml_diagram.interfaces;

namespace uml_diagram.ui.elements;

public class UILabel : IConnectableComponent
{
    public PointF Location { get; set; }
    public SizeF Size { get; set; }
    public string Text { get; set; }
    public PointF TopCenter { get => new PointF(Location.X + Size.Width / 2, Location.Y); }
    public PointF RightCenter { get => new PointF(Location.X + Size.Width, Location.Y + Size.Height/2); }
    public PointF BottomCenter { get => new PointF(Location.X + Size.Width/2, Location.Y + Size.Height); }
    public PointF  LeftCenter { get => new PointF(Location.X, Location.Y + Size.Height); }
    public bool BackgroundFill = false;
    public int Padding = 5;
    public Font Font = DiagramSettings.LightFont;
    
    public UILabel(PointF location, string text, bool backgroundFill = false)
    {
        this.Location = location;
        this.Text = text;
        this.BackgroundFill = backgroundFill;
    }

    public void Draw(Graphics g)
    {
        CalcSize(g);

        if (!BackgroundFill)
        {
            g.DrawRectangle(DiagramSettings.LightPen, Location.X, Location.Y, Size.Width, Size.Height);
            g.DrawString(Text, Font,DiagramSettings.LightBrush,  Location.X + Padding, Location.Y + Size.Height / 4);
            return;
        }
        else
        {
            g.FillRectangle(new SolidBrush(Color.White), Location.X, Location.Y, Size.Width, Size.Height);
            g.DrawString(Text, Font,DiagramSettings.LightBrush,  Location.X + Padding, Location.Y + Size.Height / 4);
        }

    }

    public void DrawCenterBetween(Graphics g, PointF p1, PointF p2)
    {
        CalcSize(g);
        PointF location = new PointF((p1.X + p2.X) / 2 - Size.Width / 2, (p1.Y + p2.Y) / 2);

        if (!BackgroundFill)
        {
            g.DrawRectangle(DiagramSettings.LightPen, location.X, location.Y - Size.Height / 2, Size.Width, Size.Height);
            g.DrawString(Text, Font, DiagramSettings.LightBrush,  location.X + Padding, location.Y + Size.Height / 4 - Size.Height/2);
            return;
        }
        else
        {
            g.FillRectangle(new SolidBrush(Color.White), location.X, location.Y - Size.Height / 2, Size.Width, Size.Height);
            g.DrawString(Text, Font, DiagramSettings.LightBrush,  location.X + Padding, location.Y + Size.Height / 4 - Size.Height / 2);
        }
    }

    public void DrawSelected(Graphics g)
    {
        
    }

    private void CalcSize(Graphics g)
    {
        SizeF textSize = g.MeasureString(Text, Font);
        Size = new(textSize.Width + Padding * 2, textSize.Height + Padding * 2);
    }
}