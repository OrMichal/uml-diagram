namespace uml_diagram.interfaces;

public interface IInteractable
{
    public bool IsCursorHovering(Point e);
    public void OnDoubleClick(Point e);
}