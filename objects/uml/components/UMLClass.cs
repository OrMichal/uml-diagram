using System.Drawing.Drawing2D;
using uml_diagram.core;
using uml_diagram.interfaces;
using uml_diagram.ui;

namespace uml_diagram.objects.uml.components;

public class UMLClass : UMLObject, IInheritable, IAbstractable, IImplementationTarget, 
    IConnectableComponent, IAssociable, IReflexiveAssociable, IMultiplicable, IComposable, IAggregatable
{
    public string Guid {get; set;}
    public PointF TopCenter { get => new PointF(Location.X + Size.Width / 2, Location.Y); }
    public PointF RightCenter { get => new PointF(Location.X + Size.Width, Location.Y + Size.Height / 2); }
    public PointF BottomCenter { get => new PointF(Location.X + Size.Width / 2, Location.Y + Size.Height); }
    public PointF LeftCenter { get => new PointF(Location.X, Location.Y + Size.Height /2); }

    public UMLClass()
    {
        this.Guid = System.Guid.NewGuid().ToString();
    }

    public UMLClass(UMLObject umlObject)
    {
        
    }
    
    public override void Draw(Graphics g)
    {
        g.SmoothingMode = SmoothingMode.AntiAlias;
        g.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAliasGridFit;

        this.Size = GetSize(g);
        PointF cursor = new PointF(this.Location.X, this.Location.Y);

        g.DrawRectangle(DiagramSettings.MediumPen, cursor.X, cursor.Y, this.Size.Width, this.Size.Height);

        StringFormat centerFormat = new StringFormat();
        centerFormat.Alignment = StringAlignment.Center;
        centerFormat.LineAlignment = StringAlignment.Center;

        float headerHeight = g.MeasureString(this.Name, DiagramSettings.Font).Height * 2.5f;

        RectangleF stereotypeBounds = new RectangleF(this.Location.X, this.Location.Y, this.Size.Width, headerHeight / 2);
        RectangleF nameBounds = new RectangleF(this.Location.X, this.Location.Y + headerHeight / 2, this.Size.Width, headerHeight / 2);

        g.DrawString(this.Name, new Font(DiagramSettings.Font, this.Abstract ? FontStyle.Italic : this.Static ? FontStyle.Underline : FontStyle.Regular), DiagramSettings.LightBrush, nameBounds, centerFormat);

        float curY = this.Location.Y + headerHeight + this.gap;

        UIGraphics.DrawLineHorizontal(g, DiagramSettings.LightPen, new PointF(this.Location.X, curY), this.Size.Width);
        curY += this.gap;

        if (this.Properties.Count > 0)
        {
            curY += this.gap;

            UIGraphics.DrawPropsFlexbox(g, DiagramSettings.Font, DiagramSettings.LightBrush, new PointF(this.Location.X, curY), this.Properties, this.listIndent);

            curY += this.Properties.Count * (g.MeasureString(this.Properties.FirstOrDefault().ToString(), DiagramSettings.Font).Height + this.listIndent);

            UIGraphics.DrawLineHorizontal(g, DiagramSettings.LightPen, new PointF(this.Location.X, curY), this.Size.Width);
            curY += this.gap;
        }

        if (this.Methods.Count > 0)
        {
            curY += this.gap;

            UIGraphics.DrawPropsFlexbox(g, DiagramSettings.Font, DiagramSettings.LightBrush, new PointF(this.Location.X, curY), this.Methods, this.listIndent);
            curY += this.Methods.Count * (g.MeasureString(this.Methods.FirstOrDefault().ToString(), DiagramSettings.Font).Height + this.listIndent);
        }
    }
}