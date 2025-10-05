using System.Drawing.Drawing2D;
using uml_diagram.core;
using uml_diagram.interfaces;
using uml_diagram.math.enums;
using uml_diagram.math.geometries;
using uml_diagram.ui.elements;

namespace uml_diagram.ui;

public static class RelationshipGuidanceCouncil
{
    public static void DrawAssociation(Graphics g, IConnectableComponent mainObject, IConnectableComponent secondaryObject)
    {
        PointF[] points = PositionGeometry.CalcRelationShipPath(mainObject, secondaryObject);
        g.DrawLines(DiagramSettings.LightPen, points);
    }

    public static void DrawDirectAssociation(Graphics g, IConnectableComponent mainObject, IConnectableComponent secondaryObject, SizeF arrowSize)
    {
        PointF[] points = PositionGeometry.CalcRelationShipPath(mainObject, secondaryObject);
        Direction arrowDirection = mainObject.Location.Y < secondaryObject.Location.Y ? Direction.Up : Direction.Down;
        UIArrow arrow = new(points[0], arrowSize, arrowDirection);
        arrow.Filled = true;
        
        g.DrawLines(DiagramSettings.LightPen, points);
        arrow.Draw(g);
    }

    public static void DrawReflexiveAssociation(Graphics g, IConnectableComponent mainObject, int distance = 20)
    {
        PointF[] points = new[]
        {
            mainObject.RightCenter, 
            new PointF(mainObject.RightCenter.X + distance, mainObject.RightCenter.Y),
            new PointF(mainObject.RightCenter.X + distance, mainObject.RightCenter.Y - distance),
            new PointF(mainObject.TopCenter.X, mainObject.RightCenter.Y - distance),
            mainObject.TopCenter
        };
        g.DrawLines(DiagramSettings.LightPen, points);
        
        UILabel rightLabel = new(new PointF(mainObject.RightCenter.X + distance - 10, mainObject.RightCenter.Y - 10), "0..*", true);
        UILabel leftLabel = new(new PointF(mainObject.TopCenter.X, mainObject.RightCenter.Y - distance - 10), "0..*", true);

        rightLabel.Padding = 1;
        leftLabel.Padding = 1;
        
        rightLabel.Draw(g);
        leftLabel.Draw(g);
    }

    public static void DrawMultiplicity(Graphics g, IConnectableComponent mainObject, IConnectableComponent secondaryObject)
    {
        PointF[] points = PositionGeometry.CalcRelationShipPath(mainObject, secondaryObject);
        
        g.DrawLines(DiagramSettings.LightPen, points);

        UILabel label = new(points[0], "0..*", true);
        label.Padding = 1;
        label.Font = DiagramSettings.SmolFont;
        
        label.DrawCenterBetween(g, points[1], points[2]);
    }

    public static void DrawAggregation(Graphics g, IConnectableComponent mainObject, IConnectableComponent secondaryObject, SizeF diamondSize)
    {
        Direction diamondDirection = mainObject.Location.Y < secondaryObject.Location.Y ? Direction.Up : Direction.Down;
        PointF[] points = PositionGeometry.CalcRelationShipPath(mainObject, secondaryObject);
        g.DrawLines(DiagramSettings.LightPen, points);
        
        UIDiamond diamond = new(points[0], diamondSize, diamondDirection);
        diamond.Draw(g);
        
        UILabel label = new(points[0], "1.*", true);
        label.Padding = 1;
        label.Font = DiagramSettings.SmolFont;
        
        label.DrawCenterBetween(g, points[1], points[2]);
    }

    public static void DrawComposition(Graphics g, IConnectableComponent mainObject, IConnectableComponent secondaryObject, SizeF diamondSize)
    {
        Direction diamondDirection = mainObject.Location.Y < secondaryObject.Location.Y ? Direction.Up : Direction.Down;
        PointF[] points = PositionGeometry.CalcRelationShipPath(mainObject, secondaryObject);
        g.DrawLines(DiagramSettings.LightPen, points);
        
        UIDiamond diamond = new(points[0], diamondSize, diamondDirection);
        diamond.Filled = true;
        diamond.Draw(g);
    }

    public static void DrawInheritence(Graphics g, IConnectableComponent mainObject, IConnectableComponent secondaryObject, SizeF arrowSize)
    {
        PointF[] points = PositionGeometry.CalcRelationShipPath(mainObject, secondaryObject);
        Direction arrowDirection = mainObject.Location.Y < secondaryObject.Location.Y ? Direction.Up : Direction.Down;
        UIArrow arrow = new(points[0], arrowSize, arrowDirection);

        Pen p = DiagramSettings.LightPen;
        p.DashStyle = DashStyle.Solid;
        
        g.DrawLines(p, points);
        arrow.Draw(g);
    }

    public static void DrawRealization(Graphics g, IConnectableComponent mainObject, IConnectableComponent secondaryObject, SizeF arrowSize)
    {
        PointF[] points = PositionGeometry.CalcRelationShipPath(mainObject, secondaryObject);
        Direction arrowDirection = mainObject.Location.Y < secondaryObject.Location.Y ? Direction.Up : Direction.Down;
        UIArrow arrow = new(points[0], arrowSize, arrowDirection);

        Pen p = DiagramSettings.LightPen;
        p.DashStyle = DashStyle.Dot;
        g.DrawLines(p, points);
        arrow.Draw(g);
    }
}