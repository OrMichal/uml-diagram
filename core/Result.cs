namespace uml_diagram.core;

public class Result
{
    public static Exception? Run(Action action)
    {
        try
        {
            return null;
        }
        catch (Exception e)
        {
            return e;
        }
    }
}