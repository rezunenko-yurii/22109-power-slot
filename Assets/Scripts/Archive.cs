using System.Collections.Generic;

public class Archive<T>
{
    private Dictionary<string, T> _dictionary = new Dictionary<string, T>();
        
    public T GetFromArchive(string id)
    {
        T uiObject = _dictionary[id];
        RemoveFromArchive(id);

        return uiObject;
    }
        
    public void TryRemoveFromArchive(string id)
    {
        if (_dictionary.ContainsKey(id))
        {
            RemoveFromArchive(id);
        }
    }
        
    private void RemoveFromArchive(string id)
    {
        _dictionary.Remove(id);
    }

    public bool Contains(string id) => _dictionary.ContainsKey(id);

    public void Add(string id, T obj)
    {
        _dictionary.Add(id, obj);
    }
}