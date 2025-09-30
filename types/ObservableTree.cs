namespace uml_diagram.types;

public class ObservableTreeNode<T>
{
    public T Value { get; set; }
    public ObservableTreeNode<T> Parent { get; private set; }
    public List<ObservableTreeNode<T>> Children { get; set; } = new();
    
    public event Action<ObservableTreeNode<T>>? NodeAdded;
    public event Action<ObservableTreeNode<T>>? NodeRemoved;
    public event Action<ObservableTreeNode<T>>? NodeChanged; 
    
    public ObservableTreeNode(T value) 
    {
        Value = value;
        Parent = null;
    }

    public void AddChild(T item)
    {
        ObservableTreeNode<T> node = new(item);
        node.Parent = this;
        Children.Add(node);
        NodeChanged?.Invoke(this);
    }

    public void AddChild(ObservableTreeNode<T> item)
    {
        Children.Add(item);
        NodeChanged?.Invoke(this);
    }

    public void RemoveChild(ObservableTreeNode<T> item)
    {
        if(Children.Remove(item))
            NodeRemoved?.Invoke(item);
    }

    public void UpdateValue(T newValue)
    {
        Value = newValue;
        NodeChanged?.Invoke(this);
    }

    public ObservableTreeNode<T>? FindChild(T value)
    {
        if (value.Equals(Value))
            return this;

        foreach (var child in Children)
        {
            ObservableTreeNode<T> res = child.FindChild(value);
            if (res is not null)
                return res;
        }

        return null;
    }

    public IEnumerable<ObservableTreeNode<T>> GetReverseEnumerator()
    {
        var current = this;
        while (current is not null)
        {
            yield return current;
            current = current.Parent;
        }
    }

    public IEnumerator<ObservableTreeNode<T>> GetEnumerator()
    {
        yield return this;

        foreach (var child in Children)
        {
            foreach (var desc in child)
                yield return desc;
        }
    }
}