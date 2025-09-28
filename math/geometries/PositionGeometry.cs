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

    public static (PointF, PointF) GetGatewaysByQuadrant(IComponent mainObject, IComponent secondObject, Quadrant quadrant)
    {
        bool secondObjCloserToXAxis = Math.Abs(secondObject.Location.X - mainObject.Location.X) < Math.Abs(secondObject.Location.Y - mainObject.Location.Y);
        PointF mainObjectCenter = CalcComponentCenter(mainObject);
        PointF secondObjectCenter = CalcComponentCenter(secondObject);

        return quadrant switch
        {
            Quadrant.TopLeft => new Func<(PointF, PointF)>(() =>
                {
                    if (secondObject.Location.Y > mainObject.Location.Y && secondObject.Location.Y < (mainObject.Location.Y + mainObject.Size.Height))
                    {
                        return (new PointF(mainObjectCenter.X, mainObject.Location.Y),
                            new PointF(secondObjectCenter.X, secondObject.Location.Y));
                    }

                    return (new PointF(mainObjectCenter.X, mainObject.Location.Y), 
                        new PointF(secondObjectCenter.X, secondObject.Location.Y + secondObject.Size.Height));
                })(),
            Quadrant.TopRight => new Func<(PointF, PointF)>(() =>
                {
                    if(secondObject.Location.Y > mainObject.Location.Y && secondObject.Location.Y < (mainObject.Location.Y + mainObject.Size.Height))
                    {
                        return (new PointF(mainObjectCenter.X, mainObject.Location.Y),
                            new PointF(secondObjectCenter.X, secondObject.Location.Y));
                    }
                    
                    return (new PointF(mainObjectCenter.X, mainObject.Location.Y), 
                        new PointF(secondObjectCenter.X, secondObject.Location.Y + secondObject.Size.Height));
                })(),
            Quadrant.BottomRight => new Func<(PointF, PointF)>(() =>
                {
                    if (secondObject.Location.Y > mainObject.Location.Y &&
                        secondObject.Location.Y < (mainObject.Location.Y + mainObject.Size.Height))
                    {
                        return (new PointF(mainObjectCenter.X, mainObject.Location.Y + mainObject.Size.Height), 
                            new PointF(secondObjectCenter.X, secondObject.Location.Y + secondObject.Size.Height));
                    }
                    
                    return (new PointF(mainObjectCenter.X, mainObject.Location.Y + mainObject.Size.Height), 
                        new PointF(secondObjectCenter.X, secondObject.Location.Y));
                })(),
            Quadrant.BottomLeft => new Func<(PointF, PointF)>(() => 
            {
                    if (secondObject.Location.Y > mainObject.Location.Y &&
                        secondObject.Location.Y < (mainObject.Location.Y + mainObject.Size.Height))
                    {
                        return (new PointF(mainObjectCenter.X, mainObject.Location.Y + mainObject.Size.Height), 
                            new PointF(secondObjectCenter.X, secondObject.Location.Y + secondObject.Size.Height));
                    }
                    
                    return (new PointF(mainObjectCenter.X, mainObject.Location.Y + mainObject.Size.Height), 
                        new PointF(secondObjectCenter.X, secondObject.Location.Y));
            })(),
        }; 
    }
    
    public static (PointF, PointF) CalcComponentsGateways(IComponent mainObject, IComponent secondObject) => 
        GetGatewaysByQuadrant(mainObject, secondObject, CalcComponentQuadrant(mainObject, secondObject));

    public static PointF[] CalcRelationShipPath(IComponent mainObject, IComponent secondObject)
    {
        (PointF mainObjectGateway, PointF secondObjectGateway) = CalcComponentsGateways(mainObject, secondObject);
        bool secondObjCloserToXAxis = Math.Abs(secondObject.Location.X - mainObject.Location.X) < Math.Abs(secondObject.Location.Y - mainObject.Location.Y);
        float distY = Math.Abs(secondObjectGateway.Y - mainObjectGateway.Y);
        float distX = Math.Abs(secondObjectGateway.X - mainObjectGateway.X);
        
        return CalcComponentQuadrant(mainObject, secondObject) switch
        {
            Quadrant.TopLeft => new Func<PointF[]>(() =>
                {
                    if (secondObject.Location.Y > mainObject.Location.Y &&
                        secondObject.Location.Y < (mainObject.Location.Y + mainObject.Size.Height))
                    {
                        return new PointF[] 
                        {
                            mainObjectGateway,
                            new PointF(mainObjectGateway.X, mainObjectGateway.Y - 20),
                            new PointF(secondObjectGateway.X, secondObjectGateway.Y - 20),
                            secondObjectGateway
                        };
                    }

                    return new PointF[]
                    {
                        mainObjectGateway,
                        new PointF(mainObjectGateway.X, mainObjectGateway.Y - 20),
                        new PointF(secondObjectGateway.X, mainObjectGateway.Y - 20),
                        secondObjectGateway
                    };
                })(),
            Quadrant.TopRight => new Func<PointF[]>(() =>
                {
                    if (secondObject.Location.Y > mainObject.Location.Y &&
                        secondObject.Location.Y < (mainObject.Location.Y + mainObject.Size.Height))
                    {
                        return new PointF[] 
                        {
                            mainObjectGateway,
                            new PointF(mainObjectGateway.X, mainObjectGateway.Y - 20),
                            new PointF(secondObjectGateway.X, secondObjectGateway.Y - 20),
                            secondObjectGateway
                        };
                    }

                    return new PointF[]
                    {
                        mainObjectGateway,
                        new PointF(mainObjectGateway.X, mainObjectGateway.Y - 20),
                        new PointF(secondObjectGateway.X, mainObjectGateway.Y - 20),
                        secondObjectGateway
                    };
                })(),
            Quadrant.BottomRight => new Func<PointF[]>(() => 
                {
                    if (secondObject.Location.Y > mainObject.Location.Y &&
                        secondObject.Location.Y < (mainObject.Location.Y + mainObject.Size.Height))
                    {
                        return new PointF[] 
                        {
                            mainObjectGateway,
                            new PointF(mainObjectGateway.X, mainObjectGateway.Y + 20),
                            new PointF(secondObjectGateway.X, secondObjectGateway.Y + 20),
                            secondObjectGateway
                        };
                    }

                    return new PointF[]
                    {
                        mainObjectGateway,
                        new PointF(mainObjectGateway.X, mainObjectGateway.Y + 20),
                        new PointF(secondObjectGateway.X, mainObjectGateway.Y + 20),
                        secondObjectGateway
                    };
                })(),
            Quadrant.BottomLeft => new Func<PointF[]>(() =>
                {
                    if (secondObject.Location.Y > mainObject.Location.Y &&
                        secondObject.Location.Y < (mainObject.Location.Y + mainObject.Size.Height))
                    {
                        return new PointF[] 
                        {
                            mainObjectGateway,
                            new PointF(mainObjectGateway.X, mainObjectGateway.Y + 20),
                            new PointF(secondObjectGateway.X, secondObjectGateway.Y + 20),
                            secondObjectGateway
                        };
                    }

                    return new PointF[]
                    {
                        mainObjectGateway,
                        new PointF(mainObjectGateway.X, mainObjectGateway.Y + 20),
                        new PointF(secondObjectGateway.X, mainObjectGateway.Y + 20),
                        secondObjectGateway
                    };
                })(),
        };
    }
}