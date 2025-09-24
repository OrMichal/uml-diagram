namespace uml_diagram.interfaces;

public interface IInteractable
{
    public bool IsCursorHovering(MouseEventArgs e);
    public void OnDoubleClick(MouseEventArgs e);
}