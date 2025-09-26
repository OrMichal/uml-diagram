using System.Diagnostics;
using uml_diagram.core;
using uml_diagram.interfaces;
using uml_diagram.ui;

namespace uml_diagram.objects.uml;

public sealed class UMLObject : IDrawable, IInteractable
{
    public string? Stereotype { get; set; }
    public string Name { get; set; }
    public string Accessibility { get; set; }
    public List<UMLObjectProperty> Properties { get; set; } = new();
    public List<UMLObjectMethod> Methods { get; set; } = new();
    
    public Point Location { get; set; }
    public SizeF Size { get; set; }
    
    private int padding = 4;
    private int margin = 4;
    private int gap = 6;
    private int listIndent = 2;
    
    private string GetStereotype() => $"<<{Stereotype}>>";
    
    public UMLObject()
    {
        this.Location = new Point(20, 20);
    }

    public UMLObject(Point location)
    {
        this.Location = location;
    }

    public bool IsCursorHovering(MouseEventArgs e)
    {
        return true;
    }

    public void OnDoubleClick(MouseEventArgs e)
    {
        
    }

    public void Draw(Graphics g)
    {
        this.Size = GetSize(g);
        PointF cursor = new(this.Location.X, this.Location.Y);
        
        g.DrawRectangle(DiagramSettings.ThickPen, cursor.X, cursor.Y, this.Size.Width, this.Size.Height);
        
        cursor.Y += g.MeasureString(Stereotype, DiagramSettings.Font).Height / 2;
        cursor.X += this.Size.Width / 2 -
                    g.MeasureString(Stereotype, DiagramSettings.Font).Width / 2;
        g.DrawString(GetStereotype(), DiagramSettings.Font, DiagramSettings.LightBrush, cursor.X, cursor.Y);

        cursor.Y += this.gap + g.MeasureString(Name, DiagramSettings.Font).Height / 2;
        cursor.X = this.Location.X + this.margin + this.Size.Width / 2 - g.MeasureString(Name, DiagramSettings.Font).Width / 2;
        g.DrawString(Name, DiagramSettings.Font, DiagramSettings.LightBrush, cursor.X, cursor.Y);
        
        cursor.Y += this.gap;
        cursor.X = this.Location.X;
        UIGraphics.DrawLineHorizontal(g, DiagramSettings.LightPen, cursor, this.Size.Width);

        if (this.Properties.Count > 0)
        {
            cursor.Y += this.gap;
            UIGraphics.DrawFlexbox(g, DiagramSettings.Font, DiagramSettings.LightBrush, cursor, this.Properties.Select(x => x.ToString()), this.listIndent);
            
            cursor.Y += this.Properties.Count * (g.MeasureString(this.Properties[0].ToString(), DiagramSettings.Font).Height + this.listIndent);
            cursor.X = this.Location.X;
            UIGraphics.DrawLineHorizontal(g, DiagramSettings.LightPen, cursor, this.Size.Width);
        }

        
        if (this.Methods.Count > 0)
        {
            cursor.Y += this.gap;
            UIGraphics.DrawFlexbox(g, DiagramSettings.Font, DiagramSettings.LightBrush, cursor, this.Methods.Select(x => x.ToString()), this.listIndent);
            
            cursor.Y += this.Properties.Count * (g.MeasureString(this.Properties[0].ToString(), DiagramSettings.Font).Height + this.listIndent);
            cursor.X = this.Location.X;
            UIGraphics.DrawLineHorizontal(g, DiagramSettings.LightPen, cursor, this.Size.Width);
        }
    }

    public SizeF GetSize(Graphics g)
    {
        float width;
        float height;
        
        string longestPropertyName = Properties.Count > 0 ? Properties.MaxBy(s => s.ToString().Length).ToString() : "";
        string longestMethodName = Methods.Count > 0 ? Methods.MaxBy(s => s.ToString().Length).ToString() : "";
        string longest = new[] { longestMethodName, longestPropertyName, this.Name, GetStereotype() }.MaxBy(x => x.Length);

        width = g.MeasureString(longest, DiagramSettings.Font).Width;
        height = (this.Stereotype is not null ? g.MeasureString(this.Stereotype, DiagramSettings.Font).Height : 0)
                 + this.gap
                 + g.MeasureString(this.Name, DiagramSettings.Font).Height
                 + this.gap
                 + (this.Properties.Count > 0 ? this.Properties.Count * (g.MeasureString(this.Properties[0].ToString(), DiagramSettings.Font).Height + this.listIndent) : 0)
                 + this.gap
                 + (this.Methods.Count > 0 ? this.Methods.Count * (g.MeasureString(this.Methods[0].ToString(), DiagramSettings.Font).Height + this.listIndent) : 0)
            ;
        
        return new(width, height);
    }
}