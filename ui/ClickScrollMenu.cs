using System.Runtime.CompilerServices;

namespace uml_diagram.ui;

public class ClickScrollMenu
{
    private Dictionary<string, Action> _options = new();
    public ContextMenuStrip _menu = new();
    public event Action Payload;

    public Point Location { get; set; }

    public ClickScrollMenu()
    {
    }
    
    public ClickScrollMenu(Control.ControlCollection control, Point location)
    {
        _menu.Location = location;
        _menu.Name = "ClickScrollMenu";
        _menu.Size = new Size(100, 50);
    }

    public void Show(Control parent, Point location)
    {
        _menu.Show(parent, location);
    }

    public void Hide()
    {
        _menu.Hide();
    }

    public void AddAction(string key, Action<object?, EventArgs> action)
    {
        ToolStripMenuItem item = new ToolStripMenuItem(key);
        _menu.Items.Add(item);
        item.Click += (sender, args) =>
        {
            action(sender, args);
            Payload.Invoke();
        };
        _menu.Refresh();
    }

    public ContextMenuStrip GetMenu() => this._menu;

    private string? GetLongestOption()
    {
        return _options.Keys.MaxBy(x => x.Length);
    }
}