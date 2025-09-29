using System.Diagnostics;
using System.Drawing.Drawing2D;
using System.Drawing.Text;
using System.Net.Mime;
using System.Text;
using uml_diagram.core;
using uml_diagram.interfaces;
using uml_diagram.ui;

namespace uml_diagram.objects.uml;

public class UMLObject : IComponent, IInteractable
{
    public string? Stereotype { get; set; }
    public string Name { get; set; }
    public string Accessibility { get; set; }
    public List<UMLObjectProperty> Properties { get; set; } = new();
    public List<UMLObjectMethod> Methods { get; set; } = new();
    public PointF Location { get; set; }
    public SizeF Size { get; set; }
    public bool Abstract { get; set; } = false;
    public bool Static { get; set; } = false;
    
    protected int padding = 4;
    protected int margin = 4;
    protected int gap = 6;
    protected int listIndent = 2;
    
    private string GetStereotype() => $"<<{Stereotype}>>";
    
    public UMLObject()
    {
        this.Location = new Point(20, 20);
    }

    public UMLObject(Point location)
    {
        this.Location = location;
    }

    public bool IsCursorHovering(Point e)
    {
        bool containsX = e.X > this.Location.X && e.X < this.Location.X + this.Size.Width;
        bool containsY = e.Y > this.Location.Y && e.Y < this.Location.Y + this.Size.Height;
        
        return containsX && containsY;
    }

    public void OnDoubleClick(Point e)
    {
        
    }

    public virtual void DrawSelected(Graphics g)
    {
        g.SmoothingMode = SmoothingMode.AntiAlias;
        g.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAliasGridFit;

        this.Size = GetSize(g);
        PointF cursor = new PointF(this.Location.X, this.Location.Y);

        g.FillRectangle(DiagramSettings.BgBrush, cursor.X, cursor.Y, this.Size.Width, this.Size.Height);
        g.DrawRectangle(DiagramSettings.MediumPen, cursor.X, cursor.Y, this.Size.Width, this.Size.Height);

        StringFormat centerFormat = new StringFormat();
        centerFormat.Alignment = StringAlignment.Center;
        centerFormat.LineAlignment = StringAlignment.Center;

        float headerHeight = g.MeasureString(this.Name, DiagramSettings.Font).Height * 2.5f;

        RectangleF stereotypeBounds = new RectangleF(this.Location.X, this.Location.Y, this.Size.Width, headerHeight / 2);
        RectangleF nameBounds = new RectangleF(this.Location.X, this.Location.Y + headerHeight / 2, this.Size.Width, headerHeight / 2);

        g.DrawString(this.GetStereotype(), DiagramSettings.Font, DiagramSettings.LightBrush, stereotypeBounds, centerFormat);
        g.DrawString(this.Name, new Font(DiagramSettings.Font, this.Abstract ? FontStyle.Italic : FontStyle.Regular), DiagramSettings.LightBrush, nameBounds, centerFormat);

        float curY = this.Location.Y + headerHeight + this.gap;

        UIGraphics.DrawLineHorizontal(g, DiagramSettings.LightPen, new PointF(this.Location.X, curY), this.Size.Width);
        curY += this.gap;

        if (this.Properties.Count > 0)
        {
            curY += this.gap;

            UIGraphics.DrawPropsFlexbox(g, DiagramSettings.Font, DiagramSettings.LightBrush, new PointF(this.Location.X, curY), this.Properties, this.listIndent);

            curY += this.Properties.Count * (g.MeasureString(this.Properties[0].ToString(), DiagramSettings.Font).Height + this.listIndent);

            UIGraphics.DrawLineHorizontal(g, DiagramSettings.LightPen, new PointF(this.Location.X, curY), this.Size.Width);
            curY += this.gap;
        }

        if (this.Methods.Count > 0)
        {
            curY += this.gap;

            UIGraphics.DrawPropsFlexbox(g, DiagramSettings.Font, DiagramSettings.LightBrush, new PointF(this.Location.X, curY), this.Methods, this.listIndent);
            curY += this.Methods.Count * (g.MeasureString(this.Methods[0].ToString(), DiagramSettings.Font).Height + this.listIndent);
        }
    }
    public virtual void Draw(Graphics g)
    {
        g.SmoothingMode = SmoothingMode.AntiAlias;
        g.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAliasGridFit;

        this.Size = GetSize(g);
        PointF cursor = new PointF(this.Location.X, this.Location.Y);

        g.DrawRectangle(DiagramSettings.ThickPen, cursor.X, cursor.Y, this.Size.Width, this.Size.Height);

        StringFormat centerFormat = new StringFormat();
        centerFormat.Alignment = StringAlignment.Center;
        centerFormat.LineAlignment = StringAlignment.Center;

        float headerHeight = g.MeasureString(this.Name, DiagramSettings.Font).Height * 2.5f;

        RectangleF stereotypeBounds = new RectangleF(this.Location.X, this.Location.Y, this.Size.Width, headerHeight / 2);
        RectangleF nameBounds = new RectangleF(this.Location.X, this.Location.Y + headerHeight / 2, this.Size.Width, headerHeight / 2);

        g.DrawString(this.GetStereotype(), DiagramSettings.Font, DiagramSettings.LightBrush, stereotypeBounds, centerFormat);
        g.DrawString(this.Name, new Font(DiagramSettings.Font, this.Abstract ? FontStyle.Italic : FontStyle.Regular), DiagramSettings.LightBrush, nameBounds, centerFormat);

        float curY = this.Location.Y + headerHeight + this.gap;

        UIGraphics.DrawLineHorizontal(g, DiagramSettings.LightPen, new PointF(this.Location.X, curY), this.Size.Width);
        curY += this.gap;

        if (this.Properties.Count > 0)
        {
            curY += this.gap;

            UIGraphics.DrawPropsFlexbox(g, DiagramSettings.Font, DiagramSettings.LightBrush, new PointF(this.Location.X, curY), this.Properties, this.listIndent);

            curY += this.Properties.Count * (g.MeasureString(this.Properties[0].ToString(), DiagramSettings.Font).Height + this.listIndent);

            UIGraphics.DrawLineHorizontal(g, DiagramSettings.LightPen, new PointF(this.Location.X, curY), this.Size.Width);
            curY += this.gap;
        }

        if (this.Methods.Count > 0)
        {
            curY += this.gap;

            UIGraphics.DrawPropsFlexbox(g, DiagramSettings.Font, DiagramSettings.LightBrush, new PointF(this.Location.X, curY), this.Methods, this.listIndent);
            curY += this.Methods.Count * (g.MeasureString(this.Methods[0].ToString(), DiagramSettings.Font).Height + this.listIndent);
        }
    }

