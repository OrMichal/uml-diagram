using uml_diagram.core;
using uml_diagram.interfaces;
using uml_diagram.math.enums;

namespace uml_diagram.ui.elements;

public class UIArrow : IComponent
{
    public Direction Direction { get; set; }
    public SizeF Size { get; set; }
    public PointF Location { get; set; }
    public bool Filled { get; set; }

    public UIArrow(PointF location, SizeF size, Direction direction)
    {
        this.Size = size;
        this.Location = location;
        this.Direction = direction;
    }
    
    public void Draw(Graphics g)
    {
        if (Filled)
        {
            switch (Direction)
            {
                case Direction.Up:
                    g.FillPolygon(DiagramSettings.LightBrush, new[] 
                    {
                        Location,
                        new PointF(Location.X + Size.Width / 2, Location.Y + Size.Height),
                        new PointF(Location.X - Size.Width / 2, Location.Y + Size.Height),
                        Location
                    });
                    break;
                case Direction.Down:
                    g.FillPolygon(DiagramSettings.LightBrush, new[] 
                    {
                        Location,
                        new PointF(Location.X + Size.Width / 2, Location.Y + Size.Height),
                        new PointF(Location.X - Size.Width / 2, Location.Y + Size.Height),
                        Location
                    });
                    break;
                case Direction.Left:
                    g.FillPolygon(DiagramSettings.LightBrush, new[]
                    {
                        Location,
                        new PointF(Location.X + Size.Width, Location.Y - Size.Height/2),
                        new PointF(Location.X + Size.Width, Location.Y + Size.Height/2),
                        Location
                    });
                    break;
                case Direction.Right:
                    g.FillPolygon(DiagramSettings.LightBrush, new[]
                    {
                        Location,
                        new PointF(Location.X - Size.Width, Location.Y - Size.Height/2),
                        new PointF(Location.X - Size.Width, Location.Y + Size.Height/2),
                        Location
                    });
                    break;
            }
        }
        
        switch (Direction)
        {
            case Direction.Up:
                g.DrawLines(DiagramSettings.LightPen, new[] 
                {
                    Location,
                    new PointF(Location.X + Size.Width / 2, Location.Y + Size.Height),
                    new PointF(Location.X - Size.Width / 2, Location.Y + Size.Height),
                    Location
                });
                break;
            case Direction.Down:
                g.DrawLines(DiagramSettings.LightPen, new[] 
                {
                    Location,
                    new PointF(Location.X + Size.Width / 2, Location.Y + Size.Height),
                    new PointF(Location.X - Size.Width / 2, Location.Y + Size.Height),
                    Location
                });
                break;
            case Direction.Left:
                g.DrawLines(DiagramSettings.LightPen, new[]
                {
                    Location,
                    new PointF(Location.X + Size.Width, Location.Y - Size.Height/2),
                    new PointF(Location.X + Size.Width, Location.Y + Size.Height/2),
                    Location
                });
                break;
            case Direction.Right:
                g.DrawLines(DiagramSettings.LightPen, new[]
                {
                    Location,
                    new PointF(Location.X - Size.Width, Location.Y - Size.Height/2),
                    new PointF(Location.X - Size.Width, Location.Y + Size.Height/2),
                    Location
                });
                break;
        }
    }

    public void DrawSelected(Graphics g)
    {
        
    }
}