using uml_diagram.interfaces;
using uml_diagram.math.enums;

namespace uml_diagram.math.geometries;

public static class PositionGeometry
{
    public static PointF CalcComponentCenter(IComponent component) => 
        new(component.Location.X + component.Size.Width / 2, component.Location.Y + component.Size.Height / 2);

    public static Quadrant CalcComponentQuadrant(IComponent mainObject, IComponent secondObject)
    {
        var mainObjectCenter = CalcComponentCenter(mainObject);
        var secondObjectCenter = CalcComponentCenter(secondObject);

        if (secondObjectCenter.X > mainObjectCenter.X && secondObjectCenter.Y > mainObjectCenter.Y) return Quadrant.BottomRight;
        else if(secondObjectCenter.X > mainObjectCenter.X && secondObjectCenter.Y < mainObjectCenter.Y) return Quadrant.TopRight;
        else if (secondObjectCenter.X < mainObjectCenter.X && secondObjectCenter.Y < mainObjectCenter.Y) return Quadrant.TopLeft;
        else return Quadrant.BottomLeft;
    }

    public static (PointF, PointF) GetGatewaysByQuadrant(IConnectableComponent mainObject, IConnectableComponent secondObject, Quadrant quadrant)
        => quadrant switch
        {
            Quadrant.TopLeft or Quadrant.TopRight => secondObject.Location.Y > mainObject.Location.Y &&
                                                        secondObject.Location.Y < mainObject.Location.Y + (mainObject.Size.Height * 2)
                ? (mainObject.TopCenter, secondObject.TopCenter)
                : (mainObject.TopCenter, secondObject.BottomCenter),
            Quadrant.BottomRight or Quadrant.BottomLeft => secondObject.Location.Y < mainObject.Location.Y &&
                                                           secondObject.Location.Y > mainObject.Location.Y - (mainObject.Size.Height * 2)
                ? (mainObject.BottomCenter, secondObject.BottomCenter)
                : (mainObject.BottomCenter, secondObject.TopCenter),
        };
    
    public static (PointF, PointF) CalcComponentsGateways(IConnectableComponent mainObject, IConnectableComponent secondObject) => 
        GetGatewaysByQuadrant(mainObject, secondObject, CalcComponentQuadrant(mainObject, secondObject));

    public static PointF[] CalcRelationShipPath(IConnectableComponent mainObject, IConnectableComponent secondObject)
    {
        (PointF mainObjectGateway, PointF secondObjectGateway) = CalcComponentsGateways(mainObject, secondObject);
        bool secondObjCloserToXAxis = Math.Abs(secondObject.Location.X - mainObject.Location.X) < Math.Abs(secondObject.Location.Y - mainObject.Location.Y);
        float distY = Math.Abs(secondObjectGateway.Y - mainObjectGateway.Y);
        float distX = Math.Abs(secondObjectGateway.X - mainObjectGateway.X);
        
        return CalcComponentQuadrant(mainObject, secondObject) switch
        {
            Quadrant.TopLeft or Quadrant.TopRight => new PointF[] 
                {
                    mainObjectGateway,
                    new PointF(mainObjectGateway.X, mainObjectGateway.Y - distY / 2),
                    new PointF(secondObjectGateway.X, mainObjectGateway.Y - distY / 2),
                    secondObjectGateway
                },
            Quadrant.BottomLeft or Quadrant.BottomRight => new PointF[] 
                {
                    mainObjectGateway,
                    new PointF(mainObjectGateway.X, mainObjectGateway.Y + distY / 2),
                    new PointF(secondObjectGateway.X, mainObjectGateway.Y + distY / 2),
                    secondObjectGateway
                }
        };
    }
}