    protected SizeF GetSize(Graphics g)
    {
        string longestPropertyName = Properties.Count > 0 ? Properties?.MaxBy(s => s.ToString().Length).ToString() : "";
        string longestMethodName = Methods.Count > 0 ? Methods?.MaxBy(s => s.ToString().Length).ToString() : "";
        string longest = new[] { longestMethodName, longestPropertyName, this.Name, GetStereotype() ?? " " }.MaxBy(x => x.Length);

        float width = g.MeasureString(longest ?? "", DiagramSettings.Font).Width;

        string stereotype = GetStereotype() ?? "";
        float stereotypeHeight = string.IsNullOrEmpty(stereotype) ? 0f : g.MeasureString(stereotype, DiagramSettings.Font).Height;
        float nameHeight = g.MeasureString(this.Name ?? "", DiagramSettings.Font).Height;

        float headerInnerSpacing = !string.IsNullOrEmpty(stereotype) ? this.gap / 2f : 0f;
        float headerHeight = stereotypeHeight + nameHeight + headerInnerSpacing;
        float height = headerHeight;

        height += 2f * this.gap;

        if (this.Properties.Count > 0)
        {
            height += this.gap;

            float propsTotal = 0f;
            foreach (var p in this.Properties)
            {
                propsTotal += g.MeasureString(p.ToString(), DiagramSettings.Font).Height + this.listIndent;
            }

            height += propsTotal;

            height += this.gap;
        }

        if (this.Methods.Count > 0)
        {
            height += this.gap;

            float methodsTotal = 0f;
            foreach (var m in this.Methods)
            {
                methodsTotal += g.MeasureString(m.ToString(), DiagramSettings.Font).Height + this.listIndent;
            }

            height += methodsTotal;
        }

        height += this.padding;

        return new SizeF(width, height);
    }

    public override string ToString()
    {
        StringBuilder sb = new();
        foreach (var propertyInfo in typeof(UMLObject).GetProperties())
        {
            sb.Append($"{propertyInfo.Name}: {propertyInfo.GetValue(propertyInfo)}");
        }
        
        foreach (var methodInfo in typeof(UMLObject).GetMethods())
        {
            sb.Append($"{methodInfo.Name}(): {methodInfo.GetType()}");
        }

        return sb.ToString();
    }
}