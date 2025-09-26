using System.Runtime.CompilerServices;

namespace uml_diagram.ui;

public class ClickScrollMenu
{
    private Dictionary<string, Action> _options = new();
    private ListBox _listBox = new();
    
    public ClickScrollMenu(Control.ControlCollection control, Point location)
    {
        _listBox.Location = location;
        _listBox.Name = "ClickScrollMenu";
        _listBox.Size = new Size(100, 50);
        _listBox.SelectedIndexChanged += OnSelectedIndexChanged;
        control.Add(_listBox);
    }

    public void Show()
    {
        _listBox.Refresh();
        _listBox.Show();
        _listBox.BringToFront();
    }

    public void Hide()
    {
        _listBox.Hide();
    }

    public void AddAction(string key, Action action)
    {
        _options.Add(key, action);
        _listBox.Items.Add(key);
        _listBox.Size = new Size(GetLongestOption().Length * 10  + 4, _options.Count * 20 + 2);
        _listBox.Refresh();
    }

    private void OnSelectedIndexChanged(object sender, EventArgs e)
    {
        _options[_listBox.SelectedItem.ToString()]();
        Hide();
    }

    private string? GetLongestOption()
    {
        return _options.Keys.MaxBy(x => x.Length);
    }
